using EnvDTE;
using Microsoft.VisualStudio.Project;
using Microsoft.VisualStudio.Project.Automation;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using VSLangProj;

namespace Civ6ModBuddyAlt.Projects;

public class Civ6ProjectNode : ProjectNode {
    internal static int imageIndex;
    private static Civ6ProjectNode? instance;
    private static readonly object padlock = new();
    private static readonly ImageList imageList = Utilities.GetImageList(typeof(Civ6ProjectNode).Assembly.GetManifestResourceStream("Civ6ModBuddyAlt.Civ6Project.bmp"));
    private readonly BindingList<ModAssociation> modAssociations = [];
    private VSProject? vsProject;
    private string? _currentModAssociationsProperty;

    private Civ6ProjectNode(Civ6ModBuddyAltPackage package) : base(package) {
        CanFileNodesHaveChilds = true;
        SupportsProjectDesigner = true;
        CanProjectDeleteItems = true;
        InitializeImageList();
        ProjectPropertyChanged += Civ6ProjectNode_OnProjectPropertyChanged;
        modAssociations.ListChanged += modAssociations_ListChanged;
    }

    public static Civ6ProjectNode CreateInstance(Civ6ModBuddyAltPackage package) {
        lock (padlock) {
            instance = new(package);

            return instance;
        }
    }

    public static Civ6ProjectNode Instance {
        get {
            lock (padlock) {
                if (instance == null) {
                    throw new InvalidOperationException("Instance is empty.");
                } else {
                    return instance;
                }
            }
        }
    }

    public BindingList<ModAssociation> ModAssociations => modAssociations;

    public override Guid ProjectGuid => new(Civ6ModBuddyAltPackage.Civ6ProjectFactoryGuidString);
    public override string ProjectType => Civ6ModBuddyAltPackage.ProjectTypeName;
    public override int ImageIndex => imageIndex;

    public string GetProjectProperty(string propertyName) => GetProjectProperty(propertyName, _PersistStorageType.PST_PROJECT_FILE);
    public void SetProjectProperty(string propertyName, string propertyValue) => SetProjectProperty(propertyName, _PersistStorageType.PST_PROJECT_FILE, propertyValue);

    public void SetProjectXmlProperty(string name, string xml) {
        if (!string.IsNullOrWhiteSpace(xml)) {
            SetProjectProperty(name, "<![CDATA[" + xml + "]]>");
            return;
        }

        SetProjectProperty(name, string.Empty);
    }

    public override void AddFileFromTemplate(string source, string target) {
        if (!File.Exists(source)) {
            throw new FileNotFoundException($"Template file not found: {source}");
        }

        if (source.EndsWith(".Art.xml", StringComparison.CurrentCultureIgnoreCase)) {
            Civ6ProjectShellSettings civ6ProjectShellSettings = (Civ6ProjectShellSettings)base.GetService(typeof(Civ6ProjectShellSettings));
            string text = Path.Combine(civ6ProjectShellSettings.AssetsPath, "Civ6", "DLC", "Shared", "pantry");

            Path.Combine(civ6ProjectShellSettings.AssetsPath, "pantry");

            string text2 = "Civ6";
            string text3 = "cb2f71b7-843e-4af3-9ca7-992acda9c195";

            if (File.Exists(Path.Combine(text, "Shared.Art.xml"))) {
                text2 = "Shared";
                text3 = "725760e3-7fc0-4be7-abf1-17bc756d5436";
            }

            FileTemplateProcessor.AddReplace("$base-project-name$", text2);
            FileTemplateProcessor.AddReplace("$base-project-guid$", text3);

            try {
                FileTemplateProcessor.UntokenFile(source, target);
                FileTemplateProcessor.Reset();

                return;
            } catch (Exception ex) {
                throw new FileLoadException("Failed to mod Art.xml template file to project", target, ex);
            }
        }

        Directory.CreateDirectory(Path.GetDirectoryName(target));
        File.Copy(source, target);
    }

    public override FileNode CreateFileNode(ProjectElement item) {
        Civ6ProjectFileNode customProjectFileNode;

        if (item.Item.EvaluatedInclude.EndsWith(".Art.xml")) {
            customProjectFileNode = new Civ6ArtFileNode(this, item);
        } else {
            customProjectFileNode = new Civ6ProjectFileNode(this, item);
        }

        customProjectFileNode.OleServiceProvider.AddService(typeof(Project), new ServiceCreatorCallback(CreateServices), false);
        customProjectFileNode.OleServiceProvider.AddService(typeof(ProjectItem), customProjectFileNode.ServiceCreator, false);
        customProjectFileNode.OleServiceProvider.AddService(typeof(VSProject), new ServiceCreatorCallback(CreateServices), false);

        return customProjectFileNode;
    }

    public override void PrepareBuild(string config, string platform, bool cleanBuild) {
        Civ6ProjectShellSettings customProjectShellSettings = (Civ6ProjectShellSettings)base.GetService(typeof(Civ6ProjectShellSettings));
        List<char> list = [.. Path.GetInvalidFileNameChars()];

        if (!list.Contains(';')) {
            list.Add(';');
        }

        if (!list.Contains('.')) {
            list.Add('.');
        }

        string text = GetProjectProperty("Name");
        text = string.Concat(text.Split(list.ToArray(), StringSplitOptions.RemoveEmptyEntries));

        BuildProject.SetGlobalProperty("Civ6_AssetsPath", customProjectShellSettings.AssetsPath);
        BuildProject.SetGlobalProperty("Civ6_GamePath", customProjectShellSettings.GamePath);
        BuildProject.SetGlobalProperty("Civ6_UserPath", customProjectShellSettings.UserPath);
        BuildProject.SetGlobalProperty("Civ6_CookerPath", customProjectShellSettings.CookerPath);
        BuildProject.SetGlobalProperty("SafeName", text);
        base.PrepareBuild(config, platform, cleanBuild);
    }

    public override object GetAutomationObject() => new OACiv6ModProject(this);

    protected override Guid[] GetConfigurationIndependentPropertyPages() => [new(Civ6ModBuddyAltPackage.InfoSettingsPageGuidString), new(Civ6ModBuddyAltPackage.AssociationsSettingsPageGuidString), new(Civ6ModBuddyAltPackage.FrontEndActionsSettingsPageGuidString), new(Civ6ModBuddyAltPackage.InGameActionsSettingsPageGuidString)];
    protected override Guid[] GetPriorityProjectDesignerPages() => [new(Civ6ModBuddyAltPackage.InfoSettingsPageGuidString), new(Civ6ModBuddyAltPackage.AssociationsSettingsPageGuidString), new(Civ6ModBuddyAltPackage.FrontEndActionsSettingsPageGuidString), new(Civ6ModBuddyAltPackage.InGameActionsSettingsPageGuidString)];
    protected override ReferenceContainerNode? CreateReferenceContainerNode() => null;

    protected override void Reload() {
        base.Reload();
        ParseModAssociationsXml(GetProjectProperty("AssociationData"), modAssociations);
    }

    protected override bool IsItemTypeFileType(string type) => string.Compare(type, Civ6ProjectBuildAction.Content.ToString(), StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(type, Civ6ProjectBuildAction.ArtDef.ToString(), StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(type, Civ6ProjectBuildAction.XLP.ToString(), StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(type, Civ6ProjectBuildAction.None.ToString(), StringComparison.OrdinalIgnoreCase) == 0;

    protected internal VSProject VSProject {
        get {
            vsProject ??= new OAVSProject(this);

            return vsProject;
        }
    }

    private void Civ6ProjectNode_OnProjectPropertyChanged(object sender, ProjectPropertyChangedArgs e) {
        if (e.PropertyName == "AssociationData") {
            string text = e.NewValue;

            if (!string.IsNullOrWhiteSpace(text) && text.StartsWith("<![CDATA[")) {
                text = text.Replace("<![CDATA[", "");
                text = text.Remove(text.Length - 3);
            }

            if (text != _currentModAssociationsProperty) {
                ParseModAssociationsXml(text, modAssociations);
            }
        }
    }

    private void modAssociations_ListChanged(object sender, ListChangedEventArgs e) {
        string text = CreateModAssociationsXml(modAssociations);

        if (_currentModAssociationsProperty == null) {
            BindingList<ModAssociation> bindingList = [];
            ParseModAssociationsXml(GetProjectProperty("AssociationData"), bindingList);
            _currentModAssociationsProperty = CreateModAssociationsXml(bindingList);
        }

        if (_currentModAssociationsProperty != text) {
            _currentModAssociationsProperty = text;
            SetProjectXmlProperty("AssociationData", text);
        }
    }

    private object? CreateServices(Type serviceType) {
        object? obj = null;

        if (typeof(VSProject) == serviceType) {
            obj = VSProject;
        } else if (typeof(Project) == serviceType) {
            obj = GetAutomationObject();
        }

        return obj;
    }

    private void InitializeImageList() {
        imageIndex = ImageHandler.ImageList.Images.Count;

        foreach (object obj in imageList.Images) {
            Image image = (Image)obj;
            ImageHandler.AddImage(image);
        }
    }

    private static string CreateModAssociationsXml(BindingList<ModAssociation> modAssociations) {
        XDocument xdocument = new XDocument(new XElement("Associations"));

        foreach (ModAssociation modAssociation in modAssociations) {
            if (!string.IsNullOrWhiteSpace(modAssociation.Type)) {
                XElement xelement = new XElement(modAssociation.Kind.ToString());
                xelement.SetAttributeValue("type", modAssociation.Type);
                xelement.SetAttributeValue("title", modAssociation.Name);
                xelement.SetAttributeValue("id", modAssociation.Id);

                if (!string.IsNullOrWhiteSpace(modAssociation.MinVersion) && int.Parse(modAssociation.MinVersion) != 0) {
                    xelement.SetAttributeValue("min_version", modAssociation.MinVersion);
                }

                if (!string.IsNullOrWhiteSpace(modAssociation.MaxVersion) && int.Parse(modAssociation.MaxVersion) != 999) {
                    xelement.SetAttributeValue("max_version", modAssociation.MaxVersion);
                }

                xdocument.Root.Add(xelement);
            }
        }

        return xdocument.ToString();
    }

    private static void ParseModAssociationsXml(string modAssociationsXml, BindingList<ModAssociation> bl) {
        bl.RaiseListChangedEvents = false;
        bl.Clear();

        if (!string.IsNullOrWhiteSpace(modAssociationsXml)) {
            XDocument xdocument = XDocument.Parse(modAssociationsXml);

            if (xdocument != null && xdocument.Root != null) {
                foreach (XNode xnode in xdocument.Root.Nodes()) {
                    XElement xelement = (XElement)xnode;
                    string localName = xelement.Name.LocalName;

                    if (localName == "Dependency" || localName == "ReverseDependency" || localName == "ReverseReference" || localName == "Reference" || localName == "Block") {
                        XAttribute xattribute = xelement.Attribute("min_version");
                        XAttribute xattribute2 = xelement.Attribute("max_version");
                        ModAssociation modAssociation = new ModAssociation {
                            Kind = (ModAssociationKind)Enum.Parse(typeof(ModAssociationKind), xelement.Name.LocalName),
                            Type = xelement.Attribute("type").Value,
                            Name = xelement.Attribute("title").Value,
                            Id = xelement.Attribute("id").Value,
                            MinVersion = (xattribute != null) ? xattribute.Value : "0",
                            MaxVersion = (xattribute2 != null) ? xattribute2.Value : "999"
                        };

                        bl.Add(modAssociation);
                    }
                }
            }
        }

        bl.RaiseListChangedEvents = true;
        bl.ResetBindings();
    }
}
