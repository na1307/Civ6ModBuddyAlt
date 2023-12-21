using Microsoft.VisualStudio.Project;
using System;
using System.Runtime.InteropServices;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Civ6ModBuddyAlt.Projects;

[Guid(Civ6ModBuddyAltPackage.Civ6ProjectFactoryGuidString)]
public class Civ6ProjectFactory : ProjectFactory {
    private readonly Civ6ModBuddyAltPackage _package;

    public Civ6ProjectFactory(Civ6ModBuddyAltPackage package) : base(package) {
        _package = package;
    }

    protected override ProjectNode CreateProject() {
        Civ6ProjectNode project = Civ6ProjectNode.CreateInstance(_package);

        project.SetSite((IOleServiceProvider)((IServiceProvider)_package).GetService(typeof(IOleServiceProvider)));

        return project;
    }
}
