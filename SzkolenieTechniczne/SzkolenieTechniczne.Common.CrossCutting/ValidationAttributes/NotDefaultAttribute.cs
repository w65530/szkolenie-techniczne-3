using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes;


[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public class NotDefaultAttribute : ValidationAttribute
{
    public const string DefaultErrorMessage = "The {0} field must not be the default value.";
    
    public NotDefaultAttribute() : base(DefaultErrorMessage)
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success!;
        }

        var type = value.GetType();
        if (type.IsValueType)
        {
            var defaultValue = Activator.CreateInstance(type);
            return !value.Equals(defaultValue) ? ValidationResult.Success! : new ValidationResult("VALUE_IS_REQUIRED");
        }
        
        return ValidationResult.Success!;
    }
}