using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuto_03_EFCore.DataBase;
using Tuto_03_EFCore.Entities;

namespace Tuto_03_EFCore.Actions
{
    public class BookAction
    { 
        private AppDbContext db;

        public BookAction()
        {
            db = new AppDbContext();
        }

        public void Read()
        {
            var books = db.Books
                .AsNoTracking()
                .Where(b => b.DeleteFlag == false )
                .ToList();

            foreach (BookEntity book in books)
            { 
                Console.WriteLine($"Book Title ==> {book?.Title}");
            }
        }

        public void ReadById(int id)
        {
            var book = db.Books
                .AsNoTracking()
                .Where(b=>b.DeleteFlag == false && b.BookId == id)
                .FirstOrDefault();

            if(book is null) Console.WriteLine("Not Found!");
            Console.WriteLine($"Book Title ==> {book!.Title} \nAuthor Name ==> {book.Author} ");
        }

        public void Create(BookEntity bookEntity)
        {
            try
            {
                db.Books.Add(bookEntity);
                var result = db.SaveChanges();
                Console.WriteLine(result >=1 ? "Create Success":"Create Fail");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void Update(BookEntity bookEntity ,int id)
        {
            try
            {
                var oldBook = db.Books
                    .AsNoTracking()
                    .Where(b=>b.DeleteFlag == false && b.BookId == id)
                    .FirstOrDefault();

                if (oldBook is null)
                {
                    Console.WriteLine("Data Not Found!");
                    return;
                }

                if (!string.IsNullOrEmpty(oldBook!.Title))
                {
                    oldBook.Title = bookEntity.Title;
                }
                if (!string.IsNullOrEmpty(oldBook.Author))
                {
                    oldBook.Author = bookEntity.Author;
                }
                if (oldBook.Year >=0)
                {
                    oldBook.Year = bookEntity.Year;
                }

                db.Entry(oldBook).State = EntityState.Modified;
                int result = db.SaveChanges();
                Console.WriteLine(result >=1 ? "Update Success!":"Update Fail");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
               var book = db.Books
                    .AsNoTracking()
                    .Where(b => b.BookId == id && b.DeleteFlag == false)
                    .FirstOrDefault();

                if (book is null)
                {
                    Console.WriteLine("Not Found!");
                    return;
                }
                book.DeleteFlag = true;
                db.Entry(book).State = EntityState.Modified;
                int result = db.SaveChanges();
                Console.WriteLine(result >=1 ? "Delete success":"Delete Fail");

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
