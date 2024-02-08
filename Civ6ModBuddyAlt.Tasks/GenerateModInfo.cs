using Microsoft.Build.Framework;
using System.Xml.Linq;

namespace Civ6ModBuddyAlt.Tasks;

public class GenerateModInfo : Microsoft.Build.Utilities.Task {
    [Required]
    public string ID { get; set; } = string.Empty;

    [Required]
    public string Version { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public string Teaser { get; set; } = string.Empty;
    public string Authors { get; set; } = string.Empty;
    public string SpecialThanks { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;

    [Required]
    public string TargetPath { get; set; } = string.Empty;

    public bool AffectsSavedGames { get; set; }
    public bool SupportsSinglePlayer { get; set; } = true;
    public bool SupportsMultiplayer { get; set; } = true;
    public bool SupportsHotSeat { get; set; }
    public string CompatibleVersions { get; set; } = string.Empty;
    public string CustomProperties { get; set; } = string.Empty;
    public string ActionCriteriaData { get; set; } = string.Empty;
    public string FrontEndActionData { get; set; } = string.Empty;
    public string InGameActionData { get; set; } = string.Empty;
    public string LocalizedTextData { get; set; } = string.Empty;
    public string AssociationData { get; set; } = string.Empty;

    public ITaskItem[]? Files { get; set; }

    public override bool Execute() {
        if (!CheckProperties()) {
            return false;
        }

        string text = Path.GetFileNameWithoutExtension(TargetPath) + ".dep";
        if (Files != null) {
            ITaskItem taskItem = Array.Find(Files, (ITaskItem f) => Path.GetExtension(f.GetMetadata("FullPath")) == ".dep");

            if (taskItem != null) {
                text = Uri.UnescapeDataString(new Uri(TargetPath).MakeRelativeUri(new Uri(taskItem.GetMetadata("FullPath"))).ToString());
            }
        }

        XDocument xdocument = new XDocument(new XElement("Mod"));

        xdocument.Root.SetAttributeValue("id", ID);
        xdocument.Root.SetAttributeValue("version", Version);

        XElement xelement = new XElement("Properties", new XElement("Name", Name), new XElement("Description", Description));

        xdocument.Root.Add(xelement);

        if (!string.IsNullOrWhiteSpace(CustomProperties)) {
            XDocument xdocument2 = XDocument.Parse(CustomProperties);

            if (xdocument2 != null) {
                foreach (XElement xelement2 in xdocument2.Elements()) {
                    xelement.SetElementValue(xelement2.Name, xelement2.Value);
                }
            }
        }

        xelement.SetElementValue("Created", ((long)Created.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString());

        if (!string.IsNullOrWhiteSpace(Teaser)) {
            xelement.SetElementValue("Teaser", Teaser);
        }

        if (!string.IsNullOrWhiteSpace(Authors)) {
            xelement.SetElementValue("Authors", Authors);
        }

        if (!string.IsNullOrWhiteSpace(SpecialThanks)) {
            xelement.SetElementValue("SpecialThanks", SpecialThanks);
        }

        if (!AffectsSavedGames) {
            xelement.SetElementValue("AffectsSavedGames", "0");
        }

        if (!SupportsSinglePlayer) {
            xelement.SetElementValue("SupportsSinglePlayer", "0");
        }

        if (!SupportsMultiplayer) {
            xelement.SetElementValue("SupportsMultiplayer", "0");
        }

        if (!SupportsHotSeat) {
            xelement.SetElementValue("SupportsHotSeat", "0");
        }

        if (!string.IsNullOrWhiteSpace(CompatibleVersions)) {
            xelement.SetElementValue("CompatibleVersions", CompatibleVersions);
        }

        if (!string.IsNullOrWhiteSpace(AssociationData)) {
            XDocument xdocument3 = XDocument.Parse(AssociationData);
            List<XElement> list = xdocument3.Root.Elements("Dependency").ToList();

            if (list.Count > 0) {
                XElement xelement3 = new XElement("Dependencies");

                foreach (XElement xelement4 in list) {
                    XElement xelement5 = new XElement("Mod");
                    string value = xelement4.Attribute("id").Value;
                    string value2 = xelement4.Attribute("title").Value;
                    string text3 = (xelement4.Attribute("min_version") != null) ? xelement4.Attribute("min_version").Value : string.Empty;
                    string text4 = (xelement4.Attribute("max_version") != null) ? xelement4.Attribute("max_version").Value : string.Empty;

                    xelement5.SetAttributeValue("id", value);
                    xelement5.SetAttributeValue("title", value2);

                    if (text3 != string.Empty) {
                        xelement5.SetAttributeValue("min_version", text3);
                    }

                    if (text4 != string.Empty) {
                        xelement5.SetAttributeValue("max_version", text4);
                    }

                    xelement3.Add(xelement5);
                }

                xdocument.Root.Add(xelement3);
            }
            List<XElement> list2 = xdocument3.Root.Elements("Reference").ToList();

            if (list2.Count > 0) {
                XElement xelement6 = new XElement("References");

                foreach (XElement xelement7 in list2) {
                    XElement xelement8 = new XElement("Mod");
                    string value3 = xelement7.Attribute("id").Value;
                    string value4 = xelement7.Attribute("title").Value;
                    string text5 = (xelement7.Attribute("min_version") != null) ? xelement7.Attribute("min_version").Value : string.Empty;
                    string text6 = (xelement7.Attribute("max_version") != null) ? xelement7.Attribute("max_version").Value : string.Empty;

                    xelement8.SetAttributeValue("id", value3);
                    xelement8.SetAttributeValue("title", value4);

                    if (text5 != string.Empty) {
                        xelement8.SetAttributeValue("min_version", text5);
                    }

                    if (text6 != string.Empty) {
                        xelement8.SetAttributeValue("max_version", text6);
                    }

                    xelement6.Add(xelement8);
                }

                xdocument.Root.Add(xelement6);
            }

            List<XElement> list3 = xdocument3.Root.Elements("Block").ToList();

            if (list3.Count > 0) {
                XElement xelement9 = new XElement("Blocks");

                foreach (XElement xelement10 in list3) {
                    XElement xelement11 = new XElement("Mod");
                    string value5 = xelement10.Attribute("id").Value;
                    string value6 = xelement10.Attribute("title").Value;
                    string text7 = (xelement10.Attribute("min_version") != null) ? xelement10.Attribute("min_version").Value : string.Empty;
                    string text8 = (xelement10.Attribute("max_version") != null) ? xelement10.Attribute("max_version").Value : string.Empty;

                    xelement11.SetAttributeValue("id", value5);
                    xelement11.SetAttributeValue("title", value6);

                    if (text7 != string.Empty) {
                        xelement11.SetAttributeValue("min_version", text7);
                    }

                    if (text8 != string.Empty) {
                        xelement11.SetAttributeValue("max_version", text8);
                    }

                    xelement9.Add(xelement11);
                }

                xdocument.Root.Add(xelement9);
            }
        }

        if (!string.IsNullOrWhiteSpace(ActionCriteriaData)) {
            XDocument xdocument4 = XDocument.Parse(ActionCriteriaData);

            xdocument.Root.Add(xdocument4.Root);
        }

        if (!string.IsNullOrWhiteSpace(FrontEndActionData)) {
            XDocument xdocument5 = XDocument.Parse(FrontEndActionData);

            if (xdocument5.Root != null) {
                IEnumerable<XElement> enumerable = xdocument5.Root.Elements().SelectMany((XElement e) => from f in e.Elements("File")
                                                                                                         where f.Value == "(Mod Art Dependency File)"
                                                                                                         select f);

                foreach (XElement xelement12 in enumerable) {
                    xelement12.Value = text;
                }
            }

            xdocument.Root.Add(xdocument5.Root);
        }

        if (!string.IsNullOrWhiteSpace(InGameActionData)) {
            XDocument xdocument6 = XDocument.Parse(InGameActionData);

            if (xdocument6.Root != null) {
                IEnumerable<XElement> enumerable2 = xdocument6.Root.Elements().SelectMany((XElement e) => from f in e.Elements("File")
                                                                                                          where f.Value == "(Mod Art Dependency File)"
                                                                                                          select f);

                foreach (XElement xelement13 in enumerable2) {
                    xelement13.Value = text;
                }
            }

            xdocument.Root.Add(xdocument6.Root);
        }

        if (!string.IsNullOrWhiteSpace(LocalizedTextData)) {
            XDocument xdocument7 = XDocument.Parse(LocalizedTextData);

            xdocument.Root.Add(xdocument7.Root);
        }

        if (Files != null) {
            XElement xelement14 = new XElement("Files");

            xdocument.Root.Add(xelement14);

            Uri uri4 = new Uri(TargetPath);

            foreach (ITaskItem taskItem2 in Files) {
                string metadata = taskItem2.GetMetadata("FullPath");
                Uri uri5 = new Uri(metadata);
                Uri uri6 = uri4.MakeRelativeUri(uri5);
                string text9 = Uri.UnescapeDataString(uri6.ToString());

                if (File.Exists(metadata)) {
                    xelement14.Add(new XElement("File", text9));
                } else {
                    Log.LogWarning("{0} appears to be missing. Skipping file..", metadata);
                }
            }
        }

        xdocument.Save(TargetPath);

        return true;
    }

    public bool CheckProperties() {
        if (string.IsNullOrWhiteSpace(ID)) {
            Log.LogError("ID is a required property of GenerateModInfo.", null);
        }

        if (string.IsNullOrWhiteSpace(Version)) {
            Log.LogError("Version is a required property of GenerateModInfo.", null);
        }

        if (string.IsNullOrWhiteSpace(Name)) {
            Log.LogError("Name is a required property of GenerateModInfo.", null);
        }

        if (string.IsNullOrWhiteSpace(Description)) {
            Log.LogError("Description is a required property of GenerateModInfo", null);
        }

        if (string.IsNullOrWhiteSpace(TargetPath)) {
            Log.LogError("TargetPath is a required property of GenerateModInfo.", null);
        }

        return !Log.HasLoggedErrors;
    }
}
