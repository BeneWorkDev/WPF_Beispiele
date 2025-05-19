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
    public class FileMessageView : MessageView
    {
        public FileMessageView(IMessageRenderer renderer) : base(renderer) { }

        public override void Display()
        {
            // Simuliere Lesevorgang
            var message = new Message
            {
                Title = "Dateinachricht",
                Content = "Dies ist eine Nachricht aus einer Datei."
            };
            renderer.Render(message);
        }
    }
}
