using Microsoft.VisualStudio.Project.Automation;
using System.Runtime.InteropServices;

namespace Civ6ModBuddyAlt.Projects;

[ComVisible(true)]
public class OACiv6ModProject : OAProject {
    public OACiv6ModProject(Civ6ProjectNode project) : base(project) { }
}
