using BeispielWartungsTool.Helpers;
using BeispielWartungsTool.Model;
using Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BeispielWartungsTool.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private int _progress;
        public int Progress
        {
            get => _progress;
            set { _progress = value; OnPropertyChanged(); }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        private int _deletedCount;
        public int DeletedCount
        {
            get => _deletedCount;
            set { _deletedCount = value; OnPropertyChanged(); }
        }

        public ObservableCollection<CleanablePath> PathsToClean { get; set; }
        public ObservableCollection<string> DeletedItems { get; set; } = new ObservableCollection<string>();

        public ICommand CleanupCommand { get; }

        public MainViewModel()
        {

            PathsToClean = new ObservableCollection<CleanablePath>(CleanupHelper.GetCommonPaths());
            
            CleanupCommand = new RelayCommand(ExecuteCleanup);
        }

        private async void ExecuteCleanup()
        {
            DeletedItems.Clear();
            DeletedCount = 0;
            Status = "Bereinige...";

            var selected = PathsToClean.Where(p => p.IsSelected).ToList();
            int total = selected.Count;
            int done = 0;

            Progress = 0;

            foreach (var path in selected)
            {
                await Task.Run(() =>
                {
                    var results = CleanupHelper.CleanPath(path.Path);

                    App.Current.Dispatcher.Invoke(() =>
                    {
                        foreach (var r in results)
                        {
                            DeletedItems.Add(r);
                            if (r.StartsWith("Datei gelöscht") || r.StartsWith("Ordner gelöscht"))
                                DeletedCount++;
                        }

                        done++;
                        Progress = (int)((done / (double)total) * 100);

                        if(Progress == 100)
                        {
                            MessageBox.Show("Bereinigung erfolgreich abgeschlossen!");
                        }
                    });
                });
            }

            Status = "Bereinigung abgeschlossen";
        }
    }
}
