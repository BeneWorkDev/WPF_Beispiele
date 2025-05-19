using BeispielCommandPattern.BasicClasses;
using System;

namespace BeispielCommandPattern.Commands
{
    public class ToggleVisibilityCommand : CommandBase
    {
        public ToggleVisibilityCommand(Action execute) : base(execute)
        {
        }
    }
}
