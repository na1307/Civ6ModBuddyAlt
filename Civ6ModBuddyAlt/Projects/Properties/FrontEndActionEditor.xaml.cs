using System.Windows;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Projects.Properties;

/// <summary>
/// FrontEndActionEditor.xaml에 대한 상호 작용 논리
/// </summary>
public partial class FrontEndActionEditor : UserControl {
    public FrontEndActionEditor() {
        InitializeComponent();
    }

    private void buttonAddFile_Click(object sender, RoutedEventArgs e) {
        if (DataContext is FrontEndAction frontEndAction) {
            FileSelector fileSelector = new(Civ6ProjectNode.Instance, null);

            if (fileSelector.ShowDialog() == true) {
                frontEndAction.Files.Add(new() {
                    File = fileSelector.File,
                    Priority = fileSelector.Priority
                });
            }
        }
    }

    private void buttonRemoveFile_Click(object sender, RoutedEventArgs e) {
        if (DataContext is FrontEndAction frontEndAction && listFiles.SelectedIndex != -1) {
            frontEndAction.Files.RemoveAt(listFiles.SelectedIndex);
        }
    }

    private void buttonAddProperty_Click(object sender, RoutedEventArgs e) {
        if (DataContext is FrontEndAction frontEndAction) {
            BasicProperty basicProperty = new BasicProperty();

            if (new PropertyEditor(basicProperty).ShowDialog() == true) {
                frontEndAction.Properties.Add(basicProperty);
            }
        }
    }

    private void buttonRemoveProperty_Click(object sender, RoutedEventArgs e) {
        if (DataContext is FrontEndAction frontEndAction && listProperties.SelectedIndex != -1) {
            frontEndAction.Properties.RemoveAt(listProperties.SelectedIndex);
        }
    }
}
