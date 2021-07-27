using System.ComponentModel.DataAnnotations.Schema;

namespace BookShelf.Core.Models
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}