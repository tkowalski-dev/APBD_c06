using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_c06.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    [Required]
    public int IdMedicament { get; set; }
    
    [Required]
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    
    [Required]
    public int IdPrescription { get; set; }
    
    [Required]
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Details { get; set; } = null!;
}