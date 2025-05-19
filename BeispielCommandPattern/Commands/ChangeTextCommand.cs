using BeispielCommandPattern.BasicClasses;
using System;

namespace BeispielCommandPattern.Commands
{
    public class ChangeTextCommand : CommandBase
    {
        public ChangeTextCommand(Action execute) : base(execute)
        {
        }
    }
}
