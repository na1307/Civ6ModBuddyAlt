using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

[Guid(Civ6ModBuddyAltPackage.AssociationsSettingsPageGuidString)]
[ComVisible(true)]
public class AssociationsSettingsPage : Civ6SettingsPage {
    public AssociationsSettingsPage() {
        Name = "Associations";
    }

    protected override void AddVisualElements() {
        AssociationsUserControl associationsUserControl = new(ProjectManager as Civ6ProjectNode);

        ThePanel.Controls.Add(associationsUserControl);

        ThePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ThePanel.AutoSize = true;
        ThePanel.AutoScroll = true;
    }
}
