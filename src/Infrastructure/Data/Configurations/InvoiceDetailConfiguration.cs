namespace Infrastructure.Configurations
{
    public class InvoiceDetailConfiguration : BaseEntityTypeConfiguration<InvoiceDetail>
    {
        public override void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.Property(e => e.InvoiceId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(e => e.ServicePriceId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
