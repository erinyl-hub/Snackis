namespace Snackis.Dtos
{
    public class PostViewDto
    {
        public int Id { get; set; }
        public string UserPoster { get; set; }
        public int CommentsCount { get; set; }
        public DateTime LastComment { get; set; }
        public string Header { get; set; }
        public DateTime PostDate { get; set; }

        public int HeadingId { get; set; }


    }
}
