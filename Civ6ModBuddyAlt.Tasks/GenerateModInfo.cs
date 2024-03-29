﻿using Microsoft.Build.Framework;
using System.Linq;
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

        XDocument xdocument = new(new XElement("Mod"));

        xdocument.Root.SetAttributeValue("id", ID);
        xdocument.Root.SetAttributeValue("version", Version);

        XElement xelement = new("Properties", new XElement("Name", Name), new XElement("Description", Description));

        xdocument.Root.Add(xelement);

        if (!string.IsNullOrWhiteSpace(CustomProperties)) {
            var xdocument2 = XDocument.Parse(CustomProperties);

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
            var xdocument3 = XDocument.Parse(AssociationData);
            List<XElement> list = xdocument3.Root.Elements("Dependency").ToList();

            if (list.Count > 0) {
                XElement xelement3 = new("Dependencies");
                foreach (var (xelement5, value, value2, text3, text4) in from XElement xelement4 in list
                                                                         let xelement5 = new XElement("Mod")
                                                                         let value = xelement4.Attribute("id").Value
                                                                         let value2 = xelement4.Attribute("title").Value
                                                                         let text3 = (xelement4.Attribute("min_version") != null) ? xelement4.Attribute("min_version").Value : string.Empty
                                                                         let text4 = (xelement4.Attribute("max_version") != null) ? xelement4.Attribute("max_version").Value : string.Empty
                                                                         select (xelement5, value, value2, text3, text4)) {
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
                XElement xelement6 = new("References");

                foreach (var (xelement8, value3, value4, text5, text6) in from XElement xelement7 in list2
                                                                          let xelement8 = new XElement("Mod")
                                                                          let value3 = xelement7.Attribute("id").Value
                                                                          let value4 = xelement7.Attribute("title").Value
                                                                          let text5 = (xelement7.Attribute("min_version") != null) ? xelement7.Attribute("min_version").Value : string.Empty
                                                                          let text6 = (xelement7.Attribute("max_version") != null) ? xelement7.Attribute("max_version").Value : string.Empty
                                                                          select (xelement8, value3, value4, text5, text6)) {
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
                XElement xelement9 = new("Blocks");
                foreach (var (xelement11, value5, value6, text7, text8) in from XElement xelement10 in list3
                                                                           let xelement11 = new XElement("Mod")
                                                                           let value5 = xelement10.Attribute("id").Value
                                                                           let value6 = xelement10.Attribute("title").Value
                                                                           let text7 = (xelement10.Attribute("min_version") != null) ? xelement10.Attribute("min_version").Value : string.Empty
                                                                           let text8 = (xelement10.Attribute("max_version") != null) ? xelement10.Attribute("max_version").Value : string.Empty
                                                                           select (xelement11, value5, value6, text7, text8)) {
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
            var xdocument4 = XDocument.Parse(ActionCriteriaData);

            xdocument.Root.Add(xdocument4.Root);
        }

        if (!string.IsNullOrWhiteSpace(FrontEndActionData)) {
            var xdocument5 = XDocument.Parse(FrontEndActionData);

            if (xdocument5.Root != null) {
                IEnumerable<XElement> enumerable = xdocument5.Root.Elements().SelectMany(e => e.Elements("File").Where(f => f.Value == "(Mod Art Dependency File)"));

                foreach (XElement xelement12 in enumerable) {
                    xelement12.Value = text;
                }
            }

            xdocument.Root.Add(xdocument5.Root);
        }

        if (!string.IsNullOrWhiteSpace(InGameActionData)) {
            var xdocument6 = XDocument.Parse(InGameActionData);

            if (xdocument6.Root != null) {
                IEnumerable<XElement> enumerable2 = xdocument6.Root.Elements().SelectMany(e => e.Elements("File").Where(f => f.Value == "(Mod Art Dependency File)"));

                foreach (XElement xelement13 in enumerable2) {
                    xelement13.Value = text;
                }
            }

            xdocument.Root.Add(xdocument6.Root);
        }

        if (!string.IsNullOrWhiteSpace(LocalizedTextData)) {
            var xdocument7 = XDocument.Parse(LocalizedTextData);

            xdocument.Root.Add(xdocument7.Root);
        }

        if (Files != null) {
            XElement xelement14 = new("Files");

            xdocument.Root.Add(xelement14);

            Uri uri4 = new Uri(TargetPath);
            foreach (var (metadata, text9) in from ITaskItem taskItem2 in Files
                                              let metadata = taskItem2.GetMetadata("FullPath")
                                              let uri5 = new Uri(metadata)
                                              let uri6 = uri4.MakeRelativeUri(uri5)
                                              let text9 = Uri.UnescapeDataString(uri6.ToString())
                                              select (metadata, text9)) {
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
