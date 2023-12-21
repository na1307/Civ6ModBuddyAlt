using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Civ6ModBuddyAlt.Projects;

public class ActionReference : INotifyPropertyChanged {
    private string _ModId;
    private string _ActionId;
    private string _Type;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value)) {
            return false;
        }

        field = value;

        OnPropertyChanged(propertyName);

        return true;
    }

    public string ModId {
        get => _ModId;
        set => SetField(ref _ModId, value, "ModId");
    }

    public string ActionId {
        get => _ActionId;
        set => SetField(ref _ActionId, value, "ActionId");
    }

    public string Type {
        get => _Type;
        set => SetField(ref _Type, value, "Type");
    }
}
