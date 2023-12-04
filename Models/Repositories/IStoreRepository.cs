namespace CentricaApi.Models.Repositories
{
    public interface IStoreRepository
    {
        public Task<IEnumerable<StoreItem>> GetAll();
        public Task<IEnumerable<StoreItem>> GetAllByDistrict(int districtId);
    }
}
