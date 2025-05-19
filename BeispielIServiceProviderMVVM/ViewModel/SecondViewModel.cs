using BeispielIServiceProviderMVVM.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeispielIServiceProviderMVVM.ViewModel
{
    public class SecondViewModel
    {
        public ICommand SayHelloCommand { get; }

        public SecondViewModel(SimpleServiceProvider _)
        {
            SayHelloCommand = new RelayCommand(() => MessageBox.Show("Hello from Second Window!"));
        }
    }
}
