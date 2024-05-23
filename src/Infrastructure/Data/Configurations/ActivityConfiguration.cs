namespace Infrastructure.Configurations
{
    public class ActivityConfiguration : BaseEntityTypeConfiguration<Activity>
    {
        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasMany(e => e.Details)
                .WithOne(e => e.Activity)
                .HasForeignKey(e => e.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            base.Configure(builder);

        }
    }
}
