using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Civ6ModBuddyAlt.Projects.Properties;

[ComVisible(true)]
[Guid(Civ6ModBuddyAltPackage.InGameActionsSettingsPageGuidString)]
public class InGameActionsSettingsPage : Civ6SettingsPage {
    public InGameActionsSettingsPage() {
        Name = "In-Game Actions";
    }

    protected override void AddVisualElements() {
        if (ProjectManager is Civ6ProjectNode customProjectNode) {
            ElementHost elementHost = new ElementHost {
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            ThePanel.Controls.Add(elementHost);

            InGameActionsUserControl inGameActionsUserControl = new(customProjectNode);
            inGameActionsUserControl.ActionsUpdated += Actions_ItemsUpdated;

            inGameActionsUserControl.InitializeComponent();

            elementHost.Child = inGameActionsUserControl;
        }
    }

    private void Actions_ItemsUpdated(object sender, EventArgs e) {
        IsDirty = true;
    }
}
