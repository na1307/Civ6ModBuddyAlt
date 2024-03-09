namespace Civ6ModBuddyAlt.Projects;

public class ModAssociation {
    public ModAssociationKind Kind { get; set; }
    public required string MinVersion { get; set; }
    public required string MaxVersion { get; set; }
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
}
