namespace Infrastructure.Configurations
{
    public class UserConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(e => e.Password)
                .HasDefaultValue(BC.HashPassword("Th1s1sP@ssword"))
                .IsRequired(true);

            builder.HasMany(e => e.Groups)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(e => e.Tokens)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(e => e.Comments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(e => e.Documents)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(e => e.MedicalRecords)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(e => e.PatientRecords)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(e => e.DoctorRecords)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(e => e.Nurses)
                .WithOne(e => e.Nurse)
                .HasForeignKey(e => e.NurseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(e => e.Pantients)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
