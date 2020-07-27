using ScreenToGif.Model;
using ScreenToGif.MVVMHelper;
using ScreenToGif.View;
using System.Windows;
using System.Windows.Input;

namespace ScreenToGif.ViewModel
{
    class ApplicationViewModel : ApplicationModel
    {
        #region Commands
        public ICommand OpenRecorder
        {
            get
            {
                return new RelayCommand
                {
                    ExecuteAction = o =>
                    {
                        var recorder = new Recorder();
                        Application.Current.MainWindow = recorder;
                        recorder.Show();
                    }
                };
            }
        }
        #endregion
    }
}
