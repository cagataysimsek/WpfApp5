using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public  class MaterialHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OfficerId { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public int DefIdUnit { get; set; }
        public int? DefIdCurrency { get; set; }
        [Required]
        public double Fee { get; set; }
        public int? DefIdBussinessType { get; set; }
        public int? DealerId { get; set; }
        public int? StationId { get; set; }
        [Required]
        public int OperationTypeNum { get; set; }
        public int OutputType { get; set; }
        
    }
}
