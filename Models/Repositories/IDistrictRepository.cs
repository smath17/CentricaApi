using System.Collections.Generic;
using System.Threading.Tasks;
using CentricaApi.Models;
using System;
using CentricaApi.Models.DTO;

namespace CentricaApi.Models.Repositories
{
    public interface IDistrictRepository
    {
        public Task<IEnumerable<DistrictItem>> GetAll();

        public Task<DistrictItem> GetById(int id);

        public Task Update(DistrictDTO projectDTO, Guid id);
    }
}