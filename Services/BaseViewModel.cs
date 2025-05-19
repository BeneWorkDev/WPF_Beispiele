using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Services
{
    /*
     * Eine BaseViewModel-Klasse dient als Ausgangspunkt für alle ViewModels in einer WPF-Anwendung. Sie hilft, häufige Aufgaben zu 
     * zentralisieren, wie das Implementieren von INotifyPropertyChanged und das Verwalten von Commands. Es ist ein gutes Designmuster, 
     * weil es dafür sorgt, dass alle ViewModels dieselbe Basisfunktionalität nutzen, was den Code wartungsfreundlicher und sauberer macht.
     * Hier ist eine detaillierte und gut dokumentierte BaseViewModel-Klasse, die einige zusätzliche nützliche Funktionen bietet:
     * 
     *  Erklärung der BaseViewModel-Klasse

        INotifyPropertyChanged-Implementierung:

        Die Klasse implementiert INotifyPropertyChanged, um sicherzustellen, dass Änderungen an den Eigenschaften des ViewModels 
        automatisch im UI reflektiert werden. Jede Eigenschaft kann OnPropertyChanged() aufrufen, um den entsprechenden Bindings 
        zu informieren.

        SetProperty-Methode:

        Diese Methode hilft dabei, Werte sicher zu setzen und automatisch die PropertyChanged-Benachrichtigung auszulösen, 
        wenn sich der Wert einer Eigenschaft ändert. Dies reduziert Boilerplate-Code und vermeidet das manuelle Setzen von 
        PropertyChanged für jede einzelne Eigenschaft.

        RegisterCommand und GetCommand:

        Diese Methoden ermöglichen es dir, Commands zu registrieren und darauf zuzugreifen. Die BaseViewModel-Klasse speichert Commands 
        intern in einer Dictionary<string, ICommand>, sodass du bequem mit mehreren Commands in deinem ViewModel arbeiten kannst.

        DisableAllCommands:

        Diese Methode ruft für alle Commands im BaseViewModel die RaiseCanExecuteChanged()-Methode auf. Sie kann verwendet werden, 
        um alle Commands gleichzeitig zu deaktivieren oder zu aktivieren, wenn z. B. bestimmte Bedingungen eintreten.
     */

    public class BaseViewModel : INotifyPropertyChanged
    {
        // Event, das ausgelöst wird, wenn sich eine Eigenschaft ändert
        public event PropertyChangedEventHandler PropertyChanged;

        // Hilfsmethode zum Auslösen des PropertyChanged-Events
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Hilfsmethode zum Setzen von Eigenschaften und Auslösen von PropertyChanged
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // Speichert eine Liste von Commands für eine einfache Verwaltung
        private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        // Hilfsmethode, um ein Command zu registrieren
        protected void RegisterCommand(string commandName, ICommand command)
        {
            if (_commands.ContainsKey(commandName))
                _commands[commandName] = command;
            else
                _commands.Add(commandName, command);
        }

        // Hilfsmethode, um ein Command abzurufen
        protected ICommand GetCommand(string commandName)
        {
            if (_commands.TryGetValue(commandName, out ICommand command))
                return command;

            return null;
        }

        // Möglichkeit, alle Commands im ViewModel zu deaktivieren
        protected void DisableAllCommands()
        {
            foreach (var command in _commands.Values.OfType<DelegateCommand>())
            {
                command.RaiseCanExecuteChanged();
            }
        }
    }
}
