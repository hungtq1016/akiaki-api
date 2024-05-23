namespace Infrastructure.Configurations
{
    public class RoleConfiguration : BaseEntityTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(role => role.Groups)
                .WithOne(group => group.Role)
                .HasForeignKey(group => group.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(role => role.Assignments)
                .WithOne(assign => assign.Role)
                .HasForeignKey(assign => assign.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
