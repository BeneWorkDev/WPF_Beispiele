using Services;
using System;
using System.Collections.ObjectModel;

namespace BeispielBaseViewModel.ViewModel
{
    /*
     *  Erklärung des MainViewModel

        SelectedItem: Eine Eigenschaft, die mit dem UI (z. B. eine ListBox) gebunden ist. Änderungen an SelectedItem lösen automatisch 
        OnPropertyChanged aus.

        Items: Eine ObservableCollection, die eine Liste von Items darstellt und mit der UI verbunden ist. Jedes Mal, wenn ein Item 
        hinzugefügt oder entfernt wird, wird das UI automatisch aktualisiert.

        DeleteItemCommand: Ein DelegateCommand, das aus einer Action und einer Func<bool> besteht:

        ExecuteDeleteItem(): Wird ausgeführt, wenn der Button gedrückt wird. Löscht das aktuell ausgewählte Item aus der Liste.

        CanExecuteDeleteItem(): Gibt an, ob der Befehl ausgeführt werden kann. In diesem Fall nur, wenn ein Element ausgewählt wurde.

        RegisterCommand("DeleteItemCommand", DeleteItemCommand): Das Command wird registriert, um sicherzustellen, dass es im 
        BaseViewModel gespeichert wird. Dies ist besonders nützlich, wenn du später alle Commands überwachen oder ändern möchtest.
     */

    public class MainViewModel : BaseViewModel
    {
        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ObservableCollection<string> Items { get; set; }

        // DeleteCommand wird als DelegateCommand erstellt
        public DelegateCommand DeleteItemCommand { get; }

        public MainViewModel()
        {
            // Initialisierung der Items
            Items = new ObservableCollection<string>
        {
            "Item A", "Item B", "Item C"
        };

            // Initialisierung des DeleteItemCommand
            DeleteItemCommand = new DelegateCommand(
                () => ExecuteDeleteItem(),
                () => CanExecuteDeleteItem()
            );

            // Registrieren des Commands im ViewModel
            RegisterCommand("DeleteItemCommand", DeleteItemCommand);
        }

        private void ExecuteDeleteItem()
        {
            if (!string.IsNullOrWhiteSpace(SelectedItem) && Items.Contains(SelectedItem))
            {
                Items.Remove(SelectedItem);
                SelectedItem = null;
                Console.WriteLine($"Item '{SelectedItem}' gelöscht.");
            }
        }

        private bool CanExecuteDeleteItem()
        {
            // Der Befehl ist nur aktiv, wenn ein Item ausgewählt wurde
            return !string.IsNullOrWhiteSpace(SelectedItem);
        }
    }
}
