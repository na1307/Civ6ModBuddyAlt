using System.Xml.Linq;

namespace Civ6ModBuddyAlt.Projects;

public class FrontEndActions(Civ6ProjectNode projectMgr) : ProjectCollection<FrontEndAction>(projectMgr, "FrontEndActionData") {
    protected override string Serialize(IEnumerable<FrontEndAction> items) {
        XDocument xdocument = new(new XElement("FrontEndActions"));
        foreach (var (frontEndAction, xelement) in from FrontEndAction frontEndAction in items
                                                   let xelement = new XElement(frontEndAction.Type)
                                                   select (frontEndAction, xelement)) {
            xelement.SetAttributeValue("id", frontEndAction.Id);

            if (frontEndAction.Properties != null && frontEndAction.Properties.Count > 0) {
                XElement xelement2 = new XElement("Properties");
                xelement2.Add(frontEndAction.Properties.Select((BasicProperty p) => new XElement(p.Name, p.Value)));
                xelement.Add(xelement2);
            }

            if (frontEndAction.Files != null) {
                foreach (var (actionFile, xelement3) in from ActionFile actionFile in frontEndAction.Files
                                                        let xelement3 = new XElement("File", actionFile.File)
                                                        select (actionFile, xelement3)) {
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

    protected override IEnumerable<FrontEndAction> Deserialize(string data) {
        List<FrontEndAction> list = [];

        if (!string.IsNullOrWhiteSpace(data)) {
            XDocument xdocument = XDocument.Parse(data);

            if (xdocument != null) {
                foreach (var (xelement, frontEndAction, xelement2) in from XElement xelement in xdocument.Root.Elements()
                                                                      let frontEndAction = new FrontEndAction() {
                                                                          Type = xelement.Name.LocalName,
                                                                          Id = xelement.Attribute("id").Value
                                                                      }
                                                                      let xelement2 = xelement.Element("Properties")
                                                                      select (xelement, frontEndAction, xelement2)) {
                    if (xelement2 != null) {
                        foreach (XElement xelement3 in xelement2.Elements()) {
                            frontEndAction.Properties.Add(new BasicProperty {
                                Name = xelement3.Name.LocalName,
                                Value = xelement3.Value
                            });
                        }
                    }

                    foreach (var (xelement4, num) in from XElement xelement4 in xelement.Elements("File")
                                                     let xattribute = xelement4.Attribute("priority")
                                                     let num = (xattribute != null) ? int.Parse(xattribute.Value) : 0
                                                     select (xelement4, num)) {
                        frontEndAction.Files.Add(new ActionFile {
                            File = xelement4.Value,
                            Priority = num
                        });
                    }

                    list.Add(frontEndAction);
                }
            }
        }

        return list;
    }
}
