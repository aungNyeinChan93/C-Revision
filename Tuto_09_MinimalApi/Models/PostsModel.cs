namespace Tuto_09_MinimalApi.Models
{
    public class PostsModel
    {
        public List<Post> posts { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string[] tags { get; set; }
        public Reactions reactions { get; set; }
        public int views { get; set; }
        public int userId { get; set; }
    }

    public class Reactions
    {
        public int likes { get; set; }
        public int dislikes { get; set; }
    }

}
