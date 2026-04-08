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
    }
}
