using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace ScreenToGif.Utils
{
    static class LocalizationHelper
    {
        public static void SelectCulture(string culture)
        {
            #region 验证
            if (string.IsNullOrEmpty(culture))
            {
                culture = "zh";
            }

            if(culture == "auto")
            {
                culture = CultureInfo.InstalledUICulture.Name;
            }
            #endregion

            #region 临时变量
            var dictionary = Application.Current.Resources.MergedDictionaries;
            var dictionaryList = dictionary.ToList();
            #endregion

            #region 选择
            var requestedResource = GetResourceDictionaryByCulture(culture, dictionaryList);
            #endregion

            #region 通用分支回退
            while(requestedResource == null && !string.IsNullOrEmpty(culture))
            {
                culture = CultureInfo.GetCultureInfo(culture).Parent.Name;
                requestedResource = GetResourceDictionaryByCulture(culture, dictionaryList);
            }
            #endregion

            #region 默认使用中文
            if(requestedResource == null)
            {
                culture = "zh";
                requestedResource = GetResourceDictionaryByCulture(culture, dictionaryList);
            }
            #endregion

            // 通过将资源放到最后来实现切换
            dictionary.Remove(requestedResource);
            dictionary.Add(requestedResource);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        static ResourceDictionary GetResourceDictionaryByCulture(string culture, List<ResourceDictionary> list)
        {
            var requestedCulture = $"/Resources/Localization/StringResources.{culture}.xaml";
            return list.FirstOrDefault(r => r.Source?.OriginalString == requestedCulture);
        }
    }
}
