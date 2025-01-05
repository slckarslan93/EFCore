using EFDemo2.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
