using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Projects.Properties;

/// <summary>
/// FrontEndActionUserControl.xaml에 대한 상호 작용 논리
/// </summary>
public partial class FrontEndActionUserControl : UserControl, INotifyPropertyChanged {
    private readonly FrontEndActions _actions;
    private FrontEndAction _SelectedAction;

    public event EventHandler ActionsUpdated;
    public event PropertyChangedEventHandler PropertyChanged;

    public FrontEndActionUserControl(Civ6ProjectNode projectMgr) {
        InitializeComponent();
        _actions = new FrontEndActions(projectMgr);
        _actions.CollectionChanged += Actions_CollectionChanged;
        _actions.CollectionItemChanged += Actions_CollectionItemChanged;
        DataContext = this;
    }

    public FrontEndActions Actions => _actions;

    public FrontEndAction SelectedAction {
        get => _SelectedAction;
        set {
            if (_SelectedAction != value) {
                _SelectedAction = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedAction"));
            }
        }
    }

    private void Actions_CollectionItemChanged(object sender, PropertyChangedEventArgs e) {
        ActionsUpdated?.Invoke(this, EventArgs.Empty);
    }

    private void Actions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
        ActionsUpdated?.Invoke(this, EventArgs.Empty);
    }

    private void buttonAddAction_Click(object sender, RoutedEventArgs e) {
        Actions.Add(new FrontEndAction());
    }

    private void buttonRemoveAction_Click(object sender, RoutedEventArgs e) {
        if (listActions.SelectedIndex != -1) {
            Actions.RemoveAt(listActions.SelectedIndex);
        }
    }
}
