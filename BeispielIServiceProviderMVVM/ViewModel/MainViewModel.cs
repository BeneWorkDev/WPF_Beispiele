using BeispielIServiceProviderMVVM.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeispielIServiceProviderMVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly SimpleServiceProvider _serviceProvider;

        public ICommand OpenSecondWindowCommand { get; }

        public MainViewModel(SimpleServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            OpenSecondWindowCommand = new RelayCommand(OpenSecondWindow);
        }

        private void OpenSecondWindow()
        {
            var secondWindow = _serviceProvider.Get<View.SecondWindow>();
            secondWindow.Show();
        }
    }
}
