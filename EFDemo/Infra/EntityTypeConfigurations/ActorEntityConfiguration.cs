using EFDemo.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.EntityTypeConfigurations
{
    public class ActorEntityConfiguration : PersonBaseEntityTypeConfiguration<ActorEntity>
    {
        public override void Configure(EntityTypeBuilder<ActorEntity> builder)
        {
            builder.ToTable(name: "Actors", schema: "ef");
            

            base.Configure(builder);
        }
    }
}
