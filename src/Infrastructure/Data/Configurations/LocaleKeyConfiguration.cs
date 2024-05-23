namespace Infrastructure.Configurations
{
    public class LocaleKeyConfiguration : BaseEntityTypeConfiguration<LocaleKey>
    {
        public override void Configure(EntityTypeBuilder<LocaleKey> builder)
        {
            builder.HasMany(localekey => localekey.Locales)
                .WithOne(locale => locale.Key)
                .HasForeignKey(locale => locale.KeyId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
