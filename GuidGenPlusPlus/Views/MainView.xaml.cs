using GuidGenPlusPlus.Models;
using System.Windows;
using System.Windows.Controls;

namespace GuidGenPlusPlus.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void Generate(object sender, RoutedEventArgs e)
    {
        if (guidTypesView.SelectedItem is null)
        {
            DisplaySelectGuidFirstError();
            return;
        }
        if (guidTypesView.SelectedItem is not GuidTypeModel result)
        {
            DisplaySelectGuidFirstError();
            return;
        }
        resultBox.Text = GuidGenerator.Generate(result.Type);
    }

    public void OnToggleTheme(object sender, RoutedEventArgs e)
    {
        Flow.ToggleDisplayTheme();
    }

    private static void DisplaySelectGuidFirstError()
    {
        MessageBox.Show(
            "Please select a GUID type first. Click on one of GUID types (for example, Text Only) and then click Generate again.",
            "GuidGen++",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
    }
}
