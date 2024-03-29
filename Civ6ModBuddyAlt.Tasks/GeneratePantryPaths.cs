﻿using Microsoft.Build.Framework;
using System.Text;
using System.Xml;

namespace Civ6ModBuddyAlt.Tasks;

public class GeneratePantryPaths : Microsoft.Build.Utilities.Task {
    [Output]
    public string PantryPath { get; private set; } = string.Empty;

    [Required]
    public string ArtXmlPath { get; set; } = string.Empty;

    [Required]
    public string AssetsPath { get; set; } = string.Empty;

    public override bool Execute() {
        PantryPath = GeneratePaths(AssetsPath, ArtXmlPath);

        return !string.IsNullOrWhiteSpace(PantryPath);
    }

    private static string GeneratePaths(string assetsPath, string artXmlPath) {
        if (string.IsNullOrWhiteSpace(artXmlPath) || !File.Exists(artXmlPath)) {
            return string.Empty;
        }

        StringBuilder stringBuilder = new();
        Queue<GameArtId> queue = new();

        ParseArtXml(artXmlPath, ref queue);

        Dictionary<string, GameArtId> dictionary = new() {
            ["cb2f71b7-843e-4af3-9ca7-992acda9c195"] = new() {
                Id = "cb2f71b7-843e-4af3-9ca7-992acda9c195",
                Name = "Civ6",
                PantryPath = Path.Combine(assetsPath, "Civ6", "pantry")
            },
            ["725760e3-7fc0-4be7-abf1-17bc756d5436"] = new() {
                Id = "725760e3-7fc0-4be7-abf1-17bc756d5436",
                Name = "Shared",
                PantryPath = Path.Combine(assetsPath, "Civ6", "DLC", "Shared", "pantry")
            },
            ["7446c8fe-29eb-44f8-801f-098f681cc5c5"] = new() {
                Id = "7446c8fe-29eb-44f8-801f-098f681cc5c5",
                Name = "Expansion1",
                PantryPath = Path.Combine(assetsPath, "Civ6", "DLC", "Expansion1", "pantry")
            },
            ["b1b63999-6b16-4dd2-a5b6-eb19794aa8ca"] = new() {
                Id = "b1b63999-6b16-4dd2-a5b6-eb19794aa8ca",
                Name = "Expansion2",
                PantryPath = Path.Combine(assetsPath, "Civ6", "DLC", "Expansion2", "pantry")
            },
            ["E05D018D-A6ED-469B-AA5E-5D122693E2EC"] = new() {
                Id = "E05D018D-A6ED-469B-AA5E-5D122693E2EC",
                Name = "CivRoyaleScenario",
                PantryPath = Path.Combine(assetsPath, "Civ6", "DLC", "CivRoyaleScenario", "pantry")
            }
        };

        while (queue.Count != 0) {
            GameArtId gameArtId = queue.Dequeue();

            if (dictionary.TryGetValue(gameArtId.Id, out var gameArtId2)) {
                stringBuilder.Append($" \"{gameArtId2.PantryPath}\"");
                ParseArtXml(Path.Combine(gameArtId2.PantryPath, string.Format("{0}.Art.xml", gameArtId2.Name)), ref queue);
            } else {
                string text6 = Path.Combine(assetsPath, "Civ6", "DLC", gameArtId.Name, "pantry");
                string text7 = Path.Combine(text6, $"{gameArtId.Name}.Art.xml");

                if (File.Exists(text7)) {
                    stringBuilder.Append($" \"{text6}\"");
                    ParseArtXml(text7, ref queue);
                } else {
                    throw new FileNotFoundException(string.Format("Could not find art xml. {0} - {1}", gameArtId.Name, gameArtId.Id));
                }
            }
        }

        return stringBuilder.ToString();
    }

    private static void ParseArtXml(string path, ref Queue<GameArtId> references) {
        string text = LoadXml(path);

        if (!string.IsNullOrWhiteSpace(text)) {
            XmlDocument xmlDocument = new();

            xmlDocument.LoadXml(text);

            XmlNodeList xmlNodeList = xmlDocument.DocumentElement.SelectNodes("requiredGameArtIDs/Element");

            if (xmlNodeList != null) {
                foreach (var (innerText, innerText2) in from XmlNode xmlNode in xmlNodeList
                                                        where xmlNode != null
                                                        let xmlNode2 = xmlNode.SelectSingleNode("name")
                                                        let xmlNode3 = xmlNode.SelectSingleNode("id")
                                                        where xmlNode2 != null && xmlNode3 != null
                                                        let innerText = xmlNode2.Attributes["text"].InnerText
                                                        let innerText2 = xmlNode3.Attributes["text"].InnerText
                                                        where !string.IsNullOrWhiteSpace(innerText) && !string.IsNullOrWhiteSpace(innerText2)
                                                        select (innerText, innerText2)) {
                    references.Enqueue(new GameArtId(innerText, innerText2, string.Empty));
                }
            }
        }
    }

    private static string LoadXml(string path) => File.ReadAllText(path).Replace("\0", " ").Replace("AssetObjects::GameArtSpecification", "AssetObjects..GameArtSpecification").TrimEnd(Environment.NewLine.ToCharArray());
}
