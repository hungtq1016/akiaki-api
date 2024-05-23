namespace Infrastructure.Configurations
{
    public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AbstractEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(entity => entity.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(entity => entity.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(entity => entity.Status)
                .HasDefaultValue(StatusEnum.Active)
                .IsRequired(true);

        }
    }
}
