using DatabaseTwo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto_04_ClassLibary
{
    public class BookController
    {

        private readonly AppDbContext db;

        public BookController()
        {
            db = new AppDbContext();
        }
        public void Read()
        {
            var books =  db.Books
                            .AsNoTracking()
                            .Where(b => b.DeleteFlag == false)
                            .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Book Title = {book?.Title}");
            }
        }
    }
}
