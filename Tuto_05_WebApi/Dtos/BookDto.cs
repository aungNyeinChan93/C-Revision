namespace Tuto_05_WebApi.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public bool DeleteFlag {  get; set; } = false;
    }
}
