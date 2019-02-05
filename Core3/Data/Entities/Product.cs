using System.ComponentModel.DataAnnotations;

namespace Core3.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        public User User { get; set; }
    }
}
