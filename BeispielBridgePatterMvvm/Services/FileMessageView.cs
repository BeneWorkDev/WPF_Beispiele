using BeispielBridgePatterMvvm.Interfaces;
using BeispielBridgePatterMvvm.Model;

namespace BeispielBridgePatterMvvm.Services
{
    public class FileMessageView : MessageView
    {
        public FileMessageView(IMessageRenderer renderer) : base(renderer) { }

        public override void Display()
        {
            var message = new Message
            {
                Title = "Dateinachricht",
                Content = "Dies ist eine Nachricht aus einer Datei."
            };
            Renderer.Render(message);
        }
    }
}
