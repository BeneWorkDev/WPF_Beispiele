using BeispielBridgePatterMvvm.Interfaces;

namespace BeispielBridgePatterMvvm.Services
{
    public abstract class MessageView
    {
        protected readonly IMessageRenderer Renderer;

        protected MessageView(IMessageRenderer renderer)
        {
            Renderer = renderer;
        }

        public abstract void Display();
    }
}
