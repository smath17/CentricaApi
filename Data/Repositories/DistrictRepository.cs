using CentricaApi.Models;
using CentricaApi.Models.DTO;
using CentricaApi.Models.Repositories;
using Dapper;
using System.Data;

namespace CentricaApi.Data.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        // Member field
        private readonly DapperContext _context;

        // Constructor
        public DistrictRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DistrictItem>> GetAll()
        {
            string sqlQuery = "SELECT * FROM districts";
            using (var connection = _context.CreateConnection())
            {
                var districts = await connection.QueryAsync<DistrictItem>(sqlQuery);
                return districts.ToList();
            }
        }

        public async Task<DistrictItem> GetById(int id)
        {
            // @Id refers to parameter given in QueryAsync, which is given function parameter
            string sqlQuery = "SELECT * FROM districts WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<DistrictItem>(sqlQuery, new { Id = id });
            }
        }

        public Task Update(DistrictDTO projectDTO, Guid id)
        {
            /*
            string sqlQuery = "UPDATE districts SET Title = @Title, Status = @Status, Description = @Description WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Title", updateTodoDTO.Title, DbType.String);
            parameters.Add("Status", updateTodoDTO.Status, DbType.String);
            parameters.Add("Description", updateTodoDTO.Description, DbType.String);
            parameters.Add("Id", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
            */
            throw new NotImplementedException();
        }
    }
}
