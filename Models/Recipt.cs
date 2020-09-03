using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Recipt
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
