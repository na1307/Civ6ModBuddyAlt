using System.ComponentModel;
using System.Windows;

namespace Civ6ModBuddyAlt.Wizards;

/// <summary>
/// WizardWindow.xaml에 대한 상호 작용 논리
/// </summary>
public sealed partial class WizardWindow {
    private static readonly Civ6ProjectShellSettings projectSettings = (Civ6ProjectShellSettings)Package.GetGlobalService(typeof(Civ6ProjectShellSettings));
    private readonly WizardViewModel viewModel;

    public WizardWindow() {
        InitializeComponent();
        viewModel = new();
        DataContext = viewModel;
        TitleBox.Text = "Mod Title";
        AuthorsBox.Text = projectSettings.Authors;
        DescriptionBox.Text = "The description of the mod.";
    }

    public string ModTitle => viewModel.ModTitle;
    public string ModAuthors => viewModel.ModAuthors;
    public string ModSpecialThanks => viewModel.ModSpecialThanks;
    public string ModDescription => viewModel.ModDescription;

    protected override void OnClosing(CancelEventArgs e) {
        base.OnClosing(e);

        if (DialogResult.GetValueOrDefault() && !isValid()) {
            e.Cancel = true;
        }
    }

    private bool isValid() {
        StringLengthRule titleLenghtRule = new() { MinLength = 8, MaxLength = 256 };
        StringNotBeEmptyRule authorsRule = new();
        StringLengthRule descLenghtRule = new() { MinLength = 8, MaxLength = 1024 };

        return titleLenghtRule.Validate(TitleBox.Text, null).IsValid && authorsRule.Validate(AuthorsBox.Text, null).IsValid && descLenghtRule.Validate(DescriptionBox.Text, null).IsValid;
    }

    private void OKButton_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    private void CancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;
}
