using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

[ComVisible(true)]
[Guid(Civ6ModBuddyAltPackage.InfoSettingsPageGuidString)]
public class InfoSettingsPage : Civ6SettingsPage {
    public InfoSettingsPage() => Name = "Mod Info";

    protected override void AddVisualElements() {
        ThePanel.Controls.Add(new ModInfoUserControl((Civ6ProjectNode)ProjectManager) {
            Dock = DockStyle.Fill
        });

        ThePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ThePanel.AutoSize = true;
        ThePanel.AutoScroll = true;
    }
}
