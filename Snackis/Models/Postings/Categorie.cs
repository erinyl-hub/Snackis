namespace Snackis.Models.Postings
{
    public class Categorie
    {
        public int Id { get; set; }
        public string CategorieName { get; set; }
        public string Description { get; set; }


        public ICollection<Heading> Headings { get; set; } = new List<Heading>();
    }
}
