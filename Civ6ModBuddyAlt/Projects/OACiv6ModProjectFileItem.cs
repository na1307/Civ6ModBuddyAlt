using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Project.Automation;
using System.Runtime.InteropServices;

namespace Civ6ModBuddyAlt.Projects;

[ComVisible(true)]
[Guid("bb55e070-1e2f-468c-bdd2-0cc119a78ceb")]
public class OACiv6ModProjectFileItem : OAFileItem {
    public OACiv6ModProjectFileItem(OAProject project, FileNode node) : base(project, node) { }
}