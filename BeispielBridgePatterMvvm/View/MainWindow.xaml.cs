using BeispielBridgePatterMvvm.ViewModel;
using System.Windows;

namespace BeispielBridgePatterMvvm
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
