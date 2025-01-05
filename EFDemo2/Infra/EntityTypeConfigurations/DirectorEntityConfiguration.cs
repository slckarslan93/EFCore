using EFDemo2.Infra.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.EntityTypeConfigurations
{
    public class DirectorEntityConfiguration : PersonBaseEntityTypeConfiguration<DirectorEntity>
    {
        public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
        {


            base.Configure(builder);
        }
    }
}
