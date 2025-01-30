﻿using AVStock.Application.Models;
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

        /*
       

        #region Segment
        Task<int> SaveSegment(Segment_Request parameters);

        Task<IEnumerable<Segment_Response>> GetSegmentList(BaseSearchEntity parameters);

        Task<Segment_Response?> GetSegmentById(int Id);
        #endregion

        #region Sub Segment
        Task<int> SaveSubSegment(SubSegment_Request parameters);

        Task<IEnumerable<SubSegment_Response>> GetSubSegmentList(BaseSearchEntity parameters);

        Task<SubSegment_Response?> GetSubSegmentById(int Id);
        #endregion

        #region Cell Chemistry
        Task<int> SaveCellChemistry(CellChemistry_Request parameters);

        Task<IEnumerable<CellChemistry_Response>> GetCellChemistryList(BaseSearchEntity parameters);

        Task<CellChemistry_Response?> GetCellChemistryById(int Id);
        #endregion

        #region Product Speces
        Task<int> SaveProductSpeces(ProductSpeces_Request parameters);

        Task<IEnumerable<ProductSpeces_Response>> GetProductSpecesList(BaseSearchEntity parameters);

        Task<ProductSpeces_Response?> GetProductSpecesById(int Id);
        #endregion

        #region Item Category
        Task<int> SaveItemCategory(ItemCategory_Request parameters);

        Task<IEnumerable<ItemCategory_Response>> GetItemCategoryList(BaseSearchEntity parameters);

        Task<ItemCategory_Response?> GetItemCategoryById(int Id);
        #endregion

        #region Item Description
        Task<int> SaveItemDescription(ItemDescription_Request parameters);

        Task<IEnumerable<ItemDescription_Response>> GetItemDescriptionList(BaseSearchEntity parameters);

        Task<ItemDescription_Response?> GetItemDescriptionById(int Id);
        #endregion

        #region Product Type
        Task<int> SaveProductType(ProductType_Request parameters);

        Task<IEnumerable<ProductType_Response>> GetProductTypeList(BaseSearchEntity parameters);

        Task<ProductType_Response?> GetProductTypeById(int Id);
        #endregion

        #region Product Make
        Task<int> SaveProductMake(ProductMake_Request parameters);

        Task<IEnumerable<ProductMake_Response>> GetProductMakeList(BaseSearchEntity parameters);

        Task<ProductMake_Response?> GetProductMakeById(int Id);
        #endregion

        #region Product Model
        Task<int> SaveProductModel(ProductModel_Request parameters);

        Task<IEnumerable<ProductModel_Response>> GetProductModelList(BaseSearchEntity parameters);

        Task<ProductModel_Response?> GetProductModelById(int Id);
        #endregion

        #region BMS Make
        Task<int> SaveBMSMake(BMSMake_Request parameters);

        Task<IEnumerable<BMSMake_Response>> GetBMSMakeList(BaseSearchEntity parameters);

        Task<BMSMake_Response?> GetBMSMakeById(int Id);
        #endregion

        #region Type of BMS
        Task<int> SaveTypeOfBMS(TypeOfBMS_Request parameters);

        Task<IEnumerable<TypeOfBMS_Response>> GetTypeOfBMSList(BaseSearchEntity parameters);

        Task<TypeOfBMS_Response?> GetTypeOfBMSById(int Id);
        #endregion

        #region Battery Physical Status
        Task<int> SaveBatteryPhysicalStatus(BatteryPhysicalStatus_Request parameters);

        Task<IEnumerable<BatteryPhysicalStatus_Response>> GetBatteryPhysicalStatusList(BaseSearchEntity parameters);

        Task<BatteryPhysicalStatus_Response?> GetBatteryPhysicalStatusById(int Id);
        #endregion
        */
    }
}
