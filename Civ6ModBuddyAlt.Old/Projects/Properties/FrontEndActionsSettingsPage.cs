using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Civ6ModBuddyAlt.Projects.Properties;

[ComVisible(true)]
[Guid(Civ6ModBuddyAltPackage.FrontEndActionsSettingsPageGuidString)]
public class FrontEndActionsSettingsPage : Civ6SettingsPage {
    public FrontEndActionsSettingsPage() {
        Name = "FrontEnd Actions";
    }

    protected override void AddVisualElements() {
        if (ProjectManager is Civ6ProjectNode customProjectNode) {
            ElementHost elementHost = new() {
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            ThePanel.Controls.Add(elementHost);

            FrontEndActionUserControl frontEndActionUserControl = new(customProjectNode);
            frontEndActionUserControl.ActionsUpdated += Actions_ItemsUpdated;

            frontEndActionUserControl.InitializeComponent();

            elementHost.Child = frontEndActionUserControl;
        }
    }

    private void Actions_ItemsUpdated(object sender, EventArgs e) {
        IsDirty = true;
    }
}
