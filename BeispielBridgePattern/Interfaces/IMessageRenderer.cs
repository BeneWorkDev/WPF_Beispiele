using BeispielBridgePattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielBridgePattern.Interfaces
{
    public interface IMessageRenderer
    {
        void Render(Message message);
    }
}
