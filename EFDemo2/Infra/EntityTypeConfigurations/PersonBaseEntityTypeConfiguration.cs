using EFDemo2.Infra.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.EntityTypeConfigurations
{
    public class PersonBaseEntityTypeConfiguration<TEntity> : BaseEntityTypeConfiguration<TEntity> where TEntity : PersonBaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
