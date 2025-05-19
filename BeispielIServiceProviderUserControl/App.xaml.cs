using BeispielIServiceProviderUserControl.Services;
using BeispielIServiceProviderUserControl.View;
using BeispielIServiceProviderUserControl.ViewModel;
using System.Windows;

namespace BeispielIServiceProviderUserControl
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static SimpleServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider = new SimpleServiceProvider();

            // Registrierungen
            ServiceProvider.Register(() => new HomeViewModel(ServiceProvider));
            ServiceProvider.Register(() => new SecondViewModel(ServiceProvider));
            ServiceProvider.Register(() => new MainViewModel(ServiceProvider));
            // DataContext erstellen
            ServiceProvider.Register(() => new HomeView { DataContext = ServiceProvider.Get<HomeViewModel>() });
            ServiceProvider.Register(() => new SecondView { DataContext = ServiceProvider.Get<SecondViewModel>() });
            ServiceProvider.Register(() => new MainWindow { DataContext = ServiceProvider.Get<MainViewModel>() });

            var mainWindow = ServiceProvider.Get<MainWindow>();
            mainWindow.Show();
        }
    }
}
