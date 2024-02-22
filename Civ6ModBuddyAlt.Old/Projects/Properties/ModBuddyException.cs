namespace Civ6ModBuddyAlt.Projects.Properties;

public class ModBuddyException : Exception {
    public ModBuddyException() { }
    public ModBuddyException(string message) : base(message) { }
    public ModBuddyException(string message, Exception inner) : base(message, inner) { }
}
