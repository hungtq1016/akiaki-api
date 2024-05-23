namespace Infrastructure.Configurations
{
    public class TreatmentDetailConfiguration : BaseEntityTypeConfiguration<TreatmentDetail>
    {
        public override void Configure(EntityTypeBuilder<TreatmentDetail> builder)
        {
            builder.Property(e => e.TreatmentId).HasColumnType("varchar")
                    .HasMaxLength(36)
                    .HasDefaultValueSql(Constants.UuidAlgorithm)
                    .IsRequired(true);

            builder.Property(e => e.ActivityId).HasColumnType("varchar")
                    .HasMaxLength(36)
                    .HasDefaultValueSql(Constants.UuidAlgorithm)
                    .IsRequired(true);

            base.Configure(builder);

        }
    }
}
