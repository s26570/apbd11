using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c11.Models.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder
            .HasKey(x => x.IdPrescription)
            .HasName("Pre_pk");

        builder
            .Property(e => e.IdPrescription)
            .ValueGeneratedNever();

        builder
            .Property(e => e.Date)
            .IsRequired();

        builder
            .Property(e => e.DueDate)
            .IsRequired();

        builder
            .HasOne<Doctor>()
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdDoctor)
            .HasConstraintName("Prescription_Doctor")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<Patient>()
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(e => e.IdPatient)
            .HasConstraintName("Prescription_Patient")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .ToTable("Prescription");
    }
}