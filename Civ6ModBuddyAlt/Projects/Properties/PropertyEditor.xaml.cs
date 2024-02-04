using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Civ6ModBuddyAlt.Projects.Properties;

/// <summary>
/// PropertyEditor.xaml에 대한 상호 작용 논리
/// </summary>
public partial class PropertyEditor : Window {
    private BasicProperty _Property;

    public PropertyEditor(BasicProperty property) {
        InitializeComponent();
        _Property = property;
        DataContext = property;
    }

    private void OKButton_Click(object sender, RoutedEventArgs e) {
        if (!IsValid(this)) {
            return;
        }

        foreach (BindingExpressionBase bindingExpressionBase in BindingOperations.GetSourceUpdatingBindings(this)) {
            bindingExpressionBase.UpdateSource();
        }

        DialogResult = new bool?(true);
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) {
        foreach (BindingExpressionBase bindingExpressionBase in BindingOperations.GetSourceUpdatingBindings(this)) {
            bindingExpressionBase.UpdateTarget();
        }

        DialogResult = new bool?(false);
    }

    private bool IsValid(DependencyObject node) {
        if (node != null && Validation.GetHasError(node)) {
            if (node is IInputElement element) {
                Keyboard.Focus(element);
            }

            return false;
        }

        foreach (object obj in LogicalTreeHelper.GetChildren(node)) {
            if (obj is DependencyObject @object && !IsValid(@object)) {
                return false;
            }
        }

        return true;
    }
}
