using EFDemo.Infra.Entities.Base;

namespace EFDemo.Infra.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
