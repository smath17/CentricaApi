using System.Data;
using Microsoft.Data.SqlClient;
// using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace CentricaApi.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
    }
}
