using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_c06.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Required]
    public DateOnly Date { get; set; }
    
    [Required]
    public DateOnly DueDate { get; set; }
    
    public int IdDoctor { get; set; }

    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }

    public int IdPatient { get; set; }

    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = null!;
}
