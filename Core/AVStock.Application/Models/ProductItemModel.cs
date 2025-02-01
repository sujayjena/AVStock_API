using AVStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    public class ProductItemModel
    {
    }

    #region Lab Name

    public class LabName_Request : BaseEntity
    {
        public string? LabName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class LabName_Response : BaseResponseEntity
    {
        public string? LabName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Machine Name

    public class MachineName_Request : BaseEntity
    {
        public string? MachineName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class MachineName_Response : BaseResponseEntity
    {
        public string? MachineName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Item Name

    public class ItemName_Request : BaseEntity
    {
        public string? ItemName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ItemName_Response : BaseResponseEntity
    {
        public string? ItemName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Category

    public class Category_Request : BaseEntity
    {
        public string? Category { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Category_Response : BaseResponseEntity
    {
        public string? Category { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Sub Category

    public class SubCategory_Request : BaseEntity
    {
        public string? SubCategory { get; set; }

        public bool? IsActive { get; set; }
    }

    public class SubCategory_Response : BaseResponseEntity
    {
        public string? SubCategory { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Storage Location

    public class StorageLocation_Request : BaseEntity
    {
        public string? StorageLocation { get; set; }

        public bool? IsActive { get; set; }
    }

    public class StorageLocation_Response : BaseResponseEntity
    {
        public string? StorageLocation { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Item Status

    public class ItemStatus_Request : BaseEntity
    {
        public string? ItemStatus { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ItemStatus_Response : BaseResponseEntity
    {
        public string? ItemStatus { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region SKU

    public class SKU_Request : BaseEntity
    {
        public string? SKU { get; set; }

        public bool? IsActive { get; set; }
    }

    public class SKU_Response : BaseResponseEntity
    {
        public string? SKU { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Product Master

    public class ProductMaster_Request : BaseEntity
    {
        public int? ItemNameId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ManufacturerId { get; set; }

        [DefaultValue("")]
        public string? Description { get; set; }

        [DefaultValue("")]
        public string? HSNCode { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ProductMaster_Response : BaseResponseEntity
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

        public bool? IsActive { get; set; }
    }

    #endregion
}
