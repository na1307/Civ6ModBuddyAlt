using System.Xml.Linq;

namespace Civ6ModBuddyAlt.Projects;

public class InGameActions(Civ6ProjectNode projectMgr) : ProjectCollection<InGameAction>(projectMgr, "InGameActionData") {
    protected override string Serialize(IEnumerable<InGameAction> items) {
        XDocument xdocument = new(new XElement("InGameActions"));

        foreach (var (inGameAction, xelement) in from InGameAction inGameAction in items
                                                 let xelement = new XElement(inGameAction.Type)
                                                 select (inGameAction, xelement)) {
            xelement.SetAttributeValue("id", inGameAction.Id);
            if (inGameAction.Properties != null && inGameAction.Properties.Count > 0) {
                XElement xelement2 = new XElement("Properties");

                xelement2.Add(inGameAction.Properties.Select((BasicProperty p) => new XElement(p.Name, p.Value)));
                xelement.Add(xelement2);
            }

            if (inGameAction.Criteria != null) {
                xelement.Add(inGameAction.Criteria.Select((string c) => new XElement("Criteria", c)));
            }

            if (inGameAction.References != null) {
                xelement.Add(inGameAction.References.Select((ActionReference r) => new XElement(r.Type, new XAttribute("mod_id", r.ModId), new XAttribute("action_id", r.ActionId))));
            }

            if (inGameAction.Files != null) {
                foreach (ActionFile actionFile in inGameAction.Files) {
                    XElement xelement3 = new XElement("File", actionFile.File);

                    if (actionFile.Priority != 0) {
                        xelement3.SetAttributeValue("priority", actionFile.Priority);
                    }

                    xelement.Add(xelement3);
                }
            }

            xdocument.Root.Add(xelement);
        }

        return xdocument.ToString(SaveOptions.DisableFormatting);
    }

    protected override IEnumerable<InGameAction> Deserialize(string data) {
        List<InGameAction> list = [];

        if (!string.IsNullOrWhiteSpace(data)) {
            XDocument xdocument = XDocument.Parse(data);

            if (xdocument != null) {
                foreach (var (xelement, inGameAction, xelement2) in from XElement xelement in xdocument.Root.Elements()
                                                                    let inGameAction = new InGameAction() {
                                                                        Type = xelement.Name.LocalName,
                                                                        Id = xelement.Attribute("id").Value
                                                                    }
                                                                    let xelement2 = xelement.Element("Properties")
                                                                    select (xelement, inGameAction, xelement2)) {
                    if (xelement2 != null) {
                        foreach (XElement xelement3 in xelement2.Elements()) {
                            inGameAction.Properties.Add(new BasicProperty {
                                Name = xelement3.Name.LocalName,
                                Value = xelement3.Value
                            });
                        }
                    }

                    foreach (XElement xelement4 in xelement.Elements("Criteria")) {
                        inGameAction.Criteria.Add(xelement4.Value);
                    }

                    foreach (var (xelement5, num) in from XElement xelement5 in xelement.Elements("File")
                                                     let xattribute = xelement5.Attribute("priority")
                                                     let num = (xattribute != null) ? int.Parse(xattribute.Value) : 0
                                                     select (xelement5, num)) {
                        inGameAction.Files.Add(new ActionFile {
                            File = xelement5.Value,
                            Priority = num
                        });
                    }

                    foreach (var (xelement6, localName) in from XElement xelement6 in xelement.Elements()
                                                           let localName = xelement6.Name.LocalName
                                                           where localName == "Include" || localName == "Exclude" || localName == "Requires" || localName == "ConflictsWith"
                                                           select (xelement6, localName)) {
                        inGameAction.References.Add(new ActionReference {
                            Type = localName,
                            ModId = xelement6.Attribute("mod_id").Value,
                            ActionId = xelement6.Attribute("action_id").Value
                        });
                    }

                    list.Add(inGameAction);
                }
            }
        }

        return list;
    }
}
