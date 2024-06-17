using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c11.Models.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasKey(e => e.IdPatient)
            .HasName("Pat_pk");

        builder
            .Property(e => e.IdPatient)
            .ValueGeneratedNever();

        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.BirthDay)
            .IsRequired();

        builder.ToTable("Patient");
    }
}