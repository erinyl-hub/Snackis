namespace Snackis.Models.Postings
{
    public class Report
    {
        public int Id { get; set; }
        public int? PoastId { get; set; }
        public int? CommentId { get; set; }
        public DateTime ReportDate { get; set; }
        public string UserId { get; set; }
    }
}
