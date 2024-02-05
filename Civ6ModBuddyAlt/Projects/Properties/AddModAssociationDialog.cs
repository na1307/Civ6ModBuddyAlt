using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

public partial class AddModAssociationDialog : Form {
    public AddModAssociationDialog() => InitializeComponent();

    public ModAssociation Value => new() {
        Type = "Mod",
        Name = modNameTextBox.Text,
        Id = modIdTextBox.Text,
        MinVersion = fromVersionUpDown.Value.ToString(),
        MaxVersion = toVersionUpDown.Value.ToString()
    };

    private void button3_Click(object sender, EventArgs e) => openFileDialog1.ShowDialog();

    private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
        using StreamReader reader = new(openFileDialog1.FileName);
        var s = reader.ReadToEnd();

        modIdTextBox.Text = Regex.Match(s, "<Mod id=\"(?<id>.+)\" version=\"[0-9|.]+\">").Groups["id"].Value;
        modNameTextBox.Text = Regex.Match(s, "<Name>(?<name>.+)</Name>.").Groups["name"].Value;
    }
}
