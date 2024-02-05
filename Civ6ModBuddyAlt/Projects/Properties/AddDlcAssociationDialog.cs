using Microsoft.VisualStudio.Threading;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

public partial class AddDlcAssociationDialog : Form {
    private const string dlcsUrl = "https://raw.githubusercontent.com/na1307/Civ6ModBuddyAlt/main/dlcs.json";
    private const string custom = "(Custom)";
    private static readonly DlcPackage[] dlcPackages = initDPs();

    public AddDlcAssociationDialog() {
        InitializeComponent();

        if (dlcPackages.Length > 0) {
            comboBox1.Items.AddRange(dlcPackages.Select(dp => dp.DisplayName).Concat([custom]).ToArray());
        } else {
            comboBox1.Items.Add(custom);
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;
        }
    }

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

    private static DlcPackage[] initDPs() {
        try {
            using JoinableTaskContext context = new();
            JoinableTaskFactory factory = new(context);
            using HttpClient client = new();

            return JsonSerializer.Deserialize<DlcPackage[]>(factory.Run(() => client.GetStreamAsync(dlcsUrl)));
        } catch (HttpRequestException) {
            // Not Avaliable
        }

        return [];
    }

    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e) {
        try {
            DlcPackage dlcPackage = dlcPackages[comboBox1.SelectedIndex];
            dlcNameTextBox.Text = dlcPackage.DisplayName;
            dlcPackageIdTextBox.Text = dlcPackage.ModId;
        } catch (IndexOutOfRangeException) when (comboBox1.SelectedIndex == comboBox1.Items.Count - 1) {
            dlcNameTextBox.Text = string.Empty;
            dlcPackageIdTextBox.Text = string.Empty;
        }
    }

    private void dlcTextBox_TextChanged(object sender, EventArgs e) {
        okButton.Enabled = !string.IsNullOrWhiteSpace(dlcNameTextBox.Text) && !string.IsNullOrWhiteSpace(dlcPackageIdTextBox.Text);

        if (((TextBox)sender).Modified) {
            comboBox1.Text = custom;
        }
    }

    private void okButton_Click(object sender, EventArgs e) {
        if (Guid.TryParseExact(dlcPackageIdTextBox.Text, "D", out _)) {
            DialogResult = DialogResult.OK;
        } else {
            MessageBox.Show("The Id does not fit the format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private readonly record struct DlcPackage([property: JsonPropertyName("id")] string ModId, [property: JsonPropertyName("nameKey")] string NameKey, [property: JsonPropertyName("displayName")] string DisplayName);
}
