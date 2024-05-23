namespace Infrastructure.Configurations
{
    public class GroupUrlConfiguration : BaseEntityTypeConfiguration<GroupUrl>
    {
        public override void Configure(EntityTypeBuilder<GroupUrl> builder)
        {

            builder.HasMany(groupurl => groupurl.Urls)
                .WithOne(url => url.Group)
                .HasForeignKey(url => url.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
