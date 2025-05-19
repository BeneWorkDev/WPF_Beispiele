using WartungsTool_v._2.Interfaces;

namespace WartungsTool_v._2.Abstraction
{
    public abstract class MessageView
    {
        protected IMessageRenderer Renderer;
        protected MessageView(IMessageRenderer renderer) => Renderer = renderer;
        public abstract void Display(string content);
    }
}
