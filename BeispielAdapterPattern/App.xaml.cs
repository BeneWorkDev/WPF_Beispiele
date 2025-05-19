using BeispielAdapterPattern.ViewModel;
using System.Windows;

namespace BeispielAdapterPattern
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel() // Setze das ViewModel als DataContext
            };
            mainWindow.Show();
        }
    }
}
