using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperService
{
    public class MyDapperService
    {
        private readonly string _databaseString = "Data Source=.;Initial Catalog=ANC_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True";

        private IDbConnection _dapper;
        public MyDapperService()
        {
            _dapper = new SqlConnection(_databaseString);
        }

        public List<T>? Query<T>(string query ,object? parameters = null)
        {
            //List<T>? result;
            //if (parameters == null)
            //{
            //    result = _dapper.Query<T>(query).ToList();
            //}
            //else
            //{
            // result = _dapper.Query<T>(query, parameters).ToList();

            //}
            //return result;
            return parameters == null
                ? _dapper.Query<T>(query).ToList()
                : _dapper.Query<T>(query, parameters).ToList();
        }
    }
}
