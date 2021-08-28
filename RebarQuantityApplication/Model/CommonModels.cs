using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace RebarQuantityApplication
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

            //= (sender, e) => { };
        }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteEvaluator == null)
            { return true; }
            else
            {
                bool result = this.CanExecuteEvaluator.Invoke(parameter);
                return result;
            }
        }

        public void Execute(object parameter)
        {
            //this.MethodToExecute.Invoke(parameter);
            mAction();
        }

        private Action<object> MethodToExecute;
        private Func<object, bool> CanExecuteEvaluator;

        public RelayCommand(Action<object> ActualMethodToExecute, Func<object, bool> ActualCanExecuteEvaluator)
        {
            MethodToExecute = ActualMethodToExecute;
            CanExecuteEvaluator = ActualCanExecuteEvaluator;
        }

        public RelayCommand(Action<object> ActualMethodToExecute)
        {
            new RelayCommand(ActualMethodToExecute, null);
        }
        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion
    }
}
