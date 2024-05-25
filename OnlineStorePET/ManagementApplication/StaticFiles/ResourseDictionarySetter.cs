using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.StaticFiles
{
    public static class ResourseDictionarySetter
    {
        public static void SetDictionaries(FrameworkElement window)
        {
            var colorsDict = new ResourceDictionary
            {
                Source = new Uri(@"pack://application:,,,/Themes/Colors.xaml")
            };
            var customStylesDict = new ResourceDictionary
            {
                Source = new Uri(@"pack://application:,,,/Themes/CustomStyles.xaml")
            };
            var MahControlsDict = new ResourceDictionary
            {
                Source = new Uri(@"pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml")
            };
            var MahStylesDict = new ResourceDictionary
            {
                Source = new Uri(@"pack://application:,,,/MahApps.Metro;component/Styles/Themes/Light.Blue.xaml")
            };
            var MahFontsDict = new ResourceDictionary
            {
                Source = new Uri(@"pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml")
            };

            window.Resources.MergedDictionaries.Add(colorsDict);
            window.Resources.MergedDictionaries.Add(customStylesDict);
            window.Resources.MergedDictionaries.Add(MahControlsDict);
            window.Resources.MergedDictionaries.Add(MahStylesDict);
            window.Resources.MergedDictionaries.Add(MahFontsDict);
        }
    }
}
