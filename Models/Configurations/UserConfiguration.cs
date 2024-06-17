using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c11.Models.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.IdUser)
            .HasName("AU_pk");

        builder
            .Property(u => u.IdUser)
            .ValueGeneratedOnAdd();

        builder
            .Property(u => u.Login)
            .IsRequired();

        builder
            .Property(u => u.Password)
            .IsRequired();

        builder
            .Property(u => u.Salt)
            .IsRequired();

        builder
            .Property(u => u.RefreshToken)
            .IsRequired();

        builder
            .Property(u => u.RefreshTokenExp)
            .IsRequired();

        builder
            .ToTable("AppUser");
    }
}