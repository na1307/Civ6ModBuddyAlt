using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Civ6ModBuddyAlt.Projects;

public class ActionFile : INotifyPropertyChanged {
    private string _File;
    private int _Priority;

    public event PropertyChangedEventHandler PropertyChanged;

    public string File {
        get => _File;
        set => SetField(ref _File, value);
    }

    public int Priority {
        get => _Priority;
        set => SetField(ref _Priority, value);
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value)) {
            return false;
        }

        field = value;

        OnPropertyChanged(propertyName);

        return true;
    }

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
