namespace Infrastructure.Configurations
{
    public class TreatmentPlantConfiguration : BaseEntityTypeConfiguration<TreatmentPlant>
    {
        public override void Configure(EntityTypeBuilder<TreatmentPlant> builder)
        {
            builder.HasMany(e => e.Details)
                .WithOne(e => e.Treatment)
                .HasForeignKey(e => e.TreatmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(e => e.PatientId).HasColumnType("varchar")
                    .HasMaxLength(36)
                    .HasDefaultValueSql(Constants.UuidAlgorithm)
                    .IsRequired(true);

            base.Configure(builder);

        }
    }
}
