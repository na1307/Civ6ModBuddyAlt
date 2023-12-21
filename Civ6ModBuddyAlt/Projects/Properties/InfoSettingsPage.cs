using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

[ComVisible(true)]
[Guid(Civ6ModBuddyAltPackage.InfoSettingsPageGuidString)]
public class InfoSettingsPage : Civ6SettingsPage {
    public InfoSettingsPage() {
        Name = "Mod Info";
    }

    protected override void AddVisualElements() {
        ModInfoUserControl modInfoUserControl = new(ProjectManager as Civ6ProjectNode) {
            Dock = DockStyle.Fill
        };

        ThePanel.Controls.Add(modInfoUserControl);

        ThePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ThePanel.AutoSize = true;
        ThePanel.AutoScroll = true;
    }
}
