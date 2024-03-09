using System.ComponentModel;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Wizards;

public interface IModWizardPage : INotifyPropertyChanged {
    string Title { get; }
    string Description { get; }
    UserControl Panel { get; }
    bool CanGoNext { get; }
    bool CanGoBack { get; }
}