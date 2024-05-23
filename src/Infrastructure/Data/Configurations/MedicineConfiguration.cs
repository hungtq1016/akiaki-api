namespace Infrastructure.Configurations
{
    public class MedicineConfiguration : BaseEntityTypeConfiguration<Medicine>
    {
        public override void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasMany(medicine => medicine.Precriptions)
                .WithOne(detail => detail.Medicine)
                .HasForeignKey(locale => locale.MedicineId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);
        }
    }
}
