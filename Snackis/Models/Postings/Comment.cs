using Snackis.Areas.Identity.Data;

namespace Snackis.Models.Postings
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string? CommentImage { get; set; }

        public DateTime CommentDate { get; set; }
        public DateTime? CommentUpdated { get; set; }


        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();



        public int? PostId { get; set; }
        public Post? Post { get; set; }

        public string? UserId { get; set; }
        public SnackisUser? SnackisUser { get; set; }
    }
}
