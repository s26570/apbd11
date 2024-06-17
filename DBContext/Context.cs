using c11.Models;
using c11.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace c11.DBContext;

public class Context : DbContext
{
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public Context()
    {
    }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;User ID=sa;Password=Haslo12345@;Initial Catalog=master;Integrated Security=False;Persist Security Info=False;Connect Timeout=30;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
    }
}