using System;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

public partial class ModInfoUserControl : UserControl {
    private readonly Civ6ProjectNode projectMgr;
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3604:Member initializer values should not be redundant", Justification = "<보류 중>")]
    private readonly bool isInitializing = true;

    public ModInfoUserControl(Civ6ProjectNode projectManager) {
        projectMgr = projectManager;
        InitializeComponent();
        InitializeDefaultValues();
        isInitializing = false;
    }

    private void InitializeDefaultValues() {
        modIdTextBox.Text = projectMgr.GetProjectProperty("Guid");
        modNameTextBox.Text = projectMgr.GetProjectProperty("Name");
        descriptionTextBox.Text = projectMgr.GetProjectProperty("Description");
        teaserTextBox.Text = projectMgr.GetProjectProperty("Teaser");
        authorsTextBox.Text = projectMgr.GetProjectProperty("Authors");
        specialThanksTextBox.Text = projectMgr.GetProjectProperty("SpecialThanks");
        singleCheckBox.Checked = GetProjectPropertyAsBool("SupportsSinglePlayer", true);
        multiCheckBox.Checked = GetProjectPropertyAsBool("SupportsMultiplayer", true);
        hotCheckBox.Checked = GetProjectPropertyAsBool("SupportsHotSeat", true);
        affectsCheckBox.Checked = GetProjectPropertyAsBool("AffectsSavedGames", true);
        string projectProperty = projectMgr.GetProjectProperty("ModVersion");

        if (string.IsNullOrWhiteSpace(projectProperty)) {
            projectMgr.SetProjectProperty("ModVersion", "1");
            versionUpDown.Value = 1m;
        } else {
            if (int.TryParse(projectProperty, out var num)) {
                versionUpDown.Value = num;
            } else {
                projectMgr.SetProjectProperty("ModVersion", "1");
                versionUpDown.Value = 1m;
            }
        }
    }

    private bool GetProjectPropertyAsBool(string propertyName, bool defaultValue) {
        string projectProperty = projectMgr.GetProjectProperty(propertyName);

        if (string.IsNullOrWhiteSpace(projectProperty)) {
            return defaultValue;
        }

        return projectProperty == "true";
    }

    private bool ValidateTextControl(Control control, string name, int minLength, int maxLength) {
        if (string.IsNullOrWhiteSpace(control.Text)) {
            string text = string.Format(Civ6ModBuddyAltPackage.PropertyCannotBeEmpty, name);

            errorProvider.SetError(control, text);

            return false;
        }

        control.Text = control.Text.Trim();

        if (control.Text.Length < minLength) {
            string text2 = string.Format(Civ6ModBuddyAltPackage.PropertyMustBeAtLeastXLength, name, minLength);

            errorProvider.SetError(control, text2);

            return false;
        }

        if (control.Text.Length > maxLength) {
            string text3 = string.Format(Civ6ModBuddyAltPackage.PropertyMustBeAtMaxXLength, name, maxLength);

            errorProvider.SetError(control, text3);

            return false;
        }

        errorProvider.SetError(control, string.Empty);

        return true;
    }

    private void SetProjectProperty(string propertyName, bool bValue) {
        projectMgr.SetProjectProperty(propertyName, bValue ? "true" : "false");
    }

    private void newGuidButton_Click(object sender, EventArgs e) {
        if (MessageBox.Show("Replacing the GUID of a mod is the equivalent of making this a new mod.  It will have no connection to the previous GUID.  Any mods which associated with this mod by GUID will no longer have any association with this mod.  Are you sure you'd like to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
            Guid guid = Guid.NewGuid();
            projectMgr.SetProjectProperty("Guid", guid.ToString());
            modIdTextBox.Text = guid.ToString();
        }
    }

    private void versionUpDown_ValueChanged(object sender, EventArgs e) {
        projectMgr.SetProjectProperty("ModVersion", versionUpDown.Value.ToString());
    }

    private void modNameTextBox_TextChanged(object sender, EventArgs e) {
        if (!isInitializing) {
            projectMgr.SetProjectProperty("Name", modNameTextBox.Text.Trim());
        }
    }

    private void modNameTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
        if (!ValidateTextControl(modNameTextBox, "Name", 10, 256)) {
            e.Cancel = true;
        }
    }

    private void authorTextBox_TextChanged(object sender, EventArgs e) {
        if (!isInitializing) {
            projectMgr.SetProjectProperty("Authors", authorsTextBox.Text.Trim());
        }
    }

    private void authorsTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
        if (!ValidateTextControl(authorsTextBox, "Authors", 6, 256)) {
            e.Cancel = true;
        }
    }

    private void specialThanksTextBox_TextChanged(object sender, EventArgs e) {
        if (!isInitializing) {
            projectMgr.SetProjectProperty("SpecialThanks", specialThanksTextBox.Text.Trim());
        }
    }

    private void teaserTextBox_TextChanged(object sender, EventArgs e) {
        if (!isInitializing) {
            projectMgr.SetProjectProperty("Teaser", teaserTextBox.Text.Trim());
        }
    }

    private void descriptionTextBox_TextChanged(object sender, EventArgs e) {
        if (!isInitializing) {
            projectMgr.SetProjectProperty("Description", descriptionTextBox.Text.Trim());
        }
    }

    private void descriptionTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
        if (!ValidateTextControl(descriptionTextBox, "Description", 16, 4096)) {
            e.Cancel = true;
        }
    }

    private void singleCheckBox_CheckedChanged(object sender, EventArgs e) {
        SetProjectProperty("SupportsSinglePlayer", singleCheckBox.Checked);
    }

    private void multiCheckBox_CheckedChanged(object sender, EventArgs e) {
        SetProjectProperty("SupportsMultiplayer", multiCheckBox.Checked);
    }

    private void hotCheckBox_CheckedChanged(object sender, EventArgs e) {
        SetProjectProperty("SupportsHotSeat", hotCheckBox.Checked);
    }

    private void affectsCheckBox_CheckedChanged(object sender, EventArgs e) {
        SetProjectProperty("AffectsSavedGames", affectsCheckBox.Checked);
    }
}
