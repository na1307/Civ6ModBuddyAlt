using System;
using System.IO;

namespace Civ6ModBuddyAlt.Projects;

public class Civ6ProjectShellSettings {
    private readonly Civ6ModBuddyAltPackage projectPackage;

    public Civ6ProjectShellSettings(Civ6ModBuddyAltPackage projectPackageArg) => projectPackage = projectPackageArg ?? throw new ArgumentNullException("projectPackageArg");

    public string UserPath {
        get => projectPackage.GetDialogPage<Civ6PathOptionPage>().UserPath;
        set => projectPackage.GetDialogPage<Civ6PathOptionPage>().UserPath = value;
    }

    public string GamePath {
        get => projectPackage.GetDialogPage<Civ6PathOptionPage>().GamePath;
        set => projectPackage.GetDialogPage<Civ6PathOptionPage>().GamePath = value;
    }

    public string AssetsPath {
        get => projectPackage.GetDialogPage<Civ6PathOptionPage>().AssetsPath;
        set => projectPackage.GetDialogPage<Civ6PathOptionPage>().AssetsPath = value;
    }

    public string ToolsPath {
        get => projectPackage.GetDialogPage<Civ6PathOptionPage>().ToolsPath;
        set => projectPackage.GetDialogPage<Civ6PathOptionPage>().ToolsPath = value;
    }

    public string CookerPath => Path.GetFullPath(Path.Combine(ToolsPath, "AssetModTools", "Cooker", "Civ6AssetCooker_FinalRelease.exe"));
}
