using System.Globalization;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Wizards;

public class StringNotBeEmptyRule : ValidationRule {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo) => !string.IsNullOrWhiteSpace((string)value) ? ValidationResult.ValidResult : new(false, "The Value cannot be empty.");
}
