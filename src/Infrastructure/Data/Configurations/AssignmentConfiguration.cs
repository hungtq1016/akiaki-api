namespace Infrastructure.Configurations
{
    public class AssignmentConfiguration : BaseEntityTypeConfiguration<Assignment>
    {
        public override void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(e => e.PermissionId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(e => e.RoleId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
