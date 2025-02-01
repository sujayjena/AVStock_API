using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface IProductItemRepository
    {
        #region Lab Name

        Task<int> SaveLabName(LabName_Request parameters);
        Task<IEnumerable<LabName_Response>> GetLabNameList(BaseSearchEntity parameters);
        Task<LabName_Response?> GetLabNameById(int Id);

        #endregion

        #region Machine Name

        Task<int> SaveMachineName(MachineName_Request parameters);
        Task<IEnumerable<MachineName_Response>> GetMachineNameList(BaseSearchEntity parameters);
        Task<MachineName_Response?> GetMachineNameById(int Id);

        #endregion

        #region Item Name

        Task<int> SaveItemName(ItemName_Request parameters);
        Task<IEnumerable<ItemName_Response>> GetItemNameList(BaseSearchEntity parameters);
        Task<ItemName_Response?> GetItemNameById(int Id);

        #endregion

        #region Category
        Task<int> SaveCategory(Category_Request parameters);

        Task<IEnumerable<Category_Response>> GetCategoryList(BaseSearchEntity parameters);

        Task<Category_Response?> GetCategoryById(int Id);
        #endregion

        #region Sub Category
        Task<int> SaveSubCategory(SubCategory_Request parameters);

        Task<IEnumerable<SubCategory_Response>> GetSubCategoryList(BaseSearchEntity parameters);

        Task<SubCategory_Response?> GetSubCategoryById(int Id);
        #endregion

        #region Storage Location
        Task<int> SaveStorageLocation(StorageLocation_Request parameters);

        Task<IEnumerable<StorageLocation_Response>> GetStorageLocationList(BaseSearchEntity parameters);

        Task<StorageLocation_Response?> GetStorageLocationById(int Id);
        #endregion

        #region Item Status
        Task<int> SaveItemStatus(ItemStatus_Request parameters);

        Task<IEnumerable<ItemStatus_Response>> GetItemStatusList(BaseSearchEntity parameters);

        Task<ItemStatus_Response?> GetItemStatusById(int Id);
        #endregion

        #region SKU
        Task<int> SaveSKU(SKU_Request parameters);

        Task<IEnumerable<SKU_Response>> GetSKUList(BaseSearchEntity parameters);

        Task<SKU_Response?> GetSKUById(int Id);
        #endregion

        #region Product Master
        Task<int> SaveProductMaster(ProductMaster_Request parameters);

        Task<IEnumerable<ProductMaster_Response>> GetProductMasterList(BaseSearchEntity parameters);

        Task<ProductMaster_Response?> GetProductMasterById(int Id);
        #endregion

    }
}
