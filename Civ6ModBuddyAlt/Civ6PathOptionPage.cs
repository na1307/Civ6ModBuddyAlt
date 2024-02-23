using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt;

[Guid("e22a0d36-d176-4c82-a3de-407e0b1ab4df")]
public sealed class Civ6PathOptionPage : DialogPage {
    private string userPath = string.Empty;
    private string gamePath = string.Empty;
    private string toolsPath = string.Empty;
    private string assetsPath = string.Empty;

    public string UserPath {
        get {
            if (string.IsNullOrWhiteSpace(userPath)) {
                userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games\\Sid Meier's Civilization VI");
            }

            return userPath;
        }
        set => userPath = value;
    }

    public string GamePath {
        get {
            if (string.IsNullOrWhiteSpace(gamePath)) {
                gamePath = getSteamPath("Sid Meier's Civilization VI");
            }

            return gamePath;
        }
        set => gamePath = value;
    }

    public string ToolsPath {
        get {
            if (string.IsNullOrWhiteSpace(toolsPath)) {
                toolsPath = getSteamPath("Sid Meier's Civilization VI SDK");
            }

            return toolsPath;
        }
        set => toolsPath = value;
    }

    public string AssetsPath {
        get {
            if (string.IsNullOrWhiteSpace(assetsPath)) {
                assetsPath = getSteamPath("Sid Meier's Civilization VI SDK Assets");
            }

            return assetsPath;
        }
        set => assetsPath = value;
    }

    protected override IWin32Window Window => new Civ6PathUserControl(this);

    private static string getSteamPath(string dirName) {
        if (Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\" + dirName)) {
            return @"C:\Program Files (x86)\Steam\steamapps\common\" + dirName;
        }

        if (Directory.Exists(@"C:\Program Files\Steam\steamapps\common\" + dirName)) {
            return @"C:\Program Files\Steam\steamapps\common\" + dirName;
        }

        return Array.Find(Directory.GetLogicalDrives(), dl => Directory.Exists(dl + @"SteamLibrary\steamapps\common\" + dirName)) + @"SteamLibrary\steamapps\common\" + dirName;
    }
}
