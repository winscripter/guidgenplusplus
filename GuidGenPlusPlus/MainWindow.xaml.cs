using System.Windows;

namespace GuidGenPlusPlus;

/// <summary>
/// Application starts here.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        GuidTypes.PrepareShared();
        this.mainView.guidTypesView.ItemsSource = GuidTypes.Shared;
    }
}