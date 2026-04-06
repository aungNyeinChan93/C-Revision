//using System.Data;
//using System.Data.SqlClient;


//string databaseStr = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

//SqlConnection connection = new SqlConnection(databaseStr);

//connection.Open();

//string query = @"select * from Books where deleteflag = 0";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);


//DataTable table = new DataTable("Books");


////SqlDataReader reader = cmd.ExecuteReader();
////while (reader.Read())
////{
////    Console.WriteLine(reader["Title"] + "\r\n");
////}

//// CREATE
//Console.WriteLine("Enter Title");
//string title = Console.ReadLine();

//Console.WriteLine("Enter Author");
//string author = Console.ReadLine();

//Console.WriteLine("Enter Year");
//int year = int.Parse(Console.ReadLine());


////string createQuery = $@"INSERT INTO [dbo].[Books]
////           ([Title]
////           ,[Author]
////           ,[Year]
////           ,[DeleteFlag])
////     VALUES
////           ('{title}'
////           ,'{author}'
////           ,{year}
////           ,0)";
//string createQuery = $@"INSERT INTO [dbo].[Books]
//           ([Title]
//           ,[Author]
//           ,[Year]
//           ,[DeleteFlag])
//     VALUES
//           (@Title
//           ,@Author
//           ,@Year
//           ,0)";

//SqlCommand cmd2 = new SqlCommand(createQuery,connection);
//cmd2.Parameters.AddWithValue("@Title",title);
//cmd2.Parameters.AddWithValue("@Author",author);
//cmd2.Parameters.AddWithValue("@Year",year);
//int isSuccess = cmd2.ExecuteNonQuery();

//if (isSuccess == 1) Console.WriteLine("Create success!");

//adapter.Fill(table);
//connection.Close();

//foreach (DataRow row in table.Rows)
//{
//    Console.WriteLine(row["Title"] + "\r\n");
//    Console.WriteLine(row["Author"] + "\r\n");
//}

using Tuto_01_AdoDotNet;
using Tuto_01_AdoDotNet.Entities;

AdoDotNet adoApp = new AdoDotNet();

//adoApp.Create();
//adoApp.Read();    
//Console.WriteLine("Enter Id");
//int bookId = int.Parse(Console.ReadLine());
//adoApp.ReadById(bookId);

//Console.WriteLine("Enter Update Id");
//int bookId = int.Parse(Console.ReadLine());

//Console.WriteLine("Enter Update Title");
//string title = Console.ReadLine();

//Console.WriteLine("Enter Update Author");
//string author = Console.ReadLine();

//Console.WriteLine("Enter Update Year");
//int year = int.Parse(Console.ReadLine());

//BookDto book = new BookDto() { Title = title,Author = author,Year = year};

//adoApp.Update(book,bookId);


Console.WriteLine("Enter Delete Id");
int bookId = int.Parse(Console.ReadLine());
adoApp.Delete(bookId);