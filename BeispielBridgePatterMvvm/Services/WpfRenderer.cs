using BeispielBridgePatterMvvm.Interfaces;
using BeispielBridgePatterMvvm.Model;
using System;

namespace BeispielBridgePatterMvvm.Services
{
    public class WpfRenderer : IMessageRenderer
    {
        private readonly Action<Message> _renderAction;

        public WpfRenderer(Action<Message> renderAction)
        {
            _renderAction = renderAction;
        }

        public void Render(Message message)
        {
            _renderAction?.Invoke(message);
        }
    }
}
