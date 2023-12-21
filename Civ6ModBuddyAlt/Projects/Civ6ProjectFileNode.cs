using EnvDTE;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Project.Automation;
using System;

namespace Civ6ModBuddyAlt.Projects;

public class Civ6ProjectFileNode : FileNode {
    private OACiv6ModProjectFileItem automationObject;

    internal Civ6ProjectFileNode(ProjectNode root, ProjectElement e) : base(root, e) { }

    protected override NodeProperties CreatePropertiesObject() => new Civ6ProjectFileProperties(this);

    public override object GetAutomationObject() {
        automationObject ??= new OACiv6ModProjectFileItem(ProjectManager.GetAutomationObject() as OAProject, this);

        return automationObject;
    }

    internal ServiceCreatorCallback ServiceCreator => new(CreateServices);

    private object CreateServices(Type serviceType) {
        object obj = null;

        if (typeof(ProjectItem) == serviceType) {
            obj = GetAutomationObject();
        }

        return obj;
    }
}
