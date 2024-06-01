namespace APBD_c06.Context;

using APBD_c06.Models;
using Microsoft.EntityFrameworkCore;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost,1434;Initial Catalog=master;User ID=sa;Password=yourStrong(!)Password;Encrypt=False");


    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
}
