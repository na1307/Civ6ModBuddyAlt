using System.ComponentModel;

namespace Civ6ModBuddyAlt.Options;

public sealed class NameOptionPage : DialogPage {
    [Category("Name")]
    [DisplayName("What's your name?")]
    [Description("This value will be used as the default value for Mod Authors.")]
    public string Authors { get; set; } = Environment.UserName;
}
