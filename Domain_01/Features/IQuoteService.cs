using DatabaseTwo.Models;
using Domain_01.Models;

namespace Domain_01.Features
{
    public interface IQuoteService
    {
        ResponseModel<List<Quote>>? AllQuotes();
        bool Create(Quote quote);
        bool Delete(int id);
        ResponseModel<Quote>? GetQuote(int id);
        bool Update(int id, Quote quote);
    }
}