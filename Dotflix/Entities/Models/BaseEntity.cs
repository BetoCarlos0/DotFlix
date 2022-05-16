using System.ComponentModel.DataAnnotations;

namespace ApiDotflix.Entities.Models
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome Requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nome menor que 3 caracteres")]
        public string Name { get; set; }
    }
}
