using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielDelegateCommand.ViewModel
{
    public class MainViewModel
    {
        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                // Wenn sich das ausgewählte Element ändert, prüfen wir, ob der Befehl ausgeführt werden kann
                DeleteItemCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<string> Items { get; set; }

        // Der DeleteItemCommand wird mit beiden Konstruktoren verwendet
        public DelegateCommand<string> DeleteItemCommand { get; }

        public MainViewModel()
        {
            Items = new ObservableCollection<string> { "Item A", "Item B", "Item C" };

            // Konstruktor 1: Mit Action und CanExecute
            DeleteItemCommand = new DelegateCommand<string>(
                item => ExecuteDelete(item),  // Action für Execute
                item => CanExecuteDelete(item) // Func für CanExecute
            );

            // Wenn du den Befehl ohne CanExecute nutzen willst, dann kannst du Konstruktor 2 verwenden
            //DeleteItemCommand = new DelegateCommand<string>(
            //    item => ExecuteDelete(item) // Nur Action, CanExecute immer true
            //);
        }

        private void ExecuteDelete(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                SelectedItem = null;
                Console.WriteLine($"Item {item} gelöscht.");
            }
        }

        private bool CanExecuteDelete(string item)
        {
            // Beispiel: Der Befehl kann nur ausgeführt werden, wenn ein Element ausgewählt wurde
            return !string.IsNullOrWhiteSpace(item);
        }
    }
}
