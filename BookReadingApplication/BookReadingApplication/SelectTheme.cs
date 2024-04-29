using System;
using System.Windows;

namespace BookReadingApplication;

public class SelectTheme
{
    public static void ChangeTheme(Uri themeUri)
    {
        ResourceDictionary theme = new()
        {
            Source = themeUri
        };

        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(theme);
    }
}
