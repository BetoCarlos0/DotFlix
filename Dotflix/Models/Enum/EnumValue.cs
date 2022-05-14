using System.ComponentModel.DataAnnotations;

namespace ApiDotflix.Models.Enum
{
    public class EnumValue
    {
        [Key]
        public int Value { get; set; }
        public string Name { get; set; }
    }
}
