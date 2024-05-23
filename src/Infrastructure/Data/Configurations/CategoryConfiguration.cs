namespace Infrastructure.Configurations
{
    public class CategoryConfiguration : BaseEntityTypeConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasMany(category => category.Blogs)
                .WithOne(comment => comment.Category)
                .HasForeignKey(comment => comment.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
