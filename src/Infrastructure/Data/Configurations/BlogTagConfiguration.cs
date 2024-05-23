namespace Infrastructure.Configurations
{
    public class BlogTagConfiguration : BaseEntityTypeConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> builder)
        {

            builder.Property(blogTag => blogTag.TagId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(blogTag => blogTag.BlogId).HasColumnType("varchar")
                 .HasMaxLength(36)
                 .HasDefaultValueSql(Constants.UuidAlgorithm)
                 .IsRequired(true);

            base.Configure(builder);

        }
    }
}
