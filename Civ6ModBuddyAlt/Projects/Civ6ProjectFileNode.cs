using EnvDTE;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Project.Automation;

namespace Civ6ModBuddyAlt.Projects;

public class Civ6ProjectFileNode : FileNode {
    private OACiv6ModProjectFileItem? automationObject;

    internal Civ6ProjectFileNode(ProjectNode root, ProjectElement e) : base(root, e) { }

    protected override NodeProperties CreatePropertiesObject() => new Civ6ProjectFileProperties(this);

    public override object GetAutomationObject() {
        automationObject ??= new OACiv6ModProjectFileItem((OAProject)ProjectManager.GetAutomationObject(), this);

        return automationObject;
    }

    internal ServiceCreatorCallback ServiceCreator => CreateServices;

    private object? CreateServices(Type serviceType) => typeof(ProjectItem) == serviceType ? GetAutomationObject() : null;
}
