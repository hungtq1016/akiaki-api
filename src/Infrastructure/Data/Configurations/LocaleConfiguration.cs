namespace Infrastructure.Configurations
{
    public class LocaleConfiguration : BaseEntityTypeConfiguration<Locale>
    {
        public override void Configure(EntityTypeBuilder<Locale> builder)
        {
            builder.Property(locale => locale.LanguageId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(locale => locale.KeyId).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            base.Configure(builder);

        }
    }
}
