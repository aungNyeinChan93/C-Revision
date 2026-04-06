

using Tuto_03_EFCore.Actions;
using Tuto_03_EFCore.Entities;

BookAction bookAction = new();

BookAction book = bookAction;

//book.Read();
//book.ReadById(11);

//book.Create(new BookEntity { Title = "Test Book",Author="JOJO0",Year=2000});

//book.Update(new BookEntity { Title = "Test Book", Author = "JOJO0", Year = 2000 },11);
//book.Update(new BookEntity { Year = 2500 }, 11


book.Delete(13);