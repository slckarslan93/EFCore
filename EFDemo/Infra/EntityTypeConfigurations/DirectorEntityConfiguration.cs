using EFDemo.Infra.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.EntityTypeConfigurations
{
    public class DirectorEntityConfiguration : PersonBaseEntityTypeConfiguration<DirectorEntity>
    {
        public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {
           

            base.Configure(builder);
        }
    }
}
