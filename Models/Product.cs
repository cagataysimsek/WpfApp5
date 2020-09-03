using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int DefId { get; set; }
        public Defination Defination { get; set; }
        [ForeignKey("ProductId")]
        public ICollection<Recipt> Recipts { get; set; }
    }
}
