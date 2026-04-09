using Domain_02.Interfaces;
using Domain_02.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Tuto_09_TestConsole.Interfaces;

namespace Tuto_09_TestConsole
{
    public  class RefitTest
    {
        public async Task Run()
        {
            var userApi = RestService.For<UserApi>("https://dummyjson.com");
            var users = await userApi.GetAllAsync();
            if(users is null)
            {
                Console.WriteLine("User not found");
                return;
            }
            foreach (User user in users.users)
            {
                Console.WriteLine($"User name is {user.firstName} {user.lastName} \n");
            }
        }

        public async Task GetBooks()
        {
            var bookApi = RestService.For<BookApi>("https://localhost:7198");
            var books = await bookApi.GetAll();
            if (books is null)
            {
                return;
            }
            foreach (var book in books)
            {
                Console.WriteLine($"Book Title ==> {book.Title}");
            }
        }
        public async Task GetOne(int id)
        {
            var bookApi = RestService.For<BookApi>("https://localhost:7198");
            var book = await bookApi.GetOne(id);
            if (book is null)
            {
                return;
            }
            Console.WriteLine($"Author Name is {book.Author}");
        }
    }
}
