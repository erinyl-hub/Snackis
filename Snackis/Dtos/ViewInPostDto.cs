namespace Snackis.Dtos
{
    public class ViewInPostDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? PostUpdated { get; set; }


    }
}
