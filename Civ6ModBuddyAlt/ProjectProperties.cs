using Microsoft.VisualStudio.ProjectSystem.Properties;
using System.ComponentModel.Composition;

namespace Civ6ModBuddyAlt;

[Export]
internal sealed partial class ProjectProperties : StronglyTypedPropertyAccess {
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectProperties"/> class.
    /// </summary>
    [ImportingConstructor]
    public ProjectProperties(ConfiguredProject configuredProject) : base(configuredProject) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectProperties"/> class.
    /// </summary>
    public ProjectProperties(ConfiguredProject configuredProject, string file, string itemType, string itemName) : base(configuredProject, file, itemType, itemName) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectProperties"/> class.
    /// </summary>
    public ProjectProperties(ConfiguredProject configuredProject, IProjectPropertiesContext projectPropertiesContext) : base(configuredProject, projectPropertiesContext) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectProperties"/> class.
    /// </summary>
    public ProjectProperties(ConfiguredProject configuredProject, UnconfiguredProject unconfiguredProject) : base(configuredProject, unconfiguredProject) { }
}
