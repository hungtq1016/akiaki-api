namespace Infrastructure.Configurations
{
    public class GroupServiceConfiguration : BaseEntityTypeConfiguration<GroupService>
    {
        public override void Configure(EntityTypeBuilder<GroupService> builder)
        {
            builder.HasMany(group => group.Services)
                .WithOne(service => service.Group)
                .HasForeignKey(service => service.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
