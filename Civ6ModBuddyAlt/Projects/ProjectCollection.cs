using System.Collections.Specialized;
using System.ComponentModel;

namespace Civ6ModBuddyAlt.Projects;

public abstract class ProjectCollection<T> : Collection<T> {
    private readonly string PropertyName;
    private readonly Civ6ProjectNode _Project;

    protected ProjectCollection(Civ6ProjectNode projectMgr, string propertyName) {
        _Project = projectMgr;
        PropertyName = propertyName;
        IEnumerable<T> enumerable = Deserialize(Project.GetProjectProperty(PropertyName));
        ClearItems();

        foreach (T t in enumerable) {
            Add(t);
        }

        CollectionChanged += ProjectCollection_CollectionChanged;
        CollectionItemChanged += ProjectCollection_CollectionItemChanged;
    }

    public Civ6ProjectNode Project => _Project;

    private void ProjectCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => Persist();
    private void ProjectCollection_CollectionItemChanged(object sender, PropertyChangedEventArgs e) => Persist();

    private void Persist() {
        string text = Serialize(this);
        string projectProperty = Project.GetProjectProperty(PropertyName);

        if (text != projectProperty) {
            Project.SetProjectXmlProperty(PropertyName, text);
            Project.SetProjectFileDirty(true);
        }
    }

    protected abstract string Serialize(IEnumerable<T> items);

    protected abstract IEnumerable<T> Deserialize(string data);
}
