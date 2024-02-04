using Microsoft.VisualStudio.Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Civ6ModBuddyAlt.Projects.Properties;

/// <summary>
/// FileSelector.xaml에 대한 상호 작용 논리
/// </summary>
public partial class FileSelector : Window {
    public FileSelector(Civ6ProjectNode projectMgr, List<string> extensions) {
        InitializeComponent();
        List<string> list = new(EnumerateFileNameSuggestions(projectMgr, extensions)) {
            "(Mod Art Dependency File)"
        };
        comboFiles.ItemsSource = list;
    }

    public string File => comboFiles.SelectedItem as string;

    public int Priority {
        get {
            int? value = priority.Value;

            if (value == null) {
                return 0;
            }

            return value.GetValueOrDefault();
        }
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

    private string[] EnumerateFileNameSuggestions(HierarchyNode parent, List<string> extensions) {
        Uri uri = new Uri(parent.ProjectManager.ProjectFolder + Path.DirectorySeparatorChar);
        List<string> list = [];

        for (HierarchyNode hierarchyNode = parent.FirstChild; hierarchyNode != null; hierarchyNode = hierarchyNode.NextSibling) {
            list.AddRange(EnumerateFileNameSuggestions(hierarchyNode, extensions));

            if (hierarchyNode is FileNode fileNode) {
                if (extensions != null) {
                    string extension = Path.GetExtension(fileNode.FileName);

                    if (extension != null && extensions.Contains(extension.ToLower())) {
                        Uri uri2 = new Uri(fileNode.Url);

                        string text2 = uri.MakeRelativeUri(uri2).ToString();

                        list.Add(Uri.UnescapeDataString(text2));
                    }
                } else {
                    Uri uri3 = new Uri(fileNode.Url);

                    string text3 = uri.MakeRelativeUri(uri3).ToString();

                    list.Add(Uri.UnescapeDataString(text3));
                }
            }
        }

        return [.. list];
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
