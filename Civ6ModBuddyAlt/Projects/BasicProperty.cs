using System.ComponentModel;

namespace Civ6ModBuddyAlt.Projects;

public class BasicProperty : INotifyPropertyChanged {
    private string _name;
    private string _value;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Name {
        get => _name;
        set {
            if (_name != value) {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
    }

    public string Value {
        get => _value;
        set {
            if (_value != value) {
                _value = value;
                NotifyPropertyChanged("Value");
            }
        }
    }

    private void NotifyPropertyChanged(string info) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
}
