﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Civ6ModBuddyAlt.Projects;

public class BasicProperty : INotifyPropertyChanged {
    private string _name = string.Empty;
    private string _value = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name {
        get => _name;
        set {
            if (_name != value) {
                _name = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string Value {
        get => _value;
        set {
            if (_value != value) {
                _value = value;
                NotifyPropertyChanged();
            }
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string? info = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
}
