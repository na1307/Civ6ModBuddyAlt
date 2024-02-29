using System.Globalization;
using System.Windows.Controls;

namespace Civ6ModBuddyAlt.Wizards;

public sealed class StringLengthRule : StringNotBeEmptyRule {
    public int MinLength { get; init; } = 0;
    public int MaxLength { get; init; } = 0;

    public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
        var baseValidate = base.Validate(value, cultureInfo);

        if (!baseValidate.IsValid) {
            return baseValidate;
        }

        var sValue = ((string)value).Trim();

        if (sValue.Length < MinLength || sValue.Length > MaxLength) {
            return new ValidationResult(false, $"The length of Value must be between {MinLength} and {MaxLength}.");
        }

        return ValidationResult.ValidResult;
    }
}
