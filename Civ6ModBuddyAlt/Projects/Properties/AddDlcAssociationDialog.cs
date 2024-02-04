using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

public partial class AddDlcAssociationDialog : Form {
    private readonly List<DlcPackage> _DlcPackages = [];

    public AddDlcAssociationDialog() => InitializeComponent();

    public ModAssociation Value {
        get {
            return new() {
                Type = "Dlc",
                Name = dlcNameTextBox.Text,
                Id = dlcPackageIdTextBox.Text,
                MinVersion = "0",
                MaxVersion = "999"
            };
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        DlcPackage dlcPackage = _DlcPackages[comboBox1.SelectedIndex];
        dlcNameTextBox.Text = dlcPackage.DisplayName;
        dlcPackageIdTextBox.Text = dlcPackage.ModId;
    }

    private void dlcNameTextBox_TextChanged(object sender, EventArgs e) => okButton.Enabled = !string.IsNullOrWhiteSpace(dlcNameTextBox.Text) && !string.IsNullOrWhiteSpace(dlcPackageIdTextBox.Text);
    private void dlcPakcageIdTextBox_TextChanged(object sender, EventArgs e) => okButton.Enabled = !string.IsNullOrWhiteSpace(dlcNameTextBox.Text) && !string.IsNullOrWhiteSpace(dlcPackageIdTextBox.Text);

    private readonly record struct DlcPackage(string ModId, string NameKey, string DisplayName);
}
