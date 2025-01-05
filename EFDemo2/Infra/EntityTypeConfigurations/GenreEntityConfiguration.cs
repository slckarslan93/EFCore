using EFDemo2.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo2.Infra.EntityTypeConfigurations
{
    public class GenreEntityConfiguration : BaseEntityTypeConfiguration<GenreEntity>
    {
        public override void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable(name: "Genres", schema: "ef");
            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
