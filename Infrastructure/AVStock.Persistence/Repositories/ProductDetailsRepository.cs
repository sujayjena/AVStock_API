using AVStock.Application.Helpers;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Persistence.Repositories
{
    public class ProductDetailsRepository : GenericRepository, IProductDetailsRepository
    {

        private IConfiguration _configuration;

        public ProductDetailsRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveProductDetails(ProductDetails_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ItemNameId", parameters.ItemNameId);
            queryParameters.Add("@CategoryId", parameters.CategoryId);
            queryParameters.Add("@SubCategoryId", parameters.SubCategoryId);
            queryParameters.Add("@ManufacturerId", parameters.ManufacturerId);
            queryParameters.Add("@Description", parameters.Description);
            queryParameters.Add("@HSNCode", parameters.HSNCode);
            queryParameters.Add("@UOMId", parameters.UOMId);
            queryParameters.Add("@MinQty", parameters.MinQty);
            queryParameters.Add("@AvailableQty", parameters.AvailableQty);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveProductDetails", queryParameters);
        }

        public async Task<IEnumerable<ProductDetails_Response>> GetProductDetailsList(BaseSearchEntity parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<ProductDetails_Response>("GetProductDetailsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<ProductDetails_Response?> GetProductDetailsById(int Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<ProductDetails_Response>("GetProductDetailsById", queryParameters)).FirstOrDefault();
        }
    }
}
