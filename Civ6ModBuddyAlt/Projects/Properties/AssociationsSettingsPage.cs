using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

[Guid(Civ6ModBuddyAltPackage.AssociationsSettingsPageGuidString)]
[ComVisible(true)]
public class AssociationsSettingsPage : Civ6SettingsPage {
    public AssociationsSettingsPage() => Name = "Associations";

    protected override void AddVisualElements() {
        ThePanel.Controls.Add(new AssociationsUserControl((Civ6ProjectNode)ProjectManager));

        ThePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ThePanel.AutoSize = true;
        ThePanel.AutoScroll = true;
    }
}
