using BeispielIServiceProviderUserControl.Services;
using Services;
using System.Windows;
using System.Windows.Input;

namespace BeispielIServiceProviderUserControl.ViewModel
{
    public class SecondViewModel : BaseViewModel
    {
        public ICommand SayHelloCommand { get; }

        public SecondViewModel(SimpleServiceProvider _)
        {
            SayHelloCommand = new RelayCommand(() => MessageBox.Show("Hello from Second View!"));
        }
    }
}
