using Civ6ModBuddyAlt.Projects;
using Civ6ModBuddyAlt.Projects.Properties;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Civ6ModBuddyAlt;

/// <summary>
/// This is the class that implements the package exposed by this assembly.
/// </summary>
/// <remarks>
/// <para>
/// The minimum requirement for a class to be considered a valid package for Visual Studio
/// is to implement the IVsPackage interface and register itself with the shell.
/// This package uses the helper classes defined inside the Managed Package Framework (MPF)
/// to do it: it derives from the Package class that provides the implementation of the
/// IVsPackage interface and uses the registration attributes defined in the framework to
/// register itself and its components with the shell. These attributes tell the pkgdef creation
/// utility what data to put into .pkgdef file.
/// </para>
/// <para>
/// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
/// </para>
/// </remarks>
[PackageRegistration(UseManagedResourcesOnly = true)]
[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
[ProvideMenuResource("Menus.ctmenu", 1)]
[ProvideOptionPage(typeof(Civ6PathOptionPage), "Civilization VI", "Path", 0, 0, true)]
[ProvideProjectFactory(typeof(Civ6ProjectFactory), "Civilization VI", "Civilization VI Project Files (*.civ6proj);*.civ6proj", "civ6proj", "civ6proj", null, LanguageVsTemplate = ProjectTypeName)]
[ProvideObject(typeof(InfoSettingsPage), RegisterUsing = RegistrationMethod.CodeBase)]
[ProvideObject(typeof(AssociationsSettingsPage), RegisterUsing = RegistrationMethod.CodeBase)]
[ProvideObject(typeof(FrontEndActionsSettingsPage), RegisterUsing = RegistrationMethod.CodeBase)]
[ProvideObject(typeof(InGameActionsSettingsPage), RegisterUsing = RegistrationMethod.CodeBase)]
[ProvideService(typeof(Civ6ProjectShellSettings), ServiceName = "Civilization VI Project Settings")]
[Guid(PackageGuidString)]
public sealed class Civ6ModBuddyAltPackage : ProjectPackage {
    /// <summary>
    /// Civ6ModBuddyAltPackage GUID string.
    /// </summary>
    public const string PackageGuidString = "8bf8641c-19cf-4132-9b76-b8ed019d0ce0";

    /// <summary>
    /// Civ6ProjectFactory GUID string.
    /// </summary>
    public const string Civ6ProjectFactoryGuidString = "67e9a580-b80a-47b4-aabe-ea3c686919ce";

    /// <summary>
    /// InfoSettingsPage GUID string.
    /// </summary>
    public const string InfoSettingsPageGuidString = "7d1d67d3-e13e-487e-9992-422c2cafd796";

    /// <summary>
    /// AssociationsSettingsPage GUID string.
    /// </summary>
    public const string AssociationsSettingsPageGuidString = "927cc605-5439-4006-b95c-992c39bde7c7";

    /// <summary>
    /// FrontEndActionsSettingsPage GUID string.
    /// </summary>
    public const string FrontEndActionsSettingsPageGuidString = "cdb5c7a3-8ced-43df-9f02-f7137aabd268";

    /// <summary>
    /// InGameActionsSettingsPage GUID string.
    /// </summary>
    public const string InGameActionsSettingsPageGuidString = "fb8672b3-8c8c-4244-b3e3-f5b647ec2e37";

    public const string ProjectTypeName = "Civ6ModProject";

    public const string PropertyCannotBeEmpty = "{0} cannot be empty.";

    public const string PropertyMustBeAtLeastXLength = "{0} must be at least {1} characters long.";

    public const string PropertyMustBeAtMaxXLength = "{0} can be no longer than {1} characters long.";

    public const string DefaultModName = "My Custom Mod";

    public const string DefaultModDescription = "This is a brief description of the mod.";

    public const string WizardCaption = "Create a new mod - {0} of {1}";

    #region Package Members

    public string UserPath => ((Civ6PathOptionPage)GetDialogPage(typeof(Civ6PathOptionPage))).UserPath;
    public string GamePath => ((Civ6PathOptionPage)GetDialogPage(typeof(Civ6PathOptionPage))).GamePath;
    public string ToolsPath => ((Civ6PathOptionPage)GetDialogPage(typeof(Civ6PathOptionPage))).ToolsPath;
    public string AssetsPath => ((Civ6PathOptionPage)GetDialogPage(typeof(Civ6PathOptionPage))).AssetsPath;
    public override string ProductUserContext => ProjectTypeName;

    public TDialogPage GetDialogPage<TDialogPage>() where TDialogPage : DialogPage => (TDialogPage)GetDialogPage(typeof(TDialogPage));

    protected override void Initialize() {
        base.Initialize();
        RegisterProjectFactory(new Civ6ProjectFactory(this));
        AddService(typeof(Civ6ProjectShellSettings), new Civ6ProjectShellSettings(this));
    }

    private void AddService(Type serviceType, object serviceInstance) => ((IServiceContainer)this).AddService(serviceType, serviceInstance, true);

    #endregion
}
