﻿using AVStock.Application.Enums;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVStock.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierTypeController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ISupplierTypeRepository _supplierTypeRepository;

        public SupplierTypeController(ISupplierTypeRepository supplierTypeRepository)
        {
            _supplierTypeRepository = supplierTypeRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSupplierType(SupplierType_Request parameters)
        {
            int result = await _supplierTypeRepository.SaveSupplierType(parameters);

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
        public async Task<ResponseModel> GetSupplierTypeList(BaseSearchEntity parameters)
        {
            IEnumerable<SupplierType_Response> lstRoles = await _supplierTypeRepository.GetSupplierTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSupplierTypeById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _supplierTypeRepository.GetSupplierTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
