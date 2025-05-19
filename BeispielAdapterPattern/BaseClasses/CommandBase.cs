using System;
using System.Windows.Input;

namespace BeispielAdapterPattern.BaseClasses
{
    public abstract class CommandBase : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // Event für das Überprüfen der Ausführbarkeit
        public event EventHandler CanExecuteChanged;

        protected CommandBase(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (() => true); // Standard: immer ausführbar
        }

        // Überprüfen, ob der Command ausgeführt werden kann
        public bool CanExecute(object parameter) => _canExecute();

        // Ausführen des Commands
        public void Execute(object parameter) => _execute();

        // Manuelle Benachrichtigung, dass sich die Ausführbarkeit geändert hat
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
