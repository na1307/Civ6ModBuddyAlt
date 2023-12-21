using Microsoft.Build.Framework;
using System.Text;
using System.Xml;

namespace Civ6ModBuddyAlt.Tasks;

public class GeneratePantryPaths : Microsoft.Build.Utilities.Task {
    private string pantryPath = string.Empty;

    [Output]
    public string PantryPath => pantryPath;

    [Required]
    public string ArtXmlPath { get; set; }

    [Required]
    public string AssetsPath { get; set; }

    public override bool Execute() {
        pantryPath = GeneratePaths(AssetsPath, ArtXmlPath);

        return !string.IsNullOrWhiteSpace(pantryPath);
    }

    private static string GeneratePaths(string assetsPath, string artXmlPath) {
        if (string.IsNullOrWhiteSpace(artXmlPath) || !File.Exists(artXmlPath)) {
            return string.Empty;
        }

        StringBuilder stringBuilder = new StringBuilder();
        Queue<GameArtId> queue = new Queue<GameArtId>();

        ParseArtXml(artXmlPath, ref queue);

        string text = Path.Combine(assetsPath, "Civ6", "DLC", "CivRoyaleScenario", "pantry");
        string text2 = Path.Combine(assetsPath, "Civ6", "DLC", "Expansion2", "pantry");
        string text3 = Path.Combine(assetsPath, "Civ6", "DLC", "Expansion1", "pantry");
        string text4 = Path.Combine(assetsPath, "Civ6", "DLC", "Shared", "pantry");
        string text5 = Path.Combine(assetsPath, "Civ6", "pantry");

        Dictionary<string, GameArtId> dictionary = new() {
            ["cb2f71b7-843e-4af3-9ca7-992acda9c195"] = new() {
                Id = "cb2f71b7-843e-4af3-9ca7-992acda9c195",
                Name = "Civ6",
                PantryPath = text5
            },
            ["725760e3-7fc0-4be7-abf1-17bc756d5436"] = new() {
                Id = "725760e3-7fc0-4be7-abf1-17bc756d5436",
                Name = "Shared",
                PantryPath = text4
            },
            ["7446c8fe-29eb-44f8-801f-098f681cc5c5"] = new() {
                Id = "7446c8fe-29eb-44f8-801f-098f681cc5c5",
                Name = "Expansion1",
                PantryPath = text3
            },
            ["b1b63999-6b16-4dd2-a5b6-eb19794aa8ca"] = new() {
                Id = "b1b63999-6b16-4dd2-a5b6-eb19794aa8ca",
                Name = "Expansion2",
                PantryPath = text2
            },
            ["E05D018D-A6ED-469B-AA5E-5D122693E2EC"] = new() {
                Id = "E05D018D-A6ED-469B-AA5E-5D122693E2EC",
                Name = "CivRoyaleScenario",
                PantryPath = text
            }
        };

        while (queue.Any()) {
            GameArtId gameArtId = queue.Dequeue();

            if (dictionary.TryGetValue(gameArtId.Id, out var gameArtId2)) {
                stringBuilder.Append(string.Format(" \"{0}\"", gameArtId2.PantryPath));
                ParseArtXml(Path.Combine(gameArtId2.PantryPath, string.Format("{0}.Art.xml", gameArtId2.Name)), ref queue);
            } else {
                string text6 = Path.Combine(assetsPath, "Civ6", "DLC", gameArtId.Name, "pantry");
                string text7 = Path.Combine(text6, string.Format("{0}.Art.xml", gameArtId.Name));

                if (File.Exists(text7)) {
                    stringBuilder.Append(string.Format(" \"{0}\"", text6));
                    ParseArtXml(text7, ref queue);
                } else {
                    string.Format("Could not find art xml. {0} - {1}", gameArtId.Name, gameArtId.Id);
                }
            }
        }

        return stringBuilder.ToString();
    }

    private static void ParseArtXml(string path, ref Queue<GameArtId> references) {
        string text = LoadXml(path);

        if (!string.IsNullOrWhiteSpace(text)) {
            XmlDocument xmlDocument = new XmlDocument();

            try {
                xmlDocument.LoadXml(text);

                XmlNode documentElement = xmlDocument.DocumentElement;
                XmlNodeList xmlNodeList = documentElement.SelectNodes("requiredGameArtIDs/Element");

                if (xmlNodeList != null) {
                    for (int i = 0; i < xmlNodeList.Count; i++) {
                        XmlNode xmlNode = xmlNodeList[i];

                        if (xmlNode != null) {
                            XmlNode xmlNode2 = xmlNode.SelectSingleNode("name");
                            XmlNode xmlNode3 = xmlNode.SelectSingleNode("id");

                            if (xmlNode2 != null && xmlNode3 != null) {
                                string innerText = xmlNode2.Attributes["text"].InnerText;
                                string innerText2 = xmlNode3.Attributes["text"].InnerText;

                                if (!string.IsNullOrWhiteSpace(innerText) && !string.IsNullOrWhiteSpace(innerText2)) {
                                    references.Enqueue(new GameArtId {
                                        Name = innerText,
                                        Id = innerText2
                                    });
                                }
                            }
                        }
                    }
                }
            } catch {
            }
        }
    }

    private static string LoadXml(string path) {
        string text = File.ReadAllText(path);
        text = text.Replace("\0", " ");
        text = text.Replace("AssetObjects::GameArtSpecification", "AssetObjects..GameArtSpecification");

        return text.TrimEnd(Environment.NewLine.ToCharArray());
    }
}
