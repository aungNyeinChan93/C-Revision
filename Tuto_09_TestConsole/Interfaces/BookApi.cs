using DatabaseTwo.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto_09_TestConsole.Interfaces
{
    public interface BookApi
    {
        [Get("/api/books")]
        Task<List<Book>> GetAll();

        [Get("/api/books/{id}")]
        Task<Book> GetOne(int id);
    }
}
