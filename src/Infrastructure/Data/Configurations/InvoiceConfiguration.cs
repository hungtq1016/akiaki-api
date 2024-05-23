namespace Infrastructure.Configurations
{
    public class InvoiceConfiguration : BaseEntityTypeConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(e => e.PatientId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(e => e.NurseId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

             builder.Property(e => e.HealthRecordId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.HasMany(e => e.InvoiceDetails)
                .WithOne(e => e.Invoice)
                .HasForeignKey(e => e.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            base.Configure(builder);

        }
    }
}
