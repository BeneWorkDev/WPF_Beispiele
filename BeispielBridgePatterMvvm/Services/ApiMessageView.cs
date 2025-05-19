using BeispielBridgePatterMvvm.Interfaces;
using BeispielBridgePatterMvvm.Model;

namespace BeispielBridgePatterMvvm.Services
{
    public class ApiMessageView : MessageView
    {
        public ApiMessageView(IMessageRenderer renderer) : base(renderer) { }

        public override void Display()
        {
            var message = new Message
            {
                Title = "API-Nachricht",
                Content = "Dies ist eine Nachricht von einer Web-API."
            };
            Renderer.Render(message);
        }
    }
}
