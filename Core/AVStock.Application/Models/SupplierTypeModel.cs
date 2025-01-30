using AVStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    public class SupplierTypeModel
    {
    }
    public class SupplierType_Request : BaseEntity
    {
        public string? SupplierType { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SupplierType_Response : BaseResponseEntity
    {
        public string? SupplierType { get; set; }
        public bool? IsActive { get; set; }
    }
}
