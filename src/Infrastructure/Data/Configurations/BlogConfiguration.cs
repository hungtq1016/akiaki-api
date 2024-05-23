namespace Infrastructure.Configurations
{
    public class BlogConfiguration : BaseEntityTypeConfiguration<Blog>
    {
        public override void Configure(EntityTypeBuilder<Blog> builder)
        {

            builder.Property(blog => blog.CategoryId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.HasMany(blog => blog.Comments)
                .WithOne(comment => comment.Blog)
                .HasForeignKey(comment => comment.BlogId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(blog => blog.Tags)
                .WithOne(blogtag => blogtag.Blog)
                .HasForeignKey(blogtag => blogtag.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
