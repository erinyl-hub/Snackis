namespace Snackis.Dtos
{
    public class CategorieDto
    {
        public int Id { get; set; }
        public string CategorieName { get; set; }
        public List<Dtos.HeadingDto> Headings { get; set; }
    }
}
