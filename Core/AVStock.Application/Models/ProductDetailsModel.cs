using AVStock.Domain.Entities;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    public class ProductDetails_Search : BaseSearchEntity
    {
    }

    public class ProductDetails_Request : BaseEntity
    {
        public int? ItemNameId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ManufacturerId { get; set; }

        [DefaultValue("")]
        public string? Description { get; set; }

        [DefaultValue("")]
        public string? HSNCode { get; set; }

        public int? UOMId { get; set; }
        public decimal? MinQty { get; set; }
        public decimal? AvailableQty { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ProductDetails_Response : BaseResponseEntity
    {
        public int? ItemNameId { get; set; }
        public string? ItemName { get; set; }
        public int? CategoryId { get; set; }
        public string? Category { get; set; }
        public int? SubCategoryId { get; set; }
        public string? SubCategory { get; set; }
        public int? ManufacturerId { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public string? HSNCode { get; set; }
        public int? UOMId { get; set; }
        public string? UOMName { get; set; }
        public decimal? MinQty { get; set; }
        public decimal? AvailableQty { get; set; }
        public bool? IsActive { get; set; }
    }
}
