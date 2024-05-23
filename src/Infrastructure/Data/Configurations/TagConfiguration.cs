namespace Infrastructure.Configurations
{
    public class TagConfiguration : BaseEntityTypeConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {

            builder.HasMany(tag => tag.Blogs)
                .WithOne(blogtag => blogtag.Tag)
                .HasForeignKey(blogtag => blogtag.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
