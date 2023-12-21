using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

public partial class addModAssociationDialog : Form {
    public addModAssociationDialog() {
        InitializeComponent();
        modsComboBox.Items.Add("(Browse)");
    }

    public ModAssociation Value => new() {
        Type = "Mod",
        Name = modNameTextBox.Text,
        Id = modIdTextBox.Text,
        MinVersion = fromVersionUpDown.Value.ToString(),
        MaxVersion = toVersionUpDown.Value.ToString()
    };
}
