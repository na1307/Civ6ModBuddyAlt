using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Wizards;

public partial class NewModWizard : Form {
    private List<IModWizardPage> pages = [];
    private int currentPage;

    public NewModWizard() {
        InitializeComponent();
    }

    public List<IModWizardPage> Pages {
        get => pages;
        set {
            pages = value;
            Text = string.Format(Civ6ModBuddyAltPackage.WizardCaption, CurrentPage + 1, MaxPages);
        }
    }

    public int CurrentPage {
        get => currentPage;
        set {
            if (Pages.Count > currentPage) {
                Pages[currentPage].Panel.Hide();
            }

            currentPage = value;
            Text = string.Format(Civ6ModBuddyAltPackage.WizardCaption, CurrentPage + 1, MaxPages);

            if (Pages.Count > currentPage) {
                IModWizardPage modWizardPage = Pages[currentPage];
                modWizardPage.Panel.Show();
            }
        }
    }

    public int MaxPages => pages.Count;

    private void page_PropertyChanged(object sender, PropertyChangedEventArgs e) {
        IModWizardPage modWizardPage = Pages[CurrentPage];
        string propertyName;

        if ((propertyName = e.PropertyName) != null && propertyName == "CanGoNext") {
            finishButton.Enabled = modWizardPage.CanGoNext;
        }
    }

    private void NewModWizard_Load(object sender, EventArgs e) {
        foreach (IModWizardPage modWizardPage in Pages) {
            panel2.Controls.Add(modWizardPage.Panel);
            modWizardPage.PropertyChanged += page_PropertyChanged;
            modWizardPage.Panel.Dock = DockStyle.Fill;
            modWizardPage.Panel.Hide();
        }

        CurrentPage = 0;
    }

    private void finishButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.OK;
    }
}
