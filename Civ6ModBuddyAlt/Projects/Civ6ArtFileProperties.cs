using Microsoft.VisualStudio.Project;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace Civ6ModBuddyAlt.Projects;

[ComVisible(true)]
public class Civ6ArtFileProperties(HierarchyNode node) : NodeProperties(node) {
    [Description("FileNameDescription")]
    [Category("Misc")]
    [LocDisplayName("FileName")]
    public string FileName => Node.Caption;

    [Category("Misc")]
    [LocDisplayName("FullPath")]
    [Description("FullPathDescription")]
    public string FullPath => Node.Url;

    [DisplayName("Pantry")]
    [Category("Misc")]
    [Description("Specifies which pantry file to use.")]
    public Civ6Pantry Pantry {
        get => ((Civ6ArtFileNode)Node).Pantry;
        set => ((Civ6ArtFileNode)Node).Pantry = value;
    }

    [Category("Misc")]
    [DisplayName("Test Property")]
    [Description("This is a test property.")]
    public string Test => "This is a test.";

    [Browsable(false)]
    public string Extension => Path.GetExtension(Node.Caption);

    [Browsable(false)]
    public string SubType { get; set; } = string.Empty;
}