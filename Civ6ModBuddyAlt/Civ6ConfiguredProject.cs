using System.ComponentModel.Composition;

namespace Civ6ModBuddyAlt;

[Export]
[AppliesTo(Civ6UnconfiguredProject.UniqueCapability)]
internal sealed class Civ6ConfiguredProject {
    [Import]
    internal ConfiguredProject ConfiguredProject { get; private set; }

    [Import]
    internal ProjectProperties Properties { get; private set; }
}
