using BeispielIServiceProviderMVVM.Services;
using BeispielIServiceProviderMVVM.View;
using BeispielIServiceProviderMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BeispielIServiceProviderMVVM
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

            // Registriere ViewModels
            ServiceProvider.Register(() => new MainViewModel(ServiceProvider));
            ServiceProvider.Register(() => new SecondViewModel(ServiceProvider));

            // Registriere Views
            ServiceProvider.Register(() => new MainWindow { DataContext = ServiceProvider.Get<MainViewModel>() });
            ServiceProvider.Register(() => new SecondWindow { DataContext = ServiceProvider.Get<SecondViewModel>() });

            // Starte Hauptfenster
            var mainWindow = ServiceProvider.Get<MainWindow>();
            mainWindow.Show();
        }
    }
}
