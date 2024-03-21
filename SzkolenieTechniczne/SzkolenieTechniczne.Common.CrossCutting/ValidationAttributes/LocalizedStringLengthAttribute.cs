using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes;

public class LocalizedStringLengthAttribute : StringLengthAttribute
{
    public LocalizedStringLengthAttribute(int maximumLength) : base(maximumLength)
    {
        
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }

        if (value is LocalizedString localizedString)
        {
            return localizedString.Values.All(languageText => base.IsValid(languageText));
        }

        return false;
    }
}