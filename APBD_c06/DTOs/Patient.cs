using System.ComponentModel.DataAnnotations;
using APBD_c06.Models;

namespace APBD_c06.DTOs;

public class PatientDto
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
    public string Birthday { get; set; }
}
