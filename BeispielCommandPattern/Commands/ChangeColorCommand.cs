using BeispielCommandPattern.BasicClasses;
using System;

namespace BeispielCommandPattern.Commands
{
    public class ChangeColorCommand : CommandBase
    {
        public ChangeColorCommand(Action execute) : base(execute)
        {
        }
    }
}
