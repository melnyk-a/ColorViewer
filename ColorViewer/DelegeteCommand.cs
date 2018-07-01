using System;

namespace ColorViewer
{
    internal sealed class DelegeteCommand : Command
    {
        private readonly Func<bool> canExecuteMethod;
        private readonly Action executeMethod;

        public DelegeteCommand(Action executeMethod) :
            this(executeMethod, () => true)
        {
        }

        public DelegeteCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.canExecuteMethod = canExecuteMethod;
            this.executeMethod = executeMethod;
        }

        public override bool CanExecute()
        {
            return canExecuteMethod();
        }

        public override void Execute()
        {
            executeMethod();
        }
    }
}