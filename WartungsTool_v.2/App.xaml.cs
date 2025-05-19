using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WartungsTool_v._2
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
    }

    public static class ThemeManager
    {
        public static void ApplyTheme(bool isDark)
        {
            string themePath = isDark ? "/Themes/NightTheme.xaml" : "/Themes/DayTheme.xaml";
            var dict = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
