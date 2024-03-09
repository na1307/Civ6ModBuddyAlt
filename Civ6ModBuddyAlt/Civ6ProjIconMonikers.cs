using Microsoft.VisualStudio.Imaging.Interop;

namespace Civ6ModBuddyAlt;

public static class Civ6ProjIconMonikers {
    private const int ProjectIcon = 0;
    private static readonly Guid ManifestGuid = new("7242e186-e6c8-4e0b-a8a0-ec9af195890c");

    public static ImageMoniker ProjectIconImageMoniker => new() { Id = ProjectIcon, Guid = ManifestGuid };
}
