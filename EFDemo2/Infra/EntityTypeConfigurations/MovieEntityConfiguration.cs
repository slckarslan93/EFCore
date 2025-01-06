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
    public class MovieEntityConfiguration : BaseEntityTypeConfiguration<MovieEntity>
    {
        public override void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("Movies", schema: "ef");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.ViewCount)
                .HasDefaultValue(1);

            builder.HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);

            builder.HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            builder.HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(j => j.ToTable("MovieActor"));

            base.Configure(builder);

        }
    }
}
