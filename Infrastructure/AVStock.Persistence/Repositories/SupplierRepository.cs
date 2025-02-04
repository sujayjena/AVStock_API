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
    public class SupplierRepository : GenericRepository, ISupplierRepository
    {

        private IConfiguration _configuration;

        public SupplierRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> SaveSupplier(Supplier_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@SupplierCode", parameters.SupplierCode);
            queryParameters.Add("@SupplierName", parameters.SupplierName);
            queryParameters.Add("@SupplierTypeId", parameters.SupplierTypeId);
            queryParameters.Add("@EmailId", parameters.EmailId);
            queryParameters.Add("@PhoneNumber", parameters.PhoneNumber);
            queryParameters.Add("@ContactName", parameters.ContactName);
            queryParameters.Add("@ContactNumber", parameters.ContactNumber);
            queryParameters.Add("@GSTNumber", parameters.GSTNumber);
            queryParameters.Add("@PanNumber", parameters.PanNumber);
            queryParameters.Add("@Address", parameters.Address);
            queryParameters.Add("@StateId", parameters.StateId);
            queryParameters.Add("@DistrictId", parameters.DistrictId);
            queryParameters.Add("@CityId", parameters.CityId);
            queryParameters.Add("@PinCode", parameters.PinCode);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveSupplier", queryParameters);
        }

        public async Task<IEnumerable<Supplier_Response>> GetSupplierList(Supplier_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Supplier_Response>("GetSupplierList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Supplier_Response?> GetSupplierById(long Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Supplier_Response>("GetSupplierById", queryParameters)).FirstOrDefault();
        }
    }
}

