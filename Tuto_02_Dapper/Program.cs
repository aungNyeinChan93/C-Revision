

using Tuto_02_Dapper.Classes;
using Tuto_02_Dapper.Entities;

DapperOrm dapper = new DapperOrm();

//dapper.Read();

//BookDto bookDto = new BookDto() { Title = "Create Title",Author = "GIGI",Year = 1333};
//dapper.Create(bookDto);

//dapper.ReadById(1);

//dapper.Update(new BookDto { Author = "Chan",Title = "Chan Books",Year = 2026},5);

dapper.Delete(10);
