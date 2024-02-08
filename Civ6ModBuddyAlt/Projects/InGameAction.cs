using System.Collections.Specialized;

namespace Civ6ModBuddyAlt.Projects;

public class InGameAction : Action {
    public InGameAction() {
        Criteria.CollectionChanged += Criteria_CollectionChanged;
        Criteria.CollectionItemChanged += Criteria_CollectionItemChanged;
        References.CollectionChanged += References_CollectionChanged;
        References.CollectionItemChanged += References_CollectionItemChanged;
    }

    public Collection<string> Criteria { get; } = [];
    public Collection<ActionReference> References { get; } = [];

    private void Criteria_CollectionItemChanged(object sender, EventArgs e) => OnPropertyChanged(nameof(Criteria));
    private void Criteria_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(Criteria));
    private void References_CollectionItemChanged(object sender, EventArgs e) => OnPropertyChanged(nameof(References));
    private void References_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(References));
}
