namespace BirdApi.Models
{
    public class BirdModel
    {
        public List<Bird> Birds { get; set; } = [];
    }

    public class Bird
    {
        public int Id { get; set; }
        public string? BirdMyanmarName { get; set; }
        public string? BirdEnglishName { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }


}
