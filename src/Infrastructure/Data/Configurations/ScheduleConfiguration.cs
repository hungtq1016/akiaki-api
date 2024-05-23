namespace Infrastructure.Configurations
{
    public class ScheduleConfiguration : BaseEntityTypeConfiguration<Schedule>
    {
        public override void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(e => e.BranchId).HasColumnType("varchar")
                 .HasMaxLength(36)
                 .HasDefaultValueSql(Constants.UuidAlgorithm)
                 .IsRequired(true);

            builder.Property(e => e.ServiceId).HasColumnType("varchar")
                    .HasMaxLength(36)
                    .HasDefaultValueSql(Constants.UuidAlgorithm)
                    .IsRequired(true);

            base.Configure(builder);

        }
    }
}
