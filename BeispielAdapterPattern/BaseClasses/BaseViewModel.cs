using System.ComponentModel;

namespace BeispielAdapterPattern.BaseClasses
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Hilfsmethode zur Benachrichtigung von Änderungen
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
