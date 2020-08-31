using Models.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StationName { get; set; }
        [Required]
        public int DealerId { get; set; }
        [Required]
        public int BussinessTypeId { get; set; }
        public Dealer Dealer  { get; set; }
    }
}
