using BeispielMediatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeispielMediatorPattern.Model
{
    public class ViewModel3
    {
        private readonly IMediator _mediator;

        public ViewModel3(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SwitchToView1()
        {
            _mediator.SwitchView("View1");
        }

        public void SwitchToView2()
        {
            _mediator.SwitchView("View2");
        }
    }
}
