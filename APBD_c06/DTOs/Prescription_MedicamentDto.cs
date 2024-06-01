using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_c06.DTOs;

public class PrescriptionMedicamentDto
{
    [Required]
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Details { get; set; } = null!;
}
