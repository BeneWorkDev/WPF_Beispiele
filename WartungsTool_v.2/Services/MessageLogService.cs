using WartungsTool_v._2.Abstraction;
using WartungsTool_v._2.Interfaces;

namespace WartungsTool_v._2.Services
{
    public class MessageLogService : ILogService
    {
        private readonly MessageView _view;

        public MessageLogService(MessageView view)
        {
            _view = view;
        }

        public void Log(string message)
        {
            _view.Display(message);
        }
    }
}
