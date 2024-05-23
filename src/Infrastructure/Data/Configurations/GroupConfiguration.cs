namespace Infrastructure.Configurations
{
    public class GroupConfiguration : BaseEntityTypeConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(group => group.UserId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(group => group.RoleId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
