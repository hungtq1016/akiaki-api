namespace Infrastructure.Configurations
{
    public class UrlConfiguration : BaseEntityTypeConfiguration<Url>
    {
        public override void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.Property(url => url.GroupId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
