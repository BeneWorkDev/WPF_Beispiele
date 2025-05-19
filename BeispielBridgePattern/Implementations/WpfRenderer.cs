using BeispielBridgePattern.Interfaces;
using BeispielBridgePattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielBridgePattern.Implementations
{
    public class WpfRenderer : IMessageRenderer
    {
        private Action<Message> renderToUI;

        public WpfRenderer(Action<Message> renderToUI)
        {
            this.renderToUI = renderToUI;
        }

        public void Render(Message message)
        {
            renderToUI?.Invoke(message);
        }
    }
}
