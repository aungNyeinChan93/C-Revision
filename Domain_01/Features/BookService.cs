using AdoService;
using DatabaseTwo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain_01.Features
{
    public class BookService
    {
        private MyAdoService _adoService;

        public BookService()
        {
            _adoService = new MyAdoService();
        }

        public List<Book>? Read()
        {
            string query = @"SELECT [BookId]
                          ,[Title]
                          ,[Author]
                          ,[Year]
                          ,[DeleteFlag]
                          FROM [dbo].[Books]
                          where DeleteFlag = 0";
            var bookTable = _adoService.Query(query);

            List<Book> books = new List<Book>();

            foreach (DataRow row in bookTable!.Rows)
            {
                books.Add(new Book
                {
                    Title = row["Title"].ToString()!,
                    Author = row["Author"].ToString()!,
                    BookId = int.Parse(row["BookId"].ToString()!),
                    DeleteFlag = bool.Parse(row["DeleteFlag"].ToString()!),
                    Year = int.Parse(row["Year"].ToString()!)
                });
            }
            
             return books;

        }

        public Book? ReadOne(int id)
        {
            string query = @"SELECT [BookId]
                          ,[Title]
                          ,[Author]
                          ,[Year]
                          ,[DeleteFlag]
                          FROM [dbo].[Books]
                          where DeleteFlag = 0 and BookId = @BookId";
            var books = _adoService.Query(query, new Adoparameter { Name = "@BookId", Value = id });
            if(books is null || books.Rows.Count <=0) return null;
            var row = books!.Rows[0];
            Book book = new Book
            {
                Title = row["Title"].ToString()!,
                Author = row["Author"].ToString()!,
                BookId = int.Parse(row["BookId"].ToString()!),
                DeleteFlag = bool.Parse(row["DeleteFlag"].ToString()!),
                Year = int.Parse(row["Year"].ToString()!)
            };
            return book;
        }

        public bool Create(Book book)
        {
            string query = @"INSERT INTO [dbo].[Books]
                           ([Title]
                           ,[Author]
                           ,[Year]
                           ,[DeleteFlag])
                         VALUES
                           (@Title
                           ,@Author
                           ,@Year
                           ,0)";
            bool isSuccess =_adoService.Execute(query,
                new Adoparameter { Name = "@Title",Value = book.Title},
                new Adoparameter { Name = "@Author", Value = book.Author},
                new Adoparameter { Name = "@Year",Value = book.Year}
                );
            return isSuccess;
        }

        public bool Update(int id,Book book)
        {
            string query = @"UPDATE [dbo].[Books]
                           SET [Title] = @Title
                              ,[Author] =@Author
                              ,[Year] = @Year
                              ,[DeleteFlag] = @DeleteFlag
                         WHERE BookId = @BookId";
            bool result = _adoService.Execute(query,
                    new Adoparameter { Name = "@Title", Value = book.Title },
                    new Adoparameter { Name = "@Author", Value = book.Author },
                    new Adoparameter { Name = "@Year", Value = book.Year },
                    new Adoparameter { Name = "@DeleteFlag" ,Value = book.DeleteFlag},
                    new Adoparameter { Name = "@BookId" ,Value = id}
                );

            return result;
        }

        public bool Delete(int id)
        {
            string query = @"UPDATE [dbo].[Books]
                           SET [DeleteFlag] = @DeleteFlag
                         WHERE BookId = @BookId and DeleteFlag = 0";
            bool result = _adoService.Execute(query,
                    new Adoparameter { Name = "@DeleteFlag", Value = 1 },
                    new Adoparameter { Name = "@BookId", Value = id }
                );

            return result;
        }
    }
}
