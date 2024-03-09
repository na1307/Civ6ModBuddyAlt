using Civ6ModBuddyAlt.Options;
using System.IO;

namespace Civ6ModBuddyAlt;

public sealed class Civ6ProjectShellSettings {
    private readonly NameOptionPage nameOptionPage;
    private readonly PathOptionPage pathOptionPage;

    public Civ6ProjectShellSettings(Civ6ModBuddyAltPackage projectPackageArg) {
        if (projectPackageArg is null) {
            throw new ArgumentNullException(nameof(projectPackageArg));
        }

        nameOptionPage = projectPackageArg.GetDialogPage<NameOptionPage>();
        pathOptionPage = projectPackageArg.GetDialogPage<PathOptionPage>();
    }

    public string Authors => nameOptionPage.Authors;
    public string UserPath => pathOptionPage.UserPath;
    public string GamePath => pathOptionPage.GamePath;
    public string AssetsPath => pathOptionPage.AssetsPath;
    public string ToolsPath => pathOptionPage.ToolsPath;
    public string CookerPath => Path.GetFullPath(Path.Combine(ToolsPath, "AssetModTools", "Cooker", "Civ6AssetCooker_FinalRelease.exe"));
}
