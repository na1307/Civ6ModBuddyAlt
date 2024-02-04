using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Projects.Properties;

/// <summary>
/// InGameActionsUserControl.xaml에 대한 상호 작용 논리
/// </summary>
public partial class InGameActionsUserControl : UserControl, INotifyPropertyChanged {
    private readonly InGameActions _actions;
    private InGameAction _SelectedAction;

    public event EventHandler ActionsUpdated;
    public event PropertyChangedEventHandler PropertyChanged;

    public InGameActionsUserControl(Civ6ProjectNode projectMgr) {
        InitializeComponent();
        _actions = new InGameActions(projectMgr);
        _actions.CollectionChanged += Actions_CollectionChanged;
        _actions.CollectionItemChanged += Actions_CollectionItemChanged;
        DataContext = this;
    }

    private void Actions_CollectionItemChanged(object sender, PropertyChangedEventArgs e) {
        ActionsUpdated?.Invoke(this, EventArgs.Empty);
    }

    private void Actions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
        ActionsUpdated?.Invoke(this, EventArgs.Empty);
    }

    public InGameActions Actions => _actions;

    public InGameAction SelectedAction {
        get => _SelectedAction;
        set {
            if (_SelectedAction != value) {
                _SelectedAction = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedAction"));
            }
        }
    }

    private void buttonAddAction_Click(object sender, RoutedEventArgs e) {
        Actions.Add(new InGameAction());
    }

    private void buttonRemoveAction_Click(object sender, RoutedEventArgs e) {
        if (listActions.SelectedIndex != -1) {
            Actions.RemoveAt(listActions.SelectedIndex);
        }
    }
}
