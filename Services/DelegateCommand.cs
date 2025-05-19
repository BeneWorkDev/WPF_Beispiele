using System;
using System.Windows.Input;

namespace Services
{
    // Generische Klasse DelegateCommand<T>
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        // Ereignis, das ausgelöst wird, wenn sich die Möglichkeit ändert, einen Befehl auszuführen
        public event EventHandler CanExecuteChanged;

        // Konstruktor 1: Mit Action<T> und Func<T, bool> für CanExecute
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        // Konstruktor 2: Mit nur einer Action<T> für Execute und einer Standard-CanExecute-Logik
        public DelegateCommand(Action<T> execute)
            : this(execute, (T) => true)  // Standard: immer aktiv
        {
        }

        // Prüft, ob der Befehl ausgeführt werden kann
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        // Führt den Befehl aus
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        // Ruft das CanExecuteChanged-Ereignis auf, um die Aktivität des Befehls zu überprüfen
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    // Nicht Generische Klasse DelegateCommand
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        // Konstruktor 1: Mit Action und Func für CanExecute
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        // Konstruktor 2: Mit nur einer Action für Execute und einer Standard-CanExecute-Logik
        public DelegateCommand(Action execute)
            : this(execute, () => true)  // Standard: immer aktiv
        {
        }

        // Prüft, ob der Befehl ausgeführt werden kann
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        // Führt den Befehl aus
        public void Execute(object parameter)
        {
            _execute();
        }

        // Ruft das CanExecuteChanged-Ereignis auf, um die Aktivität des Befehls zu überprüfen
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
