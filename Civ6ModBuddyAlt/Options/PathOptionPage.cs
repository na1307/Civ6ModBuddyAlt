using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

namespace Civ6ModBuddyAlt.Options;

[Guid("e22a0d36-d176-4c82-a3de-407e0b1ab4df")]
public sealed class PathOptionPage : UIElementDialogPage, INotifyPropertyChanged {
    private string userPath = string.Empty;
    private string gamePath = string.Empty;
    private string toolsPath = string.Empty;
    private string assetsPath = string.Empty;

    public event PropertyChangedEventHandler PropertyChanged;

    public string UserPath {
        get {
            if (string.IsNullOrWhiteSpace(userPath)) {
                userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games\\Sid Meier's Civilization VI");
            }

            return userPath;
        }
        set => setProperty(ref userPath, value);
    }

    public string GamePath {
        get {
            if (string.IsNullOrWhiteSpace(gamePath)) {
                gamePath = getSteamPath("Sid Meier's Civilization VI");
            }

            return gamePath;
        }
        set => setProperty(ref gamePath, value);
    }

    public string ToolsPath {
        get {
            if (string.IsNullOrWhiteSpace(toolsPath)) {
                toolsPath = getSteamPath("Sid Meier's Civilization VI SDK");
            }

            return toolsPath;
        }
        set => setProperty(ref toolsPath, value);
    }

    public string AssetsPath {
        get {
            if (string.IsNullOrWhiteSpace(assetsPath)) {
                assetsPath = getSteamPath("Sid Meier's Civilization VI SDK Assets");
            }

            return assetsPath;
        }
        set => setProperty(ref assetsPath, value);
    }

    protected override UIElement Child => new PathOptions(this);

    private static string getSteamPath(string dirName) {
        if (Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\" + dirName)) {
            return @"C:\Program Files (x86)\Steam\steamapps\common\" + dirName;
        }

        if (Directory.Exists(@"C:\Program Files\Steam\steamapps\common\" + dirName)) {
            return @"C:\Program Files\Steam\steamapps\common\" + dirName;
        }

        return Array.Find(Directory.GetLogicalDrives(), dl => Directory.Exists(dl + @"SteamLibrary\steamapps\common\" + dirName)) + @"SteamLibrary\steamapps\common\" + dirName;
    }

    private bool setProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) {
        if (!Equals(field, newValue)) {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        return false;
    }
}
