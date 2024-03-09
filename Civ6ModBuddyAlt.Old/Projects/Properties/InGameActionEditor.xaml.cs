using System.Windows;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Projects.Properties;

/// <summary>
/// InGameActionEditor.xaml에 대한 상호 작용 논리
/// </summary>
public partial class InGameActionEditor : UserControl {
    public InGameActionEditor() {
        InitializeComponent();
    }

    private void buttonAddFile_Click(object sender, RoutedEventArgs e) {
        if (DataContext is InGameAction inGameAction) {
            FileSelector fileSelector = new(Civ6ProjectNode.Instance, null);

            if (fileSelector.ShowDialog() == true) {
                inGameAction.Files.Add(new ActionFile {
                    File = fileSelector.File,
                    Priority = fileSelector.Priority
                });
            }
        }
    }

    private void buttonRemoveFile_Click(object sender, RoutedEventArgs e) {
        if (DataContext is InGameAction inGameAction && listFiles.SelectedIndex != -1) {
            inGameAction.Files.RemoveAt(listFiles.SelectedIndex);
        }
    }

    private void buttonAddProperty_Click(object sender, RoutedEventArgs e) {
        if (DataContext is InGameAction inGameAction) {
            BasicProperty basicProperty = new BasicProperty();

            if (new PropertyEditor(basicProperty).ShowDialog() == true) {
                inGameAction.Properties.Add(basicProperty);
            }
        }
    }

    private void buttonRemoveProperty_Click(object sender, RoutedEventArgs e) {
        if (DataContext is InGameAction inGameAction && listProperties.SelectedIndex != -1) {
            inGameAction.Properties.RemoveAt(listProperties.SelectedIndex);
        }
    }

    private void buttonAddCriteria_Click(object sender, RoutedEventArgs e) {
        MessageBox.Show("Sorry. This feature is currently unavailable.", "Sorry", MessageBoxButton.OK, MessageBoxImage.Information);

        //InGameAction inGameAction = base.DataContext as InGameAction;
        //if (inGameAction != null) {
        //    ChangeActionCriteria changeActionCriteria = new ChangeActionCriteria(inGameAction, string.Empty);
        //    if (changeActionCriteria.ShowDialog() == true && changeActionCriteria.SelectedCriteria != null) {
        //        inGameAction.Criteria.Add(changeActionCriteria.SelectedCriteria.Id);
        //    }
        //}
    }

    private void buttonRemoveCriteria_Click(object sender, RoutedEventArgs e) {
        if (DataContext is InGameAction inGameAction && listCriteria.SelectedIndex != -1) {
            inGameAction.Criteria.RemoveAt(listCriteria.SelectedIndex);
        }
    }

    private void buttonAddReference_Click(object sender, RoutedEventArgs e) {
        MessageBox.Show("Sorry. This feature is currently unavailable.", "Sorry", MessageBoxButton.OK, MessageBoxImage.Information);

        //if (DataContext is InGameAction inGameAction) {
        //    ActionReference actionReference = new ActionReference();
        //    if (new ActionReferenceEditorDialog(inGameAction, actionReference).ShowDialog() == true) {
        //        inGameAction.References.Add(actionReference);
        //    }
        //}
    }

    private void buttonEditReference_Click(object sender, RoutedEventArgs e) {
        MessageBox.Show("Sorry. This feature is currently unavailable.", "Sorry", MessageBoxButton.OK, MessageBoxImage.Information);

        //InGameAction inGameAction = base.DataContext as InGameAction;
        //if (inGameAction != null && listReferences.SelectedIndex != -1) {
        //    ActionReference actionReference = inGameAction.References[listReferences.SelectedIndex];
        //    if (actionReference != null) {
        //        ActionReferenceEditorDialog actionReferenceEditorDialog = new ActionReferenceEditorDialog(inGameAction, actionReference);
        //        actionReferenceEditorDialog.ShowDialog();
        //    }
        //}
    }

    private void buttonRemoveReference_Click(object sender, RoutedEventArgs e) {
        if (DataContext is InGameAction inGameAction && listReferences.SelectedIndex != -1) {
            inGameAction.References.RemoveAt(listReferences.SelectedIndex);
        }
    }
}
