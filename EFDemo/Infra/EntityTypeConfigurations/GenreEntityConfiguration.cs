using EFDemo.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Infra.EntityTypeConfigurations
{
    public class GenreEntityConfiguration :BaseEntityTypeConfiguration<GenreEntity>
    {
        public override void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.ToTable(name:"Genres",schema: "ef");
            builder.Property(i => i.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            base.Configure(builder);
        }
    }
}
