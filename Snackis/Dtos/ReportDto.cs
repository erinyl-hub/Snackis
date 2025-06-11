namespace Snackis.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }

        public int? PoastId { get; set; }
        public int? CommentId { get; set; }
        public int ReportId { get; set; }

        public string Reporter { get; set; }
        public string ReportedBy { get; set; }
        public DateTime ReportDate { get; set; }
        public string Text { get; set; }
    }
}   
