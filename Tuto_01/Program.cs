using System.Data;
using System.Data.SqlClient;


string databaseStr = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

SqlConnection connection = new SqlConnection(databaseStr);

connection.Open();

string query = @"select * from Books where deleteflag = 0";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);


DataTable table = new DataTable("Books");
adapter.Fill(table);


SqlDataReader reader = cmd.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine(reader["Title"] + "\r\n");
}

// CREATE
//string createQuery = @"
//INSERT INTO [dbo].[Books]
//           ([Title]
//           ,[Author]
//           ,[Year]
//           )
//     VALUES
//           (Test 
//           ,GIGI
//           ,2000
//           )";

//SqlCommand cmd2 = new SqlCommand(createQuery,connection);
//SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
adapter2.Fill(table);




connection.Close();

foreach (DataRow row in table.Rows)
{
    Console.WriteLine(row["Title"] + "\r\n");
    Console.WriteLine(row["Author"] + "\r\n");
}