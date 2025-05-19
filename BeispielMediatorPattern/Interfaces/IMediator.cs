using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielMediatorPattern.Interfaces
{
    public interface IMediator
    {
        void RegisterView(string key, IView view);
        void SwitchView(string key);
    }
}
