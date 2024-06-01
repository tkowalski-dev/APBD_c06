using System.ComponentModel.DataAnnotations;

namespace APBD_c06.DTOs;

public class DoctorDto
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
}
