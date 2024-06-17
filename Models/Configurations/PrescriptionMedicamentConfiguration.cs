using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c11.Models.Configurations;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder
            .HasKey(e => new { e.IdPrescription, e.IdMedicament })
            .HasName("PreMed_pk");

        builder
            .Property(e => e.Details)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.Dose)
            .IsRequired();

        builder
            .HasOne<Medicament>()
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdMedicament)
            .HasConstraintName("PrescriptionMedicamen_Medicament")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<Prescription>()
            .WithMany(e => e.PrescriptionMedicaments)
            .HasForeignKey(e => e.IdPrescription)
            .HasConstraintName("PrescriptionMedicament_Prescriptions")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .ToTable("Prescription_Medicament");
    }
}