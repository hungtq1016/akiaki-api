namespace Infrastructure.Configurations
{
    public class BranchConfiguration : BaseEntityTypeConfiguration<Branch>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(e => e.TypeId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.HasMany(e => e.Schedules)
                .WithOne(e => e.Branch)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
