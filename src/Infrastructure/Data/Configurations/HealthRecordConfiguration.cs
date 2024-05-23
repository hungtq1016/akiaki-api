namespace Infrastructure.Configurations
{
    public class HealthRecordConfiguration : BaseEntityTypeConfiguration<HealthRecord>
    {
        public override void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.Property(entity => entity.PatientId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(entity => entity.DoctorId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.HasMany(e => e.Invoices)
                .WithOne(e => e.HealthRecord)
                .HasForeignKey(e => e.HealthRecordId)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
