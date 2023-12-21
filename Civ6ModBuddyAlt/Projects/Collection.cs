using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Civ6ModBuddyAlt.Projects;

public class Collection<T> : ObservableCollection<T> {
    public event EventHandler<PropertyChangedEventArgs> CollectionItemChanged;

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
        switch (e.Action) {
            case NotifyCollectionChangedAction.Add:
                AddPropertyChanged(e.NewItems);
                break;

            case NotifyCollectionChangedAction.Remove:
                RemovePropertyChanged(e.OldItems);
                break;

            case NotifyCollectionChangedAction.Replace:
            case NotifyCollectionChangedAction.Reset:
                RemovePropertyChanged(e.OldItems);
                AddPropertyChanged(e.NewItems);
                break;
        }

        base.OnCollectionChanged(e);
    }

    private void AddPropertyChanged(IEnumerable items) {
        if (items != null) {
            foreach (INotifyPropertyChanged notifyPropertyChanged in items.OfType<INotifyPropertyChanged>()) {
                notifyPropertyChanged.PropertyChanged += OnItemPropertyChanged;
            }
        }
    }

    private void RemovePropertyChanged(IEnumerable items) {
        if (items != null) {
            foreach (INotifyPropertyChanged notifyPropertyChanged in items.OfType<INotifyPropertyChanged>()) {
                notifyPropertyChanged.PropertyChanged -= OnItemPropertyChanged;
            }
        }
    }

    private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e) {
        CollectionItemChanged?.Invoke(sender, e);
    }
}