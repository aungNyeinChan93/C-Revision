namespace BirdApi.Models
{
    public class TodoModel
    {
        public List<Todo> Todos { get; set; } = [];

    }

    public class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
    }
}
