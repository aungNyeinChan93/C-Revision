namespace Tuto_09_MinimalApi.Models
{
    public class QuotesModel
    {
        public List<Quote> quotes { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }


    public class Quote
    {
        public int id { get; set; }
        public string quote { get; set; }
        public string author { get; set; }
    }

}
