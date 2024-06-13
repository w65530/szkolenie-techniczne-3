using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tv_show.Entities;

[Table("TvShows", Schema = "TvShow")]
public class TvShow
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public int TvProgramId { get; set; }
}