using System;
using System.Windows.Input;

namespace ColorViewer
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute();

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public abstract void Execute();

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        public void RaiseCanExevuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}