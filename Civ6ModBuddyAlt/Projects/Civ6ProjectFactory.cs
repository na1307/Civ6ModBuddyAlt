using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Civ6ModBuddyAlt.Projects;

[Guid(Civ6ModBuddyAltPackage.Civ6ProjectFactoryGuidString)]
public class Civ6ProjectFactory(Civ6ModBuddyAltPackage package) : ProjectFactory(package) {
    protected override ProjectNode CreateProject() {
        ThreadHelper.ThrowIfNotOnUIThread();
        Civ6ProjectNode project = Civ6ProjectNode.CreateInstance(package);

        project.SetSite((IOleServiceProvider)((IServiceProvider)package).GetService(typeof(IOleServiceProvider)));

        return project;
    }
}
