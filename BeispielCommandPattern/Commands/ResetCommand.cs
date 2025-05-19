using BeispielCommandPattern.BasicClasses;
using System;

namespace BeispielCommandPattern.Commands
{
    public class ResetCommand : CommandBase
    {
        public ResetCommand(Action execute) : base(execute)
        {
        }
    }
}
