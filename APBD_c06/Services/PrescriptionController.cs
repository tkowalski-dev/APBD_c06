using APBD_c06.Context;
using APBD_c06.DTOs;
using APBD_c06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_c06.Services;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly MasterContext _dbContext;

    public PrescriptionController(MasterContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PrescriptionDto sentData)
    {
        Prescription newPrescription = new();

        DateOnly dueDate;
        if (!DateOnly.TryParse(sentData.DueDate, out dueDate))
        {
            return BadRequest("Cannot parse DueData!");
        }

        newPrescription.DueDate = dueDate;

        DateOnly date;
        if (!DateOnly.TryParse(sentData.Date, out date))
        {
            return BadRequest("Cannot parse Data!");
        }

        newPrescription.Date = date;

        if (newPrescription.DueDate < newPrescription.Date)
        {
            return BadRequest("DueData cannot be earlier than Date!");
        }
        
        
        
        Patient? patient = await _dbContext.Patients
            .Where(p => p.IdPatient == sentData.Patient.IdPatient).FirstOrDefaultAsync();

        if (patient is null)
        {
            patient = new Patient
            {
                FirstName = sentData.Patient.FirstName,
                LastName = sentData.Patient.LastName,
                // Birthday = DateOnly.Parse(sentData.Patient.Birthday),
                Prescriptions = new List<Prescription>()
            };

            if (!DateOnly.TryParse(sentData.Patient.Birthday, out date))
            {
                return BadRequest("Cannot parse Patient.Data!");
            }

            patient.Birthday = date;
            
        }

        newPrescription.Patient = patient;
        // newPrescription.IdPatient = patient.IdPatient;


        
        Doctor? doctor = await _dbContext.Doctors
            .Where(d => d.IdDoctor == sentData.Doctor.IdDoctor).FirstOrDefaultAsync();
        
        if (doctor is null)
        {
            return BadRequest("Doctor does not exists!");
        }

        newPrescription.Doctor = doctor;
        // newPrescription.IdDoctor = doctor.IdDoctor;
        
        
        
        if (newPrescription.PrescriptionMedicaments.Count > 10)
        {
            return BadRequest("Too many medicaments!");
        }

        sentData.Medicaments = sentData.Medicaments
            .GroupBy(m => m.IdMedicament)
            .Select(m => m.First())
            .ToList();
        
        foreach (PrescriptionMedicamentDto med in sentData.Medicaments)
        {
            Medicament? newMed = _dbContext.Medicaments.FirstOrDefault(m => m.IdMedicament == med.IdMedicament);
            
            if (newMed is null)
            {
                return BadRequest($"No such medicament with id {med.IdMedicament}!");
            }

            PrescriptionMedicament pm = new()
            {
                Medicament = newMed,
                Dose = med.Dose,
                Details = med.Details
            };
            
            newPrescription.PrescriptionMedicaments.Add(pm);
        }
        
        
        
        await _dbContext.Patients.AddAsync(patient);
        await _dbContext.Prescriptions.AddAsync(newPrescription);
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }
}
