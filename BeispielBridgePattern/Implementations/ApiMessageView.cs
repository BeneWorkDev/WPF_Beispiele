using BeispielBridgePattern.Abstraction;
using BeispielBridgePattern.Interfaces;
using BeispielBridgePattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielBridgePattern.Implementations
{
    public class ApiMessageView : MessageView
    {
        public ApiMessageView(IMessageRenderer renderer) : base(renderer) { }

        public override void Display()
        {
            // Simuliere API-Abruf
            var message = new Message
            {
                Title = "API-Nachricht",
                Content = "Dies ist eine Nachricht von einer Web-API."
            };
            renderer.Render(message);
        }
    }
}
