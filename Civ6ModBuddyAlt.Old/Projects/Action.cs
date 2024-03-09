using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Civ6ModBuddyAlt.Projects;

public abstract class Action : INotifyPropertyChanged {
    private string _Type = "UpdateDatabase";
    private string _Id = "NewAction";

    public event PropertyChangedEventHandler? PropertyChanged;

    protected Action() {
        Properties.CollectionChanged += Properties_CollectionChanged;
        Properties.CollectionItemChanged += Properties_CollectionItemChanged;
        Files.CollectionChanged += Files_CollectionChanged;
        Files.CollectionItemChanged += Files_CollectionItemChanged;
    }

    public string Type {
        get => _Type;
        set => SetField(ref _Type, value);
    }

    public string Id {
        get => _Id;
        set => SetField(ref _Id, value);
    }

    public Collection<BasicProperty> Properties { get; } = [];
    public Collection<ActionFile> Files { get; } = [];

    protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value)) {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName!);

        return true;
    }

    private void Files_CollectionItemChanged(object sender, EventArgs e) => OnPropertyChanged(nameof(Files));
    private void Files_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(Files));
    private void Properties_CollectionItemChanged(object sender, EventArgs e) => OnPropertyChanged(nameof(Properties));
    private void Properties_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(Properties));
}
