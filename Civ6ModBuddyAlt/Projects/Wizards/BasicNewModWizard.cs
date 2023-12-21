using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Civ6ModBuddyAlt.Projects.Wizards;

public class BasicNewModWizard : IWizard {
    public void BeforeOpeningFile(ProjectItem projectItem) { }

    public void ProjectFinishedGenerating(Project project) { }

    public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }

    public void RunFinished() { }

    public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams) {
        try {
            NewModWizard newModWizard = new NewModWizard();
            GeneralInfoPage generalInfoPage = new GeneralInfoPage();

            newModWizard.Pages.Add(generalInfoPage);

            if (newModWizard.ShowDialog() != DialogResult.OK) {
                throw new WizardCancelledException("The wizard has been canceled by the user.");
            }

            string modDescription = generalInfoPage.ModDescription;
            string text = modDescription;

            if (text.Length > 127) {
                text = text.Substring(0, 127);
            }

            replacementsDictionary["$Name$"] = CleanString(generalInfoPage.ModTitle);
            replacementsDictionary["$Teaser$"] = CleanString(text);
            replacementsDictionary["$Description$"] = CleanString(modDescription);
            replacementsDictionary["$Authors$"] = CleanString(generalInfoPage.ModAuthors);
            replacementsDictionary["$SpecialThanks$"] = CleanString(generalInfoPage.ModSpecialThanks);
        } catch (WizardCancelledException e) {
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }

        static string CleanString(string value) => value == null ? string.Empty : value.Trim();
    }

    public bool ShouldAddProjectItem(string filePath) => true;
}
