using BeispielBridgePatterMvvm.Model;
using BeispielBridgePatterMvvm.Services;
using Services;

namespace BeispielBridgePatterMvvm.ViewModel
{
    /*
    Project Struktur:
    Models/

    Message.cs
    Services/
    IMessageRenderer.cs         <- Bridge Implementierung
    MessageView.cs              <- Bridge Abstraktion
    FileMessageView.cs
    ApiMessageView.cs
    WpfRenderer.cs              <- Implementierung

    ViewModels/

    MainViewModel.cs

    Views/

    MainWindow.xaml
    MainWindow.xaml.cs

    Das Bridge Pattern wird verwendet, wenn du die Abstraktion (z. B. „Nachricht anzeigen“) von ihrer Implementierung 
    (z. B. „als WPF-UI, Konsole, Datei, etc.“) entkoppeln willst.

    Wann solltest du das Bridge Pattern verwenden?
    1. Wenn du zwei Dimensionen hast, die unabhängig variieren können

    Beispiel:

    Abstraktion: Nachrichtentyp (FileMessageView, ApiMessageView)

    Implementierung: Ausgabeform (WpfRenderer, ConsoleRenderer)

    Du willst beide unabhängig erweitern können, ohne die Klassenhierarchie explodieren zu lassen.
    2. Wenn du Änderungen in der Implementierung vornehmen willst, ohne die Abstraktion zu ändern
    z. B. du ersetzt WpfRenderer durch PdfRenderer, ohne dass MessageView geändert werden muss.

    3. Wenn du verschiedene Plattformen oder Technologien gleichzeitig unterstützen willst
    z. B. eine App, die sowohl auf Desktop (WPF) als auch in einer Konsole läuft – du kannst einfach den passenden Renderer verwenden.
    
    4. Wenn du Unit-Tests für die Abstraktion unabhängig von der konkreten Implementierung schreiben willst
    z. B. ein Mock-Renderer im Test, ohne dass du echte UI brauchst.

    Vorteile:

    - Saubere Trennung von Verantwortlichkeiten
    - Erweiterbarkeit ohne Modifikationen bestehender Klassen (Open/Closed Principle)
    - Bessere Testbarkeit
    - Reduzierung der Vererbungskomplexität

    Wann nicht verwenden?

    - Wenn du nur eine einfache, flache Beziehung hast
    - Wenn die Anzahl möglicher Kombinationen sehr gering und stabil ist
    - Wenn die Implementierung eng mit der Abstraktion verbunden bleiben muss
     */

    public class MainViewModel : BaseViewModel
    {
        private string _title;
        private string _content;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Content
        {
            get => _content;
            set { _content = value; OnPropertyChanged(); }
        }

        private void RenderMessage(Message message)
        {
            Title = message.Title;
            Content = message.Content;
        }

        public MainViewModel()
        {
            // Bridge: View <--> Renderer
            var renderer = new WpfRenderer(RenderMessage);

            // Wähle dynamisch die View
            MessageView view = new FileMessageView(renderer);
            // API Message
            //MessageView view = new ApiMessageView(renderer);

            view.Display();
        }

       
    }
}
