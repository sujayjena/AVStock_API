using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface IOrderRepository
    {
        #region Order
        Task<int> SaveOrder(Order_Request parameters);
        Task<IEnumerable<Order_Response>> GetOrderList(Order_Search parameters);
        Task<Order_Response?> GetOrderById(long Id);
        #endregion

        #region Order Details
        Task<int> SaveOrderDetails(OrderDetails_Request parameters);
        Task<IEnumerable<OrderDetails_Response>> GetOrderDetailsList(OrderDetails_Search parameters);
        #endregion
    }
}
