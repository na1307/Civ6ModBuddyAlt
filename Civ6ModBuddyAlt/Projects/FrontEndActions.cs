using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Civ6ModBuddyAlt.Projects;

public class FrontEndActions(Civ6ProjectNode projectMgr) : ProjectCollection<FrontEndAction>(projectMgr, "FrontEndActionData") {
    protected override string Serialize(IEnumerable<FrontEndAction> items) {
        XDocument xdocument = new XDocument(new XElement("FrontEndActions"));

        foreach (FrontEndAction frontEndAction in items) {
            try {
                XElement xelement = new XElement(frontEndAction.Type);
                xelement.SetAttributeValue("id", frontEndAction.Id);

                if (frontEndAction.Properties != null && frontEndAction.Properties.Count > 0) {
                    XElement xelement2 = new XElement("Properties");
                    xelement2.Add(frontEndAction.Properties.Select((BasicProperty p) => new XElement(p.Name, p.Value)));
                    xelement.Add(xelement2);
                }

                if (frontEndAction.Files != null) {
                    foreach (ActionFile actionFile in frontEndAction.Files) {
                        XElement xelement3 = new XElement("File", actionFile.File);

                        if (actionFile.Priority != 0) {
                            xelement3.SetAttributeValue("priority", actionFile.Priority);
                        }

                        xelement.Add(xelement3);
                    }
                }

                xdocument.Root.Add(xelement);
            } catch {
            }
        }

        return xdocument.ToString(SaveOptions.DisableFormatting);
    }

    protected override IEnumerable<FrontEndAction> Deserialize(string xml) {
        List<FrontEndAction> list = [];

        if (!string.IsNullOrWhiteSpace(xml)) {
            XDocument xdocument = XDocument.Parse(xml);

            if (xdocument != null) {
                foreach (XElement xelement in xdocument.Root.Elements()) {
                    try {
                        FrontEndAction frontEndAction = new() {
                            Type = xelement.Name.LocalName,
                            Id = xelement.Attribute("id").Value
                        };
                        XElement xelement2 = xelement.Element("Properties");

                        if (xelement2 != null) {
                            foreach (XElement xelement3 in xelement2.Elements()) {
                                frontEndAction.Properties.Add(new BasicProperty {
                                    Name = xelement3.Name.LocalName,
                                    Value = xelement3.Value
                                });
                            }
                        }

                        foreach (XElement xelement4 in xelement.Elements("File")) {
                            XAttribute xattribute = xelement4.Attribute("priority");
                            int num = (xattribute != null) ? int.Parse(xattribute.Value) : 0;

                            frontEndAction.Files.Add(new ActionFile {
                                File = xelement4.Value,
                                Priority = num
                            });
                        }

                        list.Add(frontEndAction);
                    } catch {
                    }
                }
            }
        }
        return list;
    }
}
