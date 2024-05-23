namespace Infrastructure.Configurations
{
    public class PermissionConfiguration : BaseEntityTypeConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasMany(permission => permission.Assignments)
                .WithOne(assign => assign.Permission)
                .HasForeignKey(assign => assign.PermissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
