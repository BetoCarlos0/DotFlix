using System.ComponentModel.DataAnnotations;

namespace ApiDotflix.Entities
{
    public class AgeGroup
    {
        [Key]
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Characteristics { get; set; }

        public AgeGroup(string symbol, string description, string characteristics)
        {
            Symbol = symbol;
            Description = description;
            Characteristics = characteristics;
        }
    }
}
