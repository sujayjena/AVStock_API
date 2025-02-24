using AVStock.Application.Enums;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVStock.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IProductDetailsRepository _productDetailsRepository;

        public ProductDetailsController(IProductDetailsRepository productDetailsRepository)
        {
            _productDetailsRepository = productDetailsRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveProductDetails(ProductDetails_Request parameters)
        {
            int result = await _productDetailsRepository.SaveProductDetails(parameters);

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
        public async Task<ResponseModel> GetProductDetailsList(BaseSearchEntity parameters)
        {
            IEnumerable<ProductDetails_Response> lstRoles = await _productDetailsRepository.GetProductDetailsList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetProductDetailsById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _productDetailsRepository.GetProductDetailsById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
