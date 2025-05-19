using BeispielMediatorPattern.Classes;
using BeispielMediatorPattern.CustomControls;
using BeispielMediatorPattern.Interfaces;
using BeispielMediatorPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeispielMediatorPattern
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMediator _mediator;
        private readonly ViewModel1 _viewModel1;
        private readonly ViewModel2 _viewModel2;
        private readonly ViewModel3 _viewModel3;

        public MainWindow()
        {
            InitializeComponent();

            _mediator = new Mediator();

            // Erstellen der Views
            var view1 = new View1();
            var view2 = new View2();
            var view3 = new View3();

            // Views beim Mediator registrieren
            _mediator.RegisterView("View1", view1);
            _mediator.RegisterView("View2", view2);
            _mediator.RegisterView("View3", view3);

            // Setze das ContentControl auf die erste View
            MainContent.Content = view1;

            // Erstellen der ViewModels
            _viewModel1 = new ViewModel1(_mediator);
            _viewModel2 = new ViewModel2(_mediator);
            _viewModel3 = new ViewModel3(_mediator);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initiale View setzen
            _mediator.SwitchView("View1");
        }

        // Beispielmethoden, um Views zu wechseln
        private void SwitchToView2_Click(object sender, RoutedEventArgs e)
        {
            _viewModel1.SwitchToView2();
        }

        private void SwitchToView3_Click(object sender, RoutedEventArgs e)
        {
            _viewModel2.SwitchToView3();
        }
    }
}
