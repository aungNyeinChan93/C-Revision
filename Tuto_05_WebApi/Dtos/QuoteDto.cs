namespace Tuto_05_WebApi.Dtos
{
    public class QuoteDto
    {
        public int QuoteId { get; set; }
        public string Quote { get; set; } = null!;
        public string Author {  get; set; } = null!;

    }
}
