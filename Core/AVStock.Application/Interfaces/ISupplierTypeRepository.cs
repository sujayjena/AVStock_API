using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface ISupplierTypeRepository
    {
        Task<int> SaveSupplierType(SupplierType_Request parameters);

        Task<IEnumerable<SupplierType_Response>> GetSupplierTypeList(BaseSearchEntity parameters);

        Task<SupplierType_Response?> GetSupplierTypeById(long Id);
    }
}
