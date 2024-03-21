using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage.Entities;

[Index(nameof (Name), IsUnique = false)]
[Table ("CountryTranslations", Schema = "Geo")]
public class CountryTranslation : BaseTranslation
{
    [ForeignKey("Country")]
    public Guid CountryId { get; set; }
    
    [MaxLength(64)]
    [MinLength(2)]
    [Required]
    public string Name { get; set; }
}