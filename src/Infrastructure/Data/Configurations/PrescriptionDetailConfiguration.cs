namespace Infrastructure.Configurations
{
    public class PrescriptionDetailConfiguration : BaseEntityTypeConfiguration<PrescriptionDetail>
    {
        public override void Configure(EntityTypeBuilder<PrescriptionDetail> builder)
        {
            builder.Property(detail => detail.PrescriptionId).HasColumnType("varchar")
                 .HasMaxLength(36)
                 .HasDefaultValueSql(Constants.UuidAlgorithm)
                 .IsRequired(true);

            builder.Property(detail => detail.MedicineId).HasColumnType("varchar")
                    .HasMaxLength(36)
                    .HasDefaultValueSql(Constants.UuidAlgorithm)
                    .IsRequired(true);

            base.Configure(builder);
        }
        
    }
}
