using System;
using System.Windows.Input;

namespace BeispielCommandPattern.BasicClasses
{
    public abstract class CommandBase : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        protected CommandBase(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (() => true); // Standardmäßig immer ausführbar
        }

        public bool CanExecute(object parameter) => _canExecute();

        public void Execute(object parameter) => _execute?.Invoke();

        // Diese Methode kann von abgeleiteten Klassen aufgerufen werden, um CanExecute neu zu berechnen
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
