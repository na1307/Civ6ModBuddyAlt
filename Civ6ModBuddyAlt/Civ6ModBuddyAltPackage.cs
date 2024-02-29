global using Microsoft.VisualStudio.ProjectSystem;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using Civ6ModBuddyAlt.Options;
using System.Runtime.InteropServices;
using System.Threading;

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
[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
[ProvideOptionPage(typeof(PathOptionPage), Civ6OptionsCategoryName, "Path", 0, 0, true)]
[Guid(PackageGuidString)]
public sealed class Civ6ModBuddyAltPackage : AsyncPackage {
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

    public const string Civ6OptionsCategoryName = "Civilization VI";

    #region Package Members

    public string UserPath => ((PathOptionPage)GetDialogPage(typeof(PathOptionPage))).UserPath;
    public string GamePath => ((PathOptionPage)GetDialogPage(typeof(PathOptionPage))).GamePath;
    public string ToolsPath => ((PathOptionPage)GetDialogPage(typeof(PathOptionPage))).ToolsPath;
    public string AssetsPath => ((PathOptionPage)GetDialogPage(typeof(PathOptionPage))).AssetsPath;

    /// <summary>
    /// Initialization of the package; this method is called right after the package is sited, so this is the place
    /// where you can put all the initialization code that rely on services provided by VisualStudio.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
    /// <param name="progress">A provider for progress updates.</param>
    /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
    protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress) {
        // When initialized asynchronously, the current thread may be a background thread at this point.
        // Do any initialization that requires the UI thread after switching to the UI thread.
        await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
    }

    #endregion
}
