using System.ComponentModel.DataAnnotations;

namespace APBD_c06.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string Email { get; set; } = null!;

    public IEnumerable<Prescription> Prescriptions { get; set; } = null!;
}
