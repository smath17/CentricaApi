using CentricaApi.Models;
using CentricaApi.Models.Repositories;
using Dapper;

namespace CentricaApi.Data.Repositories
{
    public class SalespersonRepository : ISalespersonRepository
    {
        private readonly DapperContext _context;
        public SalespersonRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SalespersonItem>> GetAll()
        {
            string sqlQuery = "SELECT * FROM salespersons";
            using (var connection = _context.CreateConnection())
            {
                var salespersons = await connection.QueryAsync<SalespersonItem>(sqlQuery);
                return salespersons.ToList();
            }
        }

        public async Task<IEnumerable<SalespersonItem>> GetAllByDistrict(int districtId)
        {
            string sqlQuery = "SELECT salespersons.* FROM salespersons INNER JOIN districts_salespersons_junction ON salespersons.id = districts_salespersons_junction.salespersons_id WHERE districts_salespersons_junction.district_id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var salespersonsByDistrict = await connection.QueryAsync<SalespersonItem>(sqlQuery, new { Id = districtId });
                return salespersonsByDistrict;
            }
        }

        public Task<SalespersonItem> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
