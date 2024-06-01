using System.ComponentModel.DataAnnotations;

namespace APBD_c06.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string Description { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string Type { get; set; } = null!;

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}
