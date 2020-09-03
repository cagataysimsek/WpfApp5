using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MaterialName { get; set; }
        public int DefId { get; set; }
        

    }
}
