namespace Snackis.Models.Postings
{
    public class Heading
    {
        public int Id { get; set; }
        public string HeadingName { get; set; } 
        public string Description { get; set; }

        public int? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }


        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
