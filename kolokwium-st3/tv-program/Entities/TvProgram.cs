using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tv_program.Entities;

[Table("TvPrograms", Schema = "TvProgram")]
public class TvProgram
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public bool IsActive { get; set; }
}