using AVStock.Domain.Entities;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    #region Inwarding
    public class Inwarding_Search : BaseSearchEntity
    {

    }

    public class Inwarding_Request : BaseEntity
    {
        public int? ItemNameId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ProductDetailsId { get; set; }
        public int? SupplierId { get; set; }
        public string? BatchNumber { get; set; }
        public string? LotNumber { get; set; }
        public int? SKUId { get; set; }
        public decimal? CurrentStock { get; set; }
        public decimal? RecoderQty { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? StorageLocationId { get; set; }
        public DateTime? LastStockUpdateDate { get; set; }
        public decimal? CostPerUnit { get; set; }
        public decimal? ReceivedQty { get; set; }
        public decimal? TotalValue { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PONumber { get; set; }
        public string? UsageDetails { get; set; }
        public int? ItemStatusId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Inwarding_Response : BaseResponseEntity
    {
        public int? ItemNameId { get; set; }
        public string? ItemName { get; set; }
        public int? CategoryId { get; set; }
        public string? Category { get; set; }
        public int? SubCategoryId { get; set; }
        public string? SubCategory { get; set; }
        public int? ManufacturerId { get; set; }
        public string? Manufacturer { get; set; }
        public int? ProductDetailsId { get; set; }
        public int? UOMId { get; set; }
        public string? UOMName { get; set; }
        public decimal? MinQty { get; set; }
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? ContactNumber { get; set; }
        public string? BatchNumber { get; set; }
        public string? LotNumber { get; set; }
        public int? SKUId { get; set; }
        public string? SKU { get; set; }
        public decimal? CurrentStock { get; set; }
        public decimal? RecoderQty { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? StorageLocationId { get; set; }
        public string? StorageLocation { get; set; }
        public DateTime? LastStockUpdateDate { get; set; }
        public decimal? CostPerUnit { get; set; }
        public decimal? ReceivedQty { get; set; }
        public decimal? TotalValue { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string? PONumber { get; set; }
        public string? UsageDetails { get; set; }
        public int? ItemStatusId { get; set; }
        public string? ItemStatus { get; set; }
        public bool? IsActive { get; set; }
    }

    #endregion

    #region Outwarding

    #endregion
}
