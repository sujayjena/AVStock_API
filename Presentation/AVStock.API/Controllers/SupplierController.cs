using AVStock.Application.Enums;
using AVStock.Application.Helpers;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : CustomBaseController
    {
        private ResponseModel _response;
        private IFileManager _fileManager;

        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(IFileManager fileManager, ISupplierRepository supplierRepository)
        {
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
            _supplierRepository = supplierRepository;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSupplier(Supplier_Request parameters)
        {
            int result = await _supplierRepository.SaveSupplier(parameters);

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
                _response.Message = "Record details saved sucessfully";
            }

            _response.Id = result;
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSupplierList(Supplier_Search parameters)
        {
            IEnumerable<Supplier_Response> lstRoles = await _supplierRepository.GetSupplierList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSupplierById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _supplierRepository.GetSupplierById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
