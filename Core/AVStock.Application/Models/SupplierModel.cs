using AVStock.Domain.Entities;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    public class Supplier_Search : BaseSearchEntity
    {

    }

    public class Supplier_Request : BaseEntity
    {
        public string? SupplierCode { get; set; }
        public string? SupplierName { get; set; }
        public int? SupplierTypeId { get; set; }
        public string? EmailId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactName { get; set; }
        public string? ContactNumber { get; set; }
        public string? GSTNumber { get; set; }
        public string? PanNumber { get; set; }
        public string? Address { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public string? PinCode { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Supplier_Response : BaseResponseEntity
    {
        public string? SupplierName { get; set; }
        public int? SupplierTypeId { get; set; }
        public string? SupplierType { get; set; }
        public string? EmailId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ContactName { get; set; }
        public string? ContactNumber { get; set; }
        public string? GSTNumber { get; set; }
        public string? PanNumber { get; set; }
        public string? Address { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public string? PinCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
