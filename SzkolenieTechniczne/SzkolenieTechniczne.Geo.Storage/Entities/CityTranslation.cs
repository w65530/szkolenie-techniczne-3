using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage.Entities;

[Index (nameof(Name), IsUnique = false)]
[Table ("CityTranslations", Schema = "Geo")]
public class CityTranslation : BaseTranslation
{
    [ForeignKey("City")]
    public Guid CityId { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
}