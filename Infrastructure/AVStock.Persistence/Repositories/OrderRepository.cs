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
    internal class OrderRepository : GenericRepository, IOrderRepository
    {

        private IConfiguration _configuration;

        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Order
        public async Task<int> SaveOrder(Order_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderNo", parameters.OrderNo);
            queryParameters.Add("@OrderDate", parameters.OrderDate);
            queryParameters.Add("@PatientId", parameters.PatientId);
            queryParameters.Add("@IsOrderCanceled", parameters.IsOrderCanceled);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrder", queryParameters);
        }

        public async Task<IEnumerable<Order_Response>> GetOrderList(Order_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<Order_Response>("GetOrderList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<Order_Response?> GetOrderById(long Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<Order_Response>("GetOrderById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Order Details
        public async Task<int> SaveOrderDetails(OrderDetails_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@ServiceId", parameters.ServiceId);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveOrderDetails", queryParameters);
        }

        public async Task<IEnumerable<OrderDetails_Response>> GetOrderDetailsList(OrderDetails_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<OrderDetails_Response>("GetOrderDetailsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        #endregion
    }
}
