using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Properties;

public partial class AssociationsUserControl : UserControl {
    private readonly BindingList<ModAssociation> _Associations;
    private readonly Civ6ProjectNode projectMgr;

    public AssociationsUserControl(Civ6ProjectNode projectManager) {
        projectMgr = projectManager;
        _Associations = projectMgr.ModAssociations;
        _Associations.ListChanged += _Associations_ListChanged;
        InitializeComponent();
        dependenciesDataGridView.AutoGenerateColumns = false;
        referencesDataGridView.AutoGenerateColumns = false;
        blockersDataGridView.AutoGenerateColumns = false;
        dependenciesDataGridView.DataSource = _Associations.Where((ModAssociation a) => a.Kind == "Dependency").ToList();
        referencesDataGridView.DataSource = _Associations.Where((ModAssociation a) => a.Kind == "Reference").ToList();
        blockersDataGridView.DataSource = _Associations.Where((ModAssociation a) => a.Kind == "Block").ToList();
    }

    private void _Associations_ListChanged(object sender, ListChangedEventArgs e) {
        dependenciesDataGridView.AutoGenerateColumns = false;
        referencesDataGridView.AutoGenerateColumns = false;
        blockersDataGridView.AutoGenerateColumns = false;
        dependenciesDataGridView.DataSource = _Associations.Where((ModAssociation a) => a.Kind == "Dependency").ToList();
        referencesDataGridView.DataSource = _Associations.Where((ModAssociation a) => a.Kind == "Reference").ToList();
        blockersDataGridView.DataSource = _Associations.Where((ModAssociation a) => a.Kind == "Block").ToList();
    }

    private void dependenciesDataGridView_SelectionChanged(object sender, EventArgs e) {
        removeSelectedDependencyButton.Enabled = dependenciesDataGridView.SelectedRows.Count > 0;
    }

    private void addModDependencyButton_Click(object sender, EventArgs e) {
        using (addModAssociationDialog addModAssociationDialog = new()) {
            if (addModAssociationDialog.ShowDialog() == DialogResult.OK) {
                ModAssociation value = addModAssociationDialog.Value;
                value.Kind = "Dependency";
                _Associations.Add(value);
            }
        }
    }

    private void addDlcDependencyButton_Click(object sender, EventArgs e) {
        using (AddDlcAssociationDialog addDlcAssociationDialog = new()) {
            if (addDlcAssociationDialog.ShowDialog() == DialogResult.OK) {
                ModAssociation value = addDlcAssociationDialog.Value;
                value.Kind = "Dependency";
                _Associations.Add(value);
            }
        }
    }

    private void removeSelectedDependencyButton_Click(object sender, EventArgs e) {
        foreach (object obj in dependenciesDataGridView.SelectedRows) {
            DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
            if (!dataGridViewRow.IsNewRow) {
                ModAssociation modAssociation = dataGridViewRow.DataBoundItem as ModAssociation;
                _Associations.Remove(modAssociation);
            }
        }
    }

    private void referencesDataGridView_SelectionChanged(object sender, EventArgs e) {
        removeSelectedReferenceButton.Enabled = referencesDataGridView.SelectedRows.Count > 0;
    }

    private void addModReferenceButton_Click(object sender, EventArgs e) {
        using (addModAssociationDialog addModAssociationDialog = new()) {
            if (addModAssociationDialog.ShowDialog() == DialogResult.OK) {
                ModAssociation value = addModAssociationDialog.Value;
                value.Kind = "Reference";
                _Associations.Add(value);
            }
        }
    }

    private void addDlcReferenceButton_Click(object sender, EventArgs e) {
        using (AddDlcAssociationDialog addDlcAssociationDialog = new()) {
            if (addDlcAssociationDialog.ShowDialog() == DialogResult.OK) {
                ModAssociation value = addDlcAssociationDialog.Value;
                value.Kind = "Reference";
                _Associations.Add(value);
            }
        }
    }

    private void removeSelectedReferenceButton_Click(object sender, EventArgs e) {
        foreach (object obj in referencesDataGridView.SelectedRows) {
            DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
            if (!dataGridViewRow.IsNewRow) {
                ModAssociation modAssociation = dataGridViewRow.DataBoundItem as ModAssociation;
                _Associations.Remove(modAssociation);
            }
        }
    }

    private void blockersDataGridView_SelectionChanged(object sender, EventArgs e) {
        removeSelectedBlockerButton.Enabled = blockersDataGridView.SelectedRows.Count > 0;
    }

    private void addModBlockerButton_Click(object sender, EventArgs e) {
        using (addModAssociationDialog addModAssociationDialog = new()) {
            if (addModAssociationDialog.ShowDialog() == DialogResult.OK) {
                ModAssociation value = addModAssociationDialog.Value;
                value.Kind = "Block";
                _Associations.Add(value);
            }
        }
    }

    private void addDlcBlockerButton_Click(object sender, EventArgs e) {
        using (AddDlcAssociationDialog addDlcAssociationDialog = new()) {
            if (addDlcAssociationDialog.ShowDialog() == DialogResult.OK) {
                ModAssociation value = addDlcAssociationDialog.Value;
                value.Kind = "Block";
                _Associations.Add(value);
            }
        }
    }

    private void removeSelectedBlockerButton_Click(object sender, EventArgs e) {
        foreach (object obj in blockersDataGridView.SelectedRows) {
            DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
            if (!dataGridViewRow.IsNewRow) {
                ModAssociation modAssociation = dataGridViewRow.DataBoundItem as ModAssociation;
                _Associations.Remove(modAssociation);
            }
        }
    }
}
