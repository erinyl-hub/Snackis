using Snackis.Areas.Identity.Data;

namespace Snackis.Models.Postings
{
    public class Post
    {
        public int Id { get; set; }
        public string PostHeading { get; set; }
        public string PostText { get; set; }     
        public DateTime PostDate { get; set; }
        public DateTime? PostUpdated { get; set; }
        public int? CommentsCount { get; set; }  
        public int? ViewTimes { get; set; }


        public string? UserId { get; set; }
        public SnackisUser? SnackisUser { get; set; }


        public int HeadingId { get; set; }
        public Heading? Heading { get; set; }

    }
}
