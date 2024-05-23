namespace Infrastructure.Configurations
{
    public class BranchTypeConfiguration : BaseEntityTypeConfiguration<BranchType>
    {
        public override void Configure(EntityTypeBuilder<BranchType> builder)
        {

            builder.HasMany(branch => branch.Branches)
                .WithOne(branchtype => branchtype.Type)
                .HasForeignKey(branchtype => branchtype.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            base.Configure(builder);

        }
    }
}
