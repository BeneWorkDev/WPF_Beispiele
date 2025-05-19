using Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WartungsTool_v._2.Model;
using WartungsTool_v._2.Services;

namespace WartungsTool_v._2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand ToggleThemeCommand { get; }
        private bool _isDarkTheme = true;

        public ObservableCollection<PathEntry> PathsToClean { get; } = new ObservableCollection<PathEntry>();
        public ObservableCollection<string> DeletedItems { get; } = new ObservableCollection<string>();

        public ICommand CleanCommand { get; }
        public ICommand AddPathCommand { get; }

        private double _progress;
        public double Progress
        {
            get => _progress;
            set { _progress = value; OnPropertyChanged(); }
        }

        private void AddPath()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (!PathsToClean.Any(p => p.Path.Equals(dialog.SelectedPath, StringComparison.OrdinalIgnoreCase)))
                    PathsToClean.Add(new PathEntry { Path = dialog.SelectedPath });
            }
        }

        private void Clean()
        {
            DeletedItems.Clear();
            var selectedPaths = PathsToClean.Where(p => p.IsSelected).ToList();
            int total = selectedPaths.Count;
            int current = 0;

            foreach (var path in selectedPaths)
            {
                var deleted = CleanupHelper.CleanPath(path.Path);
                foreach (var entry in deleted)
                    DeletedItems.Add(entry);

                current++;
                Progress = (double)current / total * 100;
            }

            System.Windows.MessageBox.Show("Bereinigung vollständig", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public string CurrentThemeName => _isDarkTheme ? "Night" : "Day";

        private void ToggleTheme()
        {
            _isDarkTheme = !_isDarkTheme;
            ThemeManager.ApplyTheme(_isDarkTheme);
        }

        public MainViewModel()
        {
            ToggleThemeCommand = new RelayCommand(ToggleTheme);
            // Initiales Theme laden
            ThemeManager.ApplyTheme(_isDarkTheme);

            CleanCommand = new RelayCommand(Clean);
            AddPathCommand = new RelayCommand(AddPath);

            PathsToClean.Add(new PathEntry { Path = "recyclebin://", IsSelected = true });
            PathsToClean.Add(new PathEntry { Path = Path.GetTempPath(), IsSelected = true });
            PathsToClean.Add(new PathEntry { Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)), IsSelected = true });
            PathsToClean.Add(new PathEntry { Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows", "INetCache"), IsSelected = true });
            PathsToClean.Add(new PathEntry { Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp"), IsSelected = true });
        }

    }
}
