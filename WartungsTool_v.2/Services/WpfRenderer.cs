using System;
using WartungsTool_v._2.Interfaces;
using WartungsTool_v._2.Model;

namespace WartungsTool_v._2.Services
{
    public class WpfRenderer : IMessageRenderer
    {
        public Action<Message> OutputAction;

        public WpfRenderer(Action<Message> outputAction)
        {
            OutputAction = outputAction;
        }

        public void Render(Message message)
        {
            OutputAction?.Invoke(message);
        }
    }
}
