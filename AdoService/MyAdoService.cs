using System.Data;
using System.Data.SqlClient;

namespace AdoService
{
    public class MyAdoService
    {
        private readonly static string _databaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private SqlConnection _connection;

        public MyAdoService()
        {
            _connection = new SqlConnection(MyAdoService._databaseString);
        }

        public DataTable? Query(string query,params List<Adoparameter>? adoparameters)
        {
            try
            {
                _connection.Open();
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand(query, _connection);

                if(adoparameters is not null)
                {
                    foreach (Adoparameter adoParameter in adoparameters)
                    {
                        cmd.Parameters.AddWithValue(adoParameter.Name, adoParameter.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                _connection.Close();
                return table is not null ? table : null ;
                
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool Execute(string query,params List<Adoparameter>? adoparameters)
        {
            _connection.Open();

            SqlCommand cmd = new SqlCommand(query,_connection);
            if (adoparameters.Count <=0) return false;

            foreach (var adoparameter in adoparameters)
            {
                cmd.Parameters.AddWithValue(adoparameter.Name,adoparameter.Value);
            }
            ;

            int result = cmd.ExecuteNonQuery();

            _connection.Close();
            return result >= 1 ? true : false ;

        }

    }

    public class Adoparameter
    {
        public string? Name { get; set; }
        public object Value { get;set;  }
    }
}
