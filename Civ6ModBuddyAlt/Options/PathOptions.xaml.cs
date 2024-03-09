using Ookii.Dialogs.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Options;

/// <summary>
/// PathOptions.xaml에 대한 상호 작용 논리
/// </summary>
public partial class PathOptions : UserControl {
    private static readonly VistaFolderBrowserDialog dialog = new() {
        Multiselect = false,
        ShowNewFolderButton = false,
    };

    public PathOptions(PathOptionPage pathOptionPage) {
        InitializeComponent();
        DataContext = pathOptionPage;
    }

    private void UserPathButton_Click(object sender, RoutedEventArgs e) {
        dialog.SelectedPath = UserPathBox.Text;

        if (dialog.ShowDialog().GetValueOrDefault()) {
            UserPathBox.Text = dialog.SelectedPath;
        }
    }

    private void GamePathButton_Click(object sender, RoutedEventArgs e) {
        dialog.SelectedPath = GamePathBox.Text;

        if (dialog.ShowDialog().GetValueOrDefault()) {
            GamePathBox.Text = dialog.SelectedPath;
        }
    }

    private void ToolsPathButton_Click(object sender, RoutedEventArgs e) {
        dialog.SelectedPath = ToolsPathBox.Text;

        if (dialog.ShowDialog().GetValueOrDefault()) {
            ToolsPathBox.Text = dialog.SelectedPath;
        }
    }

    private void AssetsPathButton_Click(object sender, RoutedEventArgs e) {
        dialog.SelectedPath = AssetsPathBox.Text;

        if (dialog.ShowDialog().GetValueOrDefault()) {
            AssetsPathBox.Text = dialog.SelectedPath;
        }
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e) {
        UserPathBox.Text = string.Empty;
        GamePathBox.Text = string.Empty;
        ToolsPathBox.Text = string.Empty;
        AssetsPathBox.Text = string.Empty;
    }
}
