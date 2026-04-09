namespace Tuto_09_MinimalApi.Models
{
  

    public class BoooksModel
    {
        public List<Book> books { get; set; }
    }

    public class Book
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        public bool deleteFlag { get; set; }
    }

}
