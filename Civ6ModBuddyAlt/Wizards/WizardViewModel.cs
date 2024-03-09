using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Civ6ModBuddyAlt.Wizards;

public sealed class WizardViewModel : INotifyPropertyChanged {
    private string modTitle;
    private string modAuthors;
    private string modSpecialThanks;
    private string modDescription;

    public event PropertyChangedEventHandler PropertyChanged;

    public string ModTitle {
        get => modTitle;
        set => setProperty(ref modTitle, value);
    }

    public string ModAuthors {
        get => modAuthors;
        set => setProperty(ref modAuthors, value);
    }

    public string ModSpecialThanks {
        get => modSpecialThanks;
        set => setProperty(ref modSpecialThanks, value);
    }

    public string ModDescription {
        get => modDescription;
        set => setProperty(ref modDescription, value);
    }

    private bool setProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) {
        if (!Equals(field, newValue)) {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        return false;
    }
}
