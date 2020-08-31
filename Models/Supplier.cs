using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
