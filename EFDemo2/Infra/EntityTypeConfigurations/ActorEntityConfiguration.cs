using EFDemo2.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.EntityTypeConfigurations
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
