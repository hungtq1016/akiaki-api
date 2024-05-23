namespace Infrastructure.Configurations
{
    public class ServiceConfiguration : BaseEntityTypeConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(service => service.GroupId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.HasMany(e => e.Schedules)
                .WithOne(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
