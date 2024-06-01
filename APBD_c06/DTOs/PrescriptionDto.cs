using APBD_c06.Models;

namespace APBD_c06.DTOs;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public string Date { get; set; } = null!;
    public string DueDate { get; set; } = null!;
    public DoctorDto Doctor { get; set; } = null!;
    public PatientDto Patient { get; set; } = null!;
    public IEnumerable<PrescriptionMedicamentDto> Medicaments { get; set; } = null!;
}
