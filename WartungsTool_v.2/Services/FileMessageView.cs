using WartungsTool_v._2.Abstraction;
using WartungsTool_v._2.Interfaces;
using WartungsTool_v._2.Model;

namespace WartungsTool_v._2.Services
{
    public class FileMessageView : MessageView
    {
        public FileMessageView(IMessageRenderer renderer) : base(renderer) { }
        public override void Display(string content)
        {
            Renderer.Render(new Message { Text = $"File: {content}" });
        }
    }
}
