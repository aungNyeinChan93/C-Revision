namespace Tuto_05_WebApi.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }

        public string? Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string? Author { get; set; } = null!;

        public DateTime? Date { get; set; } = null!;
        public bool DeleteFlag { get; set; } = false;

    }
}
