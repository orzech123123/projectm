using System;
using System.Windows.Input;

namespace Macrix.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
            : this()
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public DelegateCommand()
        {

        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
