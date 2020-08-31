using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Migrations
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DealerName { get; set; }
        [ForeignKey("DealerId")]
        public ICollection<Station> Stations { get; set; }
    }
}
