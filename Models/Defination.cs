using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Models
{
    public class Defination
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DefType { get; set; }
        [Required]
        public string DefValue { get; set; }

    }
}
