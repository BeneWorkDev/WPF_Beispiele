using BeispielBridgePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielBridgePattern.Abstraction
{
    public abstract class MessageView
    {
        protected IMessageRenderer renderer;

        protected MessageView(IMessageRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Display();
    }
}
