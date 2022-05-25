using System.ComponentModel.DataAnnotations;

namespace ApiDotflix.Entities.Models.Dtos
{
    public class BaseEntityDto
    {
        [Required(ErrorMessage = "Id obrigatório")]
        public int Id { get; set; }
    }
}
