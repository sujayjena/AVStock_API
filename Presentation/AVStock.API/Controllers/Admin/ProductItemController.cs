using AVStock.Application.Enums;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Globalization;

namespace AVStock.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IProductItemRepository _productItemRepository;

        public ProductItemController(IProductItemRepository productItemRepository)
        {
            _productItemRepository = productItemRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Lab Name

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLabName(LabName_Request parameters)
        {
            int result = await _productItemRepository.SaveLabName(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLabNameList(BaseSearchEntity parameters)
        {
            IEnumerable<LabName_Response> lstRoles = await _productItemRepository.GetLabNameList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLabNameById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetLabNameById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion

        #region Machine Name

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMachineName(MachineName_Request parameters)
        {
            int result = await _productItemRepository.SaveMachineName(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMachineNameList(BaseSearchEntity parameters)
        {
            IEnumerable<MachineName_Response> lstRoles = await _productItemRepository.GetMachineNameList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMachineNameById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetMachineNameById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion

        #region Item Name

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveItemName(ItemName_Request parameters)
        {
            int result = await _productItemRepository.SaveItemName(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetItemNameList(BaseSearchEntity parameters)
        {
            IEnumerable<ItemName_Response> lstRoles = await _productItemRepository.GetItemNameList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetItemNameById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetItemNameById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
        #endregion

        #region Category

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveCategory(Category_Request parameters)
        {
            int result = await _productItemRepository.SaveCategory(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCategoryList(BaseSearchEntity parameters)
        {
            IEnumerable<Category_Response> lstRoles = await _productItemRepository.GetCategoryList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCategoryById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetCategoryById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Sub Category

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSubCategory(SubCategory_Request parameters)
        {
            int result = await _productItemRepository.SaveSubCategory(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSubCategoryList(BaseSearchEntity parameters)
        {
            IEnumerable<SubCategory_Response> lstRoles = await _productItemRepository.GetSubCategoryList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSubCategoryById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetSubCategoryById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Storage Location

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveStorageLocation(StorageLocation_Request parameters)
        {
            int result = await _productItemRepository.SaveStorageLocation(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetStorageLocationList(BaseSearchEntity parameters)
        {
            IEnumerable<StorageLocation_Response> lstRoles = await _productItemRepository.GetStorageLocationList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetStorageLocationById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetStorageLocationById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Item Status

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveItemStatus(ItemStatus_Request parameters)
        {
            int result = await _productItemRepository.SaveItemStatus(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetItemStatusList(BaseSearchEntity parameters)
        {
            IEnumerable<ItemStatus_Response> lstRoles = await _productItemRepository.GetItemStatusList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetItemStatusById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetItemStatusById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region SKU

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSKU(SKU_Request parameters)
        {
            int result = await _productItemRepository.SaveSKU(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSKUList(BaseSearchEntity parameters)
        {
            IEnumerable<SKU_Response> lstRoles = await _productItemRepository.GetSKUList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSKUById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetSKUById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Product Master

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveProductMaster(ProductMaster_Request parameters)
        {
            int result = await _productItemRepository.SaveProductMaster(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved successfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetProductMasterList(BaseSearchEntity parameters)
        {
            IEnumerable<ProductMaster_Response> lstRoles = await _productItemRepository.GetProductMasterList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetProductMasterById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productItemRepository.GetProductMasterById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion
    }
}
