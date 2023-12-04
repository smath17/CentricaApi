namespace CentricaApi.Models.Repositories
{
    public interface ISalespersonRepository
    {
        public Task<SalespersonItem> GetById(Guid id);
        // Query all and map to objects
        public Task<IEnumerable<SalespersonItem>> GetAll();
        public Task<IEnumerable<SalespersonItem>> GetAllByDistrict(int districtId);
    }
}
