using DatabaseTwo.Models;
using Domain_WebApi_01.Models;

namespace Domain_01.Features
{
    public interface IBookService
    {
        bool Create(Book book);
        bool Delete(int id);
        BookResponseModel<List<Book>>? Read();
        Book? ReadOne(int id);
        bool Update(int id, Book book);
    }
}