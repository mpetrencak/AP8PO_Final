using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AP8PO_Final.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;
        public event Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if(_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if(_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }

        }


        public RelayCommand(Action<object> action,Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void OnCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }


        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute();
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}
