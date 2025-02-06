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
    public class MasterInventoryRepository : GenericRepository, IMasterInventoryRepository
    {

        private IConfiguration _configuration;

        public MasterInventoryRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Inwarding

        public async Task<int> SaveInwarding(Inwarding_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@ItemNameId", parameters.ItemNameId);
            queryParameters.Add("@CategoryId", parameters.CategoryId);
            queryParameters.Add("@SubCategoryId", parameters.SubCategoryId);
            queryParameters.Add("@ManufacturerId", parameters.ManufacturerId);
            queryParameters.Add("@ProductDetailsId", parameters.ProductDetailsId);
            queryParameters.Add("@SupplierId", parameters.SupplierId);
            queryParameters.Add("@BatchNumber", parameters.BatchNumber);
            queryParameters.Add("@LotNumber", parameters.LotNumber);
            queryParameters.Add("@SKUId", parameters.SKUId);
            queryParameters.Add("@CurrentStock", parameters.CurrentStock);
            queryParameters.Add("@RecoderQty", parameters.RecoderQty);
            queryParameters.Add("@ExpiryDate", parameters.ExpiryDate);
            queryParameters.Add("@StorageLocationId", parameters.StorageLocationId);
            queryParameters.Add("@LastStockUpdateDate", parameters.LastStockUpdateDate);
            queryParameters.Add("@CostPerUnit", parameters.CostPerUnit);
            queryParameters.Add("@ReceivedQty", parameters.ReceivedQty);
            queryParameters.Add("@TotalValue", parameters.TotalValue);
            queryParameters.Add("@PurchaseDate", parameters.PurchaseDate);
            queryParameters.Add("@PONumber", parameters.PONumber);
            queryParameters.Add("@UsageDetails", parameters.UsageDetails);
            queryParameters.Add("@ItemStatusId", parameters.ItemStatusId);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveInwarding", queryParameters);
        }

        public async Task<IEnumerable<Inwarding_Response>> GetInwardingList(Inwarding_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Inwarding_Response>("GetInwardingList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Inwarding_Response?> GetInwardingById(long Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Inwarding_Response>("GetInwardingById", queryParameters)).FirstOrDefault();
        }

        #endregion

        #region Outwarding

        #endregion
    }
}
