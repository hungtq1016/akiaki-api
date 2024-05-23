namespace Infrastructure.Configurations
{
    public class PrescriptionConfiguration : BaseEntityTypeConfiguration<Prescription>
    {
        public override void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.Property(prescription => prescription.DoctorId).HasColumnType("varchar")
                 .HasMaxLength(36)
                 .HasDefaultValueSql(Constants.UuidAlgorithm)
                 .IsRequired(true);

            builder.Property(prescription => prescription.PatientId).HasColumnType("varchar")
                    .HasMaxLength(36)
                    .HasDefaultValueSql(Constants.UuidAlgorithm)
                    .IsRequired(true);

            builder.HasMany(prescription => prescription.Details)
                .WithOne(detail => detail.Prescription)
                .HasForeignKey(locale => locale.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }

    }
}
