namespace Infrastructure.Configurations
{
    public class ServicePriceConfiguration : BaseEntityTypeConfiguration<ServicePrice>
    {
        public override void Configure(EntityTypeBuilder<ServicePrice> builder)
        {
            builder.HasMany(e => e.InvoiceDetails)
                .WithOne(e => e.ServicePrice)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
  
            base.Configure(builder);

        }
    }
}
