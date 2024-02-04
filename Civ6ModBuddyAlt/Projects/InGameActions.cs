using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Civ6ModBuddyAlt.Projects;

public class InGameActions(Civ6ProjectNode projectMgr) : ProjectCollection<InGameAction>(projectMgr, "InGameActionData") {
    protected override string Serialize(IEnumerable<InGameAction> items) {
        XDocument xdocument = new XDocument(new XElement("InGameActions"));

        foreach (InGameAction inGameAction in items) {
            try {
                XElement xelement = new XElement(inGameAction.Type);

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
            } catch (Exception) {
            }
        }

        return xdocument.ToString(SaveOptions.DisableFormatting);
    }

    protected override IEnumerable<InGameAction> Deserialize(string xml) {
        List<InGameAction> list = [];

        if (!string.IsNullOrWhiteSpace(xml)) {
            XDocument xdocument = XDocument.Parse(xml);

            if (xdocument != null) {
                foreach (XElement xelement in xdocument.Root.Elements()) {
                    try {
                        InGameAction inGameAction = new InGameAction() {
                            Type = xelement.Name.LocalName,
                            Id = xelement.Attribute("id").Value
                        };
                        XElement xelement2 = xelement.Element("Properties");

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

                        foreach (XElement xelement5 in xelement.Elements("File")) {
                            XAttribute xattribute = xelement5.Attribute("priority");
                            int num = (xattribute != null) ? int.Parse(xattribute.Value) : 0;

                            inGameAction.Files.Add(new ActionFile {
                                File = xelement5.Value,
                                Priority = num
                            });
                        }

                        foreach (XElement xelement6 in xelement.Elements()) {
                            string localName = xelement6.Name.LocalName;

                            if (localName == "Include" || localName == "Exclude" || localName == "Requires" || localName == "ConflictsWith") {
                                inGameAction.References.Add(new ActionReference {
                                    Type = localName,
                                    ModId = xelement6.Attribute("mod_id").Value,
                                    ActionId = xelement6.Attribute("action_id").Value
                                });
                            }
                        }

                        list.Add(inGameAction);
                    } catch (Exception) {
                    }
                }
            }
        }

        return list;
    }
}
