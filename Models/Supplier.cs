using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SupplierName { get; set; }
    }
}
