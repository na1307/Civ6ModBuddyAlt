using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;

namespace Civ6ModBuddyAlt.Wizards;

internal sealed class BasicNewModWizard : IWizard {
    public void BeforeOpeningFile(ProjectItem projectItem) { }
    public void ProjectFinishedGenerating(Project project) { }
    public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }
    public void RunFinished() { }

    public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams) {
        WizardWindow window = new();

        if (!window.ShowDialog().GetValueOrDefault()) {
            throw new WizardCancelledException("The wizard has been canceled by the user.");
        }

        replacementsDictionary["$Name$"] = cleanString(window.ModTitle);
        replacementsDictionary["$Teaser$"] = cleanString(window.ModDescription?.Length > 127 ? window.ModDescription.Substring(0, 127) : window.ModDescription);
        replacementsDictionary["$Description$"] = cleanString(window.ModDescription);
        replacementsDictionary["$Authors$"] = cleanString(window.ModAuthors);
        replacementsDictionary["$SpecialThanks$"] = cleanString(window.ModSpecialThanks);

        static string cleanString(string value) => value == null ? string.Empty : value.Trim();
    }

    public bool ShouldAddProjectItem(string filePath) => true;
}
