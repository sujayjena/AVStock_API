using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface IProductDetailsRepository
    {
        Task<int> SaveProductDetails(ProductDetails_Request parameters);
        Task<IEnumerable<ProductDetails_Response>> GetProductDetailsList(BaseSearchEntity parameters);
        Task<ProductDetails_Response?> GetProductDetailsById(int Id);
    }
}
