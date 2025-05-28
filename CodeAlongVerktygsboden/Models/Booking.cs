namespace CodeAlongVerktygsboden.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string Notes { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Asset Asset { get; set; }
        public int AssetId { get; set; }

    }
}
