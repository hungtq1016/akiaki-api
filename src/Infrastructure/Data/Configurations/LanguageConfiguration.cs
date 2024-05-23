namespace Infrastructure.Configurations
{
    public class LanguageConfiguration : BaseEntityTypeConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasMany(language => language.Locales)
                .WithOne(locale => locale.Language)
                .HasForeignKey(locale => locale.LanguageId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
