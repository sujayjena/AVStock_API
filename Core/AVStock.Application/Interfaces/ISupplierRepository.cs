using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface ISupplierRepository
    {
        Task<int> SaveSupplier(Supplier_Request parameters);

        Task<IEnumerable<Supplier_Response>> GetSupplierList(Supplier_Search parameters);

        Task<Supplier_Response?> GetSupplierById(long Id);
    }
}
