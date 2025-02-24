using AVStock.Domain.Entities;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    #region Order
    public class Order_Search : BaseSearchEntity
    {
    }

    public class Order_Request : BaseEntity
    {
        public Order_Request()
        {
            OrderDetailsList = new List<OrderDetails_Request>();
        }
        public string? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? PatientId { get; set; }

        [DefaultValue(false)]
        public bool? IsOrderCanceled { get; set; }
        public bool? IsActive { get; set; }
        public List<OrderDetails_Request> OrderDetailsList { get; set; }
    }

    public class Order_Response : BaseResponseEntity
    {
        public string? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? PatientId { get; set; }
        public bool? IsOrderCanceled { get; set; }
        public bool? IsActive { get; set; }
        public List<OrderDetails_Response> OrderDetailsList { get; set; }
    }
    #endregion

    #region Order Details
    public class OrderDetails_Search : BaseSearchEntity
    {
        public int? OrderId { get; set; }
    }

    public class OrderDetails_Request : BaseEntity
    {
        [JsonIgnore]
        public int? OrderId { get; set; }
        public int? ServiceId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class OrderDetails_Response : BaseResponseEntity
    {
        public int? OrderId { get; set; }
        public string? OrderNo { get; set; }
        public int? ServiceId { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion
}
