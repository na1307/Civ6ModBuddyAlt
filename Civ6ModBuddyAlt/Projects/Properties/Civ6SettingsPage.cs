using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace Civ6ModBuddyAlt.Projects.Properties;

[ComVisible(true)]
public abstract class Civ6SettingsPage : SettingsPage {
    protected Civ6SettingsPage() : base(Civ6ProjectNode.Instance) { }

    public override void Activate(IntPtr parent, RECT[] pRect, int bModal) {
        ThreadHelper.ThrowIfNotOnUIThread();
        base.Activate(parent, pRect, bModal);

        if (ProjectManager is Civ6ProjectNode) {
            AddVisualElements();
            return;
        }

        throw new ApplicationException("Project manager type incompatibility error.");
    }

    protected override void BindProperties() { }

    protected override int ApplyChanges() {
        if (ProjectManager is Civ6ProjectNode) {
            if (IsDirty) {
                IsDirty = false;
            }

            return 0;
        }

        return -2147024809;
    }

    protected abstract void AddVisualElements();
}
