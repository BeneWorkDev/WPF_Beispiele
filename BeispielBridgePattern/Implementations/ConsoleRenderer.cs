using BeispielBridgePattern.Interfaces;
using BeispielBridgePattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielBridgePattern.Implementations
{
    public class ConsoleRenderer : IMessageRenderer
    {
        public void Render(Message message)
        {
            Console.WriteLine($"--- {message.Title} ---");
            Console.WriteLine(message.Content);
        }
    }
}
