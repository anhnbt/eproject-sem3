using ClinicManagement.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Infrastructure.Data.Configurations
{
  public class PatientConfiguration : IEntityTypeConfiguration<Patient>
  {
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
      builder.ToTable("Patients");

      builder.HasKey(p => p.PatientId);

      builder.Property(p => p.FirstName)
          .IsRequired()
          .HasMaxLength(50);

      builder.Property(p => p.LastName)
          .IsRequired()
          .HasMaxLength(50);

      builder.Property(p => p.DateOfBirth)
          .IsRequired();

      builder.Property(p => p.Gender)
          .IsRequired()
          .HasMaxLength(10);

      builder.Property(p => p.PhoneNumber)
          .IsRequired()
          .HasMaxLength(20);

      builder.Property(p => p.Email)
          .HasMaxLength(100);

      // Define relationships
      builder.HasOne(p => p.User)
          .WithMany()
          .HasForeignKey(p => p.UserId)
          .OnDelete(DeleteBehavior.SetNull);

      builder.HasMany(p => p.PatientRecords)
          .WithOne(r => r.Patient)
          .HasForeignKey(r => r.PatientId);

      builder.HasMany(p => p.Appointments)
          .WithOne(a => a.Patient)
          .HasForeignKey(a => a.PatientId);

      builder.HasMany(p => p.Prescriptions)
          .WithOne(pr => pr.Patient)
          .HasForeignKey(pr => pr.PatientId);

      builder.HasMany(p => p.Payments)
          .WithOne(py => py.Patient)
          .HasForeignKey(py => py.PatientId);
    }
  }
}
