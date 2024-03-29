﻿using EnvDTE;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Project.Automation;
using Microsoft.VisualStudio.Shell;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace Civ6ModBuddyAlt.Projects;

[ComVisible(true)]
public class Civ6ArtFileNode : Civ6ProjectFileNode {
    private const string baseId = "cb2f71b7-843e-4af3-9ca7-992acda9c195";
    private const string sharedId = "725760e3-7fc0-4be7-abf1-17bc756d5436";
    private const string expansion1Id = "7446c8fe-29eb-44f8-801f-098f681cc5c5";
    private const string expansion2Id = "b1b63999-6b16-4dd2-a5b6-eb19794aa8ca";
    private readonly Dictionary<string, Civ6Pantry> _PantriesById = [];
    private readonly Dictionary<Civ6Pantry, string> _Pantries = [];

    internal Civ6ArtFileNode(ProjectNode root, ProjectElement e) : base(root, e) {
        _PantriesById.Add(baseId, Civ6Pantry.Base);
        _PantriesById.Add(sharedId, Civ6Pantry.Shared);
        _PantriesById.Add(expansion1Id, Civ6Pantry.Expansion1);
        _PantriesById.Add(expansion2Id, Civ6Pantry.Expansion2);
        _Pantries.Add(Civ6Pantry.Base, baseId);
        _Pantries.Add(Civ6Pantry.Shared, sharedId);
        _Pantries.Add(Civ6Pantry.Expansion1, expansion1Id);
        _Pantries.Add(Civ6Pantry.Expansion2, expansion2Id);
    }

    public override int ImageIndex => 31;

    public Civ6Pantry Pantry {
        get {
            ThreadHelper.ThrowIfNotOnUIThread();
            Civ6Pantry civ6Pantry = Civ6Pantry.Base;

            if (GetAutomationObject() is OAFileItem oafileItem) {
                string text;

                if (oafileItem.Document != null) {
                    TextDocument textDocument = (TextDocument)oafileItem.Document.Object("TextDocument");
                    EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
                    text = editPoint.GetText(textDocument.EndPoint);
                } else {
                    text = File.ReadAllText(Url);
                }

                if (!string.IsNullOrWhiteSpace(text)) {
                    text = text.Replace("AssetObjects::GameArtSpecification", "AssetObjects..GameArtSpecification");
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(text);
                    XmlElement xmlElement = (XmlElement)xmlDocument.SelectSingleNode("//requiredGameArtIDs/Element/id");

                    if (xmlElement != null) {
                        string attribute = xmlElement.GetAttribute("text");
                        _PantriesById.TryGetValue(attribute, out civ6Pantry);
                    }
                }
            }

            return civ6Pantry;
        }
        set {
            ThreadHelper.ThrowIfNotOnUIThread();
            OAFileItem oafileItem = (OAFileItem)GetAutomationObject();
            TextDocument textDocument = (TextDocument)oafileItem.Document.Object("TextDocument");
            EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
            string text = editPoint.GetText(textDocument.EndPoint).Replace("AssetObjects::GameArtSpecification", "AssetObjects..GameArtSpecification");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(text);

            XmlElement xmlElement = (XmlElement)xmlDocument.SelectSingleNode("//requiredGameArtIDs/Element/name");
            xmlElement?.SetAttribute("text", value.ToString());

            XmlElement xmlElement2 = (XmlElement)xmlDocument.SelectSingleNode("//requiredGameArtIDs/Element/id");
            xmlElement2?.SetAttribute("text", _Pantries[value]);

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings {
                Indent = true,
                IndentChars = "  ",
                Encoding = Encoding.UTF8
            };

            using StringWriter stringWriter = new StringWriter();
            using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings);

            xmlDocument.WriteTo(xmlWriter);
            xmlWriter.Flush();
            string text2 = stringWriter.GetStringBuilder().ToString();
            editPoint.ReplaceText(textDocument.EndPoint, text2, 0);
        }
    }

    protected override NodeProperties CreatePropertiesObject() => new Civ6ArtFileProperties(this);
}
