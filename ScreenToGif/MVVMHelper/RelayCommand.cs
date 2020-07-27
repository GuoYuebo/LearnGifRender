using System;
using System.Windows.Input;

namespace ScreenToGif.MVVMHelper
{
    class RelayCommand : ICommand
    {
        #region ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return CanExecutePredicate == null || CanExecutePredicate.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }
        #endregion

        #region 事件
        public Predicate<object> CanExecutePredicate { get; set; }
        public Action<object> ExecuteAction { get; set; }
        #endregion
    }
}
