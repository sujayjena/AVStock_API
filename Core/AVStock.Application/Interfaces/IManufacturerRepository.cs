using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<int> SaveManufacturer(Manufacturer_Request parameters);

        Task<IEnumerable<Manufacturer_Response>> GetManufacturerList(BaseSearchEntity parameters);

        Task<Manufacturer_Response?> GetManufacturerById(long Id);
    }
}
