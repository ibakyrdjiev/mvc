using System.ComponentModel.DataAnnotations;

namespace WebApp.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}