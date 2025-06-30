using AVStock.API.CustomAttributes;
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
    public class SampleTypeController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ISampleTypeRepository _sampleTypeRepository;

        public SampleTypeController(ISampleTypeRepository sampleTypeRepository)
        {
            _sampleTypeRepository = sampleTypeRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> SaveSampleType(SampleType_Request parameters)
        {
            int result = await _sampleTypeRepository.SaveSampleType(parameters);

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
        public async Task<ResponseModel> GetSampleTypeList(BaseSearchEntity parameters)
        {
            IEnumerable<SampleType_Response> lstRoles = await _sampleTypeRepository.GetSampleTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSampleTypeById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _sampleTypeRepository.GetSampleTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
