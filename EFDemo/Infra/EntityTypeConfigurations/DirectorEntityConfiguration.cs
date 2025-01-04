using EFDemo.Infra.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.EntityTypeConfigurations
{
    public class DirectorEntityConfiguration : PersonBaseEntityTypeConfiguration<DirectorEntity>
    {
        public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {
            builder.HasMany(d => d.Movies)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId);

            base.Configure(builder);
        }
    }
}
