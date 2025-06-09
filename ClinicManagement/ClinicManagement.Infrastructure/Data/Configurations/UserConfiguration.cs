using ClinicManagement.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Data.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(u => u.UserId);

      builder.Property(u => u.Username)
          .IsRequired()
          .HasMaxLength(50);

      builder.Property(u => u.PasswordHash)
          .IsRequired()
          .HasMaxLength(255);

      builder.Property(u => u.Email)
          .IsRequired()
          .HasMaxLength(100);

      builder.Property(u => u.FirstName)
          .IsRequired()
          .HasMaxLength(50);

      builder.Property(u => u.LastName)
          .IsRequired()
          .HasMaxLength(50);

      builder.HasIndex(u => u.Username).IsUnique();
      builder.HasIndex(u => u.Email).IsUnique();

      // Define relationships
      builder.HasOne(u => u.Doctor)
          .WithOne(d => d.User)
          .HasForeignKey<Doctor>(d => d.UserId)
          .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
