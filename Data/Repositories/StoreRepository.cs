using CentricaApi.Models;
using CentricaApi.Models.Repositories;
using Dapper;

namespace CentricaApi.Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DapperContext _context;
        public StoreRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StoreItem>> GetAllByDistrict(int districtId)
        {
            string sqlQuery = "SELECT * FROM stores WHERE stores.district_id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var storesByDistrict = await connection.QueryAsync<StoreItem>(sqlQuery, new { Id = districtId });
                return storesByDistrict;
            }
        }

        public async Task<IEnumerable<StoreItem>> GetAll()
        {
            string sqlQuery = "SELECT * FROM stores";
            using (var connection = _context.CreateConnection())
            {
                var stores = await connection.QueryAsync<StoreItem>(sqlQuery);
                return stores.ToList();
            }
        }
    }
}
