using System.ComponentModel.DataAnnotations;

namespace APBD_c06.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateOnly Birthday { get; set; }

    public IEnumerable<Prescription> Prescriptions { get; set; } = null!;
}
