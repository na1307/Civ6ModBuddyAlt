using Microsoft.VisualStudio.ProjectSystem.VS;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Composition;

namespace Civ6ModBuddyAlt;

[Export]
[AppliesTo(UniqueCapability)]
[ProjectTypeRegistration(Civ6ModBuddyAltPackage.Civ6ProjectFactoryGuidString, "Civilization VI", "Civilization VI Project Files (*.civ6proj);*.civ6proj", ProjectExtension, Language, Civ6ModBuddyAltPackage.PackageGuidString, PossibleProjectExtensions = ProjectExtension)]
[method: ImportingConstructor]
internal sealed class Civ6UnconfiguredProject(UnconfiguredProject unconfiguredProject) {
    /// <summary>
    /// The file extension used by your project type.
    /// This does not include the leading period.
    /// </summary>
    internal const string ProjectExtension = "civ6proj";

    /// <summary>
    /// A project capability that is present in your project type and none others.
    /// This is a convenient constant that may be used by your extensions so they
    /// only apply to instances of your project type.
    /// </summary>
    /// <remarks>
    /// This value should be kept in sync with the capability as actually defined in your .targets.
    /// </remarks>
    internal const string UniqueCapability = Civ6ModBuddyAltPackage.ProjectTypeName;

    internal const string Language = Civ6ModBuddyAltPackage.ProjectTypeName;

    [Import]
    internal UnconfiguredProject UnconfiguredProject { get; private set; }

    [Import]
    internal IActiveConfiguredProjectSubscriptionService SubscriptionService { get; private set; }

    [Import]
    internal IProjectThreadingService ProjectThreadingService { get; private set; }

    [Import]
    internal ActiveConfiguredProject<ConfiguredProject> ActiveConfiguredProject { get; private set; }

    [Import]
    internal ActiveConfiguredProject<Civ6ConfiguredProject> MyActiveConfiguredProject { get; private set; }

    [ImportMany(ExportContractNames.VsTypes.IVsProject, typeof(IVsProject))]
    internal OrderPrecedenceImportCollection<IVsHierarchy> ProjectHierarchies { get; private set; } = new(projectCapabilityCheckProvider: unconfiguredProject);

    internal IVsHierarchy ProjectHierarchy => ProjectHierarchies.Single().Value;
}
