using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeispielGenericEvents.ViewModel
{
    public class MainViewModel
    {
        // Die ObservableCollection mit Items
        public ObservableCollection<string> Items { get; set; }

        // Das generische Ereignis
        public GenericEvent<string> ItemAddedEvent { get; private set; }

        // Der Befehl zum Hinzufügen von Items
        public ICommand AddItemCommand { get; }

        public MainViewModel()
        {
            // Initialisiere die ObservableCollection
            Items = new ObservableCollection<string>();

            // Initialisiere das generische Ereignis
            ItemAddedEvent = new GenericEvent<string>();

            // Initialisiere den Command
            AddItemCommand = new RelayCommand(ExecuteAddItem);

            // Abonniere das Ereignis
            ItemAddedEvent.Event += OnItemAdded;
        }

        // Der Handler, der ausgeführt wird, wenn das Ereignis ausgelöst wird
        private void OnItemAdded(object sender, string item)
        {
            Console.WriteLine($"Item hinzugefügt: {item}");
        }

        // Die Methode, die ausgeführt wird, wenn der Command ausgelöst wird
        private void ExecuteAddItem()
        {
            string newItem = "Neues Item";
            Items.Add(newItem);
            // Ereignis auslösen
            ItemAddedEvent.Raise(this, newItem);
        }
    }
}
