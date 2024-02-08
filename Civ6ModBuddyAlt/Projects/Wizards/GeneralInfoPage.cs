using System.ComponentModel;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Wizards;

public partial class GeneralInfoPage : UserControl, IModWizardPage {
    private const int minNameLength = 8;
    private const int maxNameLength = 256;
    private const int minDescriptionLength = 8;
    private const int maxDescriptionLength = 1024;
    private bool canGoNext;
    private bool canGoBack;

    public event PropertyChangedEventHandler? PropertyChanged;

    public GeneralInfoPage() {
        InitializeComponent();
        titleTextBox.Text = Civ6ModBuddyAltPackage.DefaultModName;
        descriptionTextBox.Text = Civ6ModBuddyAltPackage.DefaultModDescription;
        authorsTextBox.Text = Environment.UserName;
    }

    public string Title => "General Information";
    public string Description => "Please enter the basic information required by every Civilization VI mod.";
    public UserControl Panel => this;

    public bool CanGoNext {
        get => canGoNext;
        set {
            canGoNext = value;
            OnPropertyChanged("CanGoNext");
        }
    }

    public bool CanGoBack {
        get => canGoBack;
        set {
            canGoBack = value;
            OnPropertyChanged("CanGoBack");
        }
    }

    public string ModTitle => titleTextBox.Text;
    public string ModDescription => descriptionTextBox.Text;
    public string ModAuthors => authorsTextBox.Text;
    public string ModSpecialThanks => specialThanksTextBox.Text;

    protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    private void ValidateForm() => CanGoNext = ValidateChildren(ValidationConstraints.Enabled);

    private bool ValidateTextControl(Control control, string name, int minLength, int maxLength) {
        if (string.IsNullOrWhiteSpace(control.Text)) {
            string text = string.Format(Civ6ModBuddyAltPackage.PropertyCannotBeEmpty, name);

            errorProvider.SetError(control, text);

            return false;
        }

        string text2 = control.Text.Trim();

        if (text2.Length < minLength) {
            string text3 = string.Format(Civ6ModBuddyAltPackage.PropertyMustBeAtLeastXLength, name, minLength);

            errorProvider.SetError(control, text3);

            return false;
        }

        if (text2.Length > maxLength) {
            string text4 = string.Format(Civ6ModBuddyAltPackage.PropertyMustBeAtMaxXLength, name, maxLength);

            errorProvider.SetError(control, text4);

            return false;
        }

        errorProvider.SetError(control, string.Empty);

        return true;
    }

    private void GeneralInfoPage_VisibleChanged(object sender, EventArgs e) => ValidateForm();
    private void GeneralInfoPage_Validating(object sender, CancelEventArgs e) => ValidateChildren(ValidationConstraints.Enabled);
    private void titleTextBox_TextChanged(object sender, EventArgs e) => ValidateForm();

    private void titleTextBox_Validating(object sender, CancelEventArgs e) {
        if (!ValidateTextControl(titleTextBox, "Name", minNameLength, maxNameLength)) {
            e.Cancel = true;
        }
    }

    private void authorsTextBox_TextChanged(object sender, EventArgs e) => ValidateForm();
    private void specialThanksTextBox_TextChanged(object sender, EventArgs e) => ValidateForm();
    private void descriptionTextBox_TextChanged(object sender, EventArgs e) => ValidateForm();

    private void descriptionTextBox_Validating(object sender, CancelEventArgs e) {
        if (!ValidateTextControl(descriptionTextBox, "Description", minDescriptionLength, maxDescriptionLength)) {
            e.Cancel = true;
        }
    }
}
