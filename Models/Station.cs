using System.ComponentModel.DataAnnotations;


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
