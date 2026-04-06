using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Tuto_02_Dapper.Entities;

namespace Tuto_02_Dapper.Classes
{
    public class DapperOrm  
    {
        private static readonly string _databaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        public  void Read()
        {
            using (IDbConnection db = new SqlConnection(DapperOrm._databaseString))
            {
                string query = "select * from Books where DeleteFlag = 0";
                List<BookDto> books = db.Query<BookDto>(query).ToList();
                foreach (BookDto book in books)
                {
                    Console.WriteLine(book?.Title +"\r\n");
                }
            }
        }

        public void Create(BookDto bookDto)
        {
            string query = @"
                 INSERT INTO [dbo].[Books]
                   ([Title]
                   ,[Author]
                   ,[Year]
                   ,[DeleteFlag])
                 VALUES
                       (@Title
                       ,@Author
                       ,@Year
                       ,1)";

            using (IDbConnection db = new SqlConnection(DapperOrm._databaseString))
            {
                //int result = db.Execute(query, new { Title = bookDto?.Title, Author = bookDto?.Author, Year = bookDto?.Year });
                int  result = db.Execute(query,bookDto);
                Console.WriteLine(result >=1 ? "Create Success":"Create Fail");
            }
        }

        public void ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(DapperOrm._databaseString))
            {
                string query = @"select * from Books where BookId = @BookId and DeleteFlag = 0";
                var book = db.Query<BookDto>(query,new { BookId = id}).FirstOrDefault();
                if (book is null)
                {
                    Console.WriteLine("Not Found!");
                    return;
                };
                Console.WriteLine($"Book Title is {book?.Title}");
            }
        }

        public void Update(BookDto bookDto, int id)
        {

            using (IDbConnection db = new SqlConnection(DapperOrm._databaseString))
            {

                string query = @"
                     UPDATE [dbo].[Books]
                       SET [Title] = @Title
                          ,[Author] = @Author
                          ,[Year] = @Year
                          ,[DeleteFlag] = 0
                     WHERE BookId = @BookId";

                int result = db.Execute(query, new { Title = bookDto?.Title, Author = bookDto?.Author, Year = bookDto?.Year ,BookId = id});
                Console.WriteLine(result >= 1 ? "Update Success" : "Update Fail");

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(DapperOrm._databaseString))
            {
                string query = @"UPDATE [dbo].[Books]
                   SET 
                      [DeleteFlag] = 1
                 WHERE BookId = @Id";
                var result = db.Execute(query,new { Id = id});
                Console.WriteLine(result >=1 ? "Delete Success":"Delete Fail");
            }
        }
    }
}
