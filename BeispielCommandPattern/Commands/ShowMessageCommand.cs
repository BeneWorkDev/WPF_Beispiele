using BeispielCommandPattern.BasicClasses;
using System;

namespace BeispielCommandPattern.Commands
{
    public class ShowMessageCommand : CommandBase
    {
        public ShowMessageCommand(Action execute) : base(execute)
        {
        }
    }
}
