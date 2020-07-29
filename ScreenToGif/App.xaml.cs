using ScreenToGif.Utils;
using ScreenToGif.ViewModel;
using System.Windows;

namespace ScreenToGif
{
    public partial class App : Application
    {
        #region 属性
        internal static ApplicationViewModel MainViewModel { get; set; }
        #endregion

        #region 事件
        void App_Startup(object sender, StartupEventArgs e)
        {
            #region ViewModel
            MainViewModel = (ApplicationViewModel)FindResource("AppViewModel") ?? new ApplicationViewModel();
            #endregion

            LocalizationHelper.SelectCulture("");

            #region Startup
            MainViewModel.OpenRecorder.Execute(null);
            #endregion
        }
        #endregion
    }
}
