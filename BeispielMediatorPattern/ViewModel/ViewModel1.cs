using BeispielMediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielMediatorPattern.Model
{
    public class ViewModel1
    {
        private readonly IMediator _mediator;

        public ViewModel1(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SwitchToView2()
        {
            _mediator.SwitchView("View2");
        }

        public void SwitchToView3()
        {
            _mediator.SwitchView("View3");
        }
    }
}
