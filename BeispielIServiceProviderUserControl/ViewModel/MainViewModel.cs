using BeispielIServiceProviderUserControl.Services;
using BeispielIServiceProviderUserControl.View;
using Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeispielIServiceProviderUserControl.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly SimpleServiceProvider _provider;

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowSecondViewCommand { get; }

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel(SimpleServiceProvider provider)
        {
            _provider = provider;

            ShowHomeViewCommand = new RelayCommand(() => CurrentView = _provider.Get<HomeView>());
            ShowSecondViewCommand = new RelayCommand(() => CurrentView = _provider.Get<SecondView>());

            // Initiale View setzen
            CurrentView = _provider.Get<HomeView>();
        }
    }
}
