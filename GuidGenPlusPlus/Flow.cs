using System.Windows;

namespace GuidGenPlusPlus;

internal static class Flow
{
    /// <summary>
    /// Defaults to light theme.
    /// </summary>
    public static bool IsDark { get; set; } = false;

    public static void ChangeUITheme(Uri xamlUri)
    {
        var dictionary = new ResourceDictionary { Source = xamlUri };
        App.Current.Resources.Clear();
        App.Current.Resources.MergedDictionaries.Add(dictionary);
    }

    public static readonly Uri Light = new("pack://application:,,,/GuidGenPlusPlus;component/Themes140/Light.xaml");
    public static readonly Uri Dark = new("pack://application:,,,/GuidGenPlusPlus;component/Themes140/Dark.xaml");

    public static void ToggleDisplayTheme()
    {
        IsDark = !IsDark;
        if (IsDark)
        {
            ChangeUITheme(Dark);
        }
        else
        {
            ChangeUITheme(Light);
        }
    }
}
