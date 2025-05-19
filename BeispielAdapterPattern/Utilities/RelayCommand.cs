using BeispielAdapterPattern.BaseClasses;
using System;

namespace BeispielAdapterPattern.Utilities
{
    public class RelayCommand : CommandBase
    {
        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : base(execute, canExecute)
        {
        }
    }
}
