using System.Windows;

namespace Civ6ModBuddyAlt.Wizards;

/// <summary>
/// WizardWindow.xaml에 대한 상호 작용 논리
/// </summary>
public sealed partial class WizardWindow {
    private readonly WizardViewModel viewModel;

    public WizardWindow() {
        InitializeComponent();
        viewModel = new();
        DataContext = viewModel;
    }

    public string ModTitle => viewModel.ModTitle;
    public string ModAuthors => viewModel.ModAuthors;
    public string ModSpecialThanks => viewModel.ModSpecialThanks;
    public string ModDescription => viewModel.ModDescription;

    private void OKButton_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    private void CancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;
}
