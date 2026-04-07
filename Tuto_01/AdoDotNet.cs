using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuto_01_AdoDotNet.Entities;

namespace Tuto_01_AdoDotNet
{
    public class AdoDotNet
    {
        private static readonly string DatabaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

        public SqlConnection connection;

        public AdoDotNet()
        {
            this.connection = new SqlConnection(AdoDotNet.DatabaseString);
        }
        public void Read()
        {
            connection.Open();
            string query = @"select * from Books where deleteflag = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("Books");
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Book Title ==> {row["title"]} \n");
            }
            connection.Close();
        }

        public void ReadById(int Id)
        {
            connection.Open();

            string query = $@"select * from Books where deleteflag = 0 and BookId = @BookId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BookId",Id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("Books");
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {
                Console.WriteLine("Data Not Found");
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Book Title ==> {row["title"]} \n");
            }
         
            connection.Close();
        }

        public void Create()
        {
            connection.Open();
            Console.WriteLine("Enter Title");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Author");
            string author = Console.ReadLine();

            Console.WriteLine("Enter Year");

            int year = int.Parse(Console.ReadLine());            string createQuery = $@"INSERT INTO [dbo].[Books]
           ([Title]
           ,[Author]
           ,[Year]
           ,[DeleteFlag])
             VALUES
                   (@Title
                   ,@Author
                   ,@Year
                   ,0)";

            SqlCommand cmd2 = new SqlCommand(createQuery, connection);
            cmd2.Parameters.AddWithValue("@Title", title);
            cmd2.Parameters.AddWithValue("@Author", author);
            cmd2.Parameters.AddWithValue("@Year", year);
            int isSuccess = cmd2.ExecuteNonQuery();

            if (isSuccess == 1) Console.WriteLine("Create success!");
            connection.Close();
        }

        public void Update(BookDto bookDto,int id)
        {
            connection.Open();

            string query = @"
                UPDATE [dbo].[Books]
                   SET [Title] =@Title
                      ,[Author] = @Author
                      ,[Year] = @Year
                      ,[DeleteFlag] = 0
                 WHERE BookId = @Id";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@Title",bookDto.Title);
            cmd.Parameters.AddWithValue("@Author", bookDto.Author);
            cmd.Parameters.AddWithValue("@Year",bookDto.Year);
            cmd.Parameters.AddWithValue("@Id",id);

            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result <= 0 ? "Update Fail!":"Update Success");

            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            string query = @"
                UPDATE [dbo].[Books]
                   SET 
                   [DeleteFlag] = 1
                 WHERE BookId = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id",id);

            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result >=1 ? "Delete Success":"Delete Fail");
            connection.Close();
        }


        
    }
    
}
