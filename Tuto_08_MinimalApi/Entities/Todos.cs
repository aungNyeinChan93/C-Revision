namespace Tuto_08_MinimalApi.Entities
{
    


    public class Todos
    {
        public List<Todo> todos { get; set; }
       
    }

    public class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
    }




}
