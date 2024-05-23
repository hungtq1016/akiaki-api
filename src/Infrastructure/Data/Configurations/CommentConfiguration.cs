namespace Infrastructure.Configurations
{
    public class CommentConfiguration : BaseEntityTypeConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(comment => comment.BlogId).HasColumnType("varchar")
               .HasMaxLength(36)
               .HasDefaultValueSql(Constants.UuidAlgorithm)
               .IsRequired(true);

            builder.Property(comment => comment.UserId).HasColumnType("varchar")
               .HasMaxLength(36)
               .HasDefaultValueSql(Constants.UuidAlgorithm)
               .IsRequired(true);

            builder.Property(comment => comment.ParentId).HasColumnType("varchar")
               .HasMaxLength(36)
               .HasDefaultValueSql(Constants.UuidAlgorithm)
               .IsRequired(false);

            builder.HasOne(comment => comment.Parent)
                .WithMany(comment => comment.Children)
                .HasForeignKey(comment => comment.ParentId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(comment => comment.Children)
                .WithOne(comment => comment.Parent)
                .HasForeignKey(comment => comment.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);

        }
    }
}
