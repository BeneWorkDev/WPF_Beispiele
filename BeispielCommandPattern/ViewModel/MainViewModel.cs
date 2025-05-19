using BeispielCommandPattern.Commands;
using Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace BeispielCommandPattern.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _text;
        private string _backgroundColor;
        private Visibility _textBoxVisibility;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(Text)); }
        }

        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
        }

        public System.Windows.Visibility TextBoxVisibility
        {
            get { return _textBoxVisibility; }
            set { _textBoxVisibility = value; OnPropertyChanged(nameof(TextBoxVisibility)); }
        }

        public ICommand ChangeTextCommand { get; }
        public ICommand ChangeColorCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand ToggleVisibilityCommand { get; }
        public ICommand ShowMessageCommand { get; }

        public MainViewModel()
        {
            ChangeTextCommand = new ChangeTextCommand(ChangeText);
            ChangeColorCommand = new ChangeColorCommand(ChangeColor);
            ResetCommand = new ResetCommand(Reset);
            ToggleVisibilityCommand = new ToggleVisibilityCommand(ToggleVisibility);
            ShowMessageCommand = new ShowMessageCommand(ShowMessage);

            // Initialisierung von Eigenschaften
            Text = "Initialer Text";
            BackgroundColor = "White";
            TextBoxVisibility = Visibility.Visible;
        }

        private void ChangeText()
        {
            Text = "Text wurde geändert!";
        }

        private void ChangeColor()
        {
            BackgroundColor = BackgroundColor == "White" ? "Yellow" : "White";
        }

        private void Reset()
        {
            Text = "Initialer Text";
            BackgroundColor = "White";
        }

        private void ToggleVisibility()
        {
            TextBoxVisibility = TextBoxVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ShowMessage()
        {
            Console.WriteLine("Button wurde gedrückt!");
        }
    }
}
