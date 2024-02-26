using System.Windows;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Wizards;

/// <summary>
/// WizardWindow.xaml에 대한 상호 작용 논리
/// </summary>
public partial class WizardWindow {
    public WizardWindow() => InitializeComponent();

    public string ModTitle { get; private set; }
    public string ModDescription { get; private set; }
    public string ModAuthors { get; private set; }
    public string ModSpecialThanks { get; private set; }

    private void TitleBox_TextChanged(object sender, TextChangedEventArgs e) => ModTitle = TitleBox.Text;
    private void AuthorsBox_TextChanged(object sender, TextChangedEventArgs e) => ModAuthors = AuthorsBox.Text;
    private void SpecialThanksBox_TextChanged(object sender, TextChangedEventArgs e) => ModSpecialThanks = SpecialThanksBox.Text;
    private void DescriptionBox_TextChanged(object sender, TextChangedEventArgs e) => ModDescription = DescriptionBox.Text;
    private void OKButton_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    private void CancelButton_Click(object sender, RoutedEventArgs e) => DialogResult = false;
}
