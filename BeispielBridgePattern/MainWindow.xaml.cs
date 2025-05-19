using BeispielBridgePattern.Abstraction;
using BeispielBridgePattern.Implementations;
using BeispielBridgePattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeispielBridgePattern
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Renderer für WPF
            var renderer = new WpfRenderer(RenderMessageToUI);

            // Abstrakte View mit konkreter Implementierung kombinieren
            MessageView view = new FileMessageView(renderer);
            //MessageView view = new ApiMessageView(renderer);

            view.Display();

            // Parallel könnte ein anderer View auf Konsole ausgeben
            var consoleRenderer = new ConsoleRenderer();
            var consoleView = new ApiMessageView(consoleRenderer);
            consoleView.Display();
        }

        private void RenderMessageToUI(Message message)
        {
            TitleBlock.Text = message.Title;
            ContentBlock.Text = message.Content;
        }
    }
}
