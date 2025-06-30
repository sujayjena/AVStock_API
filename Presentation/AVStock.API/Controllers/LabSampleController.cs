using AVStock.API.CustomAttributes;
using AVStock.Application.Enums;
using AVStock.Application.Helpers;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabSampleController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ILabSampleRepository _LabSampleRepository;
        private IFileManager _fileManager;

        public LabSampleController(ILabSampleRepository LabSampleRepository, IFileManager fileManager)
        {
            _LabSampleRepository = LabSampleRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> SaveLabSample(LabSample_Request parameters)
        {
            int result = await _LabSampleRepository.SaveLabSample(parameters);

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

                foreach (var item in parameters.sampleDetailsList)
                {
                    var vLabSampleDetails_Request = new LabSampleDetails_Request();
                    vLabSampleDetails_Request.Id = item.Id;
                    vLabSampleDetails_Request.LabSampleId = result;
                    vLabSampleDetails_Request.TestId = item.TestId;
                    vLabSampleDetails_Request.IsActive = item.IsActive;

                    var vLabSampleDetails = await _LabSampleRepository.SaveLabSampleDetails(vLabSampleDetails_Request);
                }
            }

            _response.Id = result;
            return _response;

        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> GetLabSampleList(LabSample_Search parameters)
        {
            var objList = await _LabSampleRepository.GetLabSampleList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> GetLabSampleById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _LabSampleRepository.GetLabSampleById(Id);
                if (vResultObj != null)
                {
                    var LabSampleD = new LabSampleDetails_Search();
                    LabSampleD.LabSampleId = vResultObj.Id;

                    var vLabSampleD = await _LabSampleRepository.GetLabSampleDetailsList(LabSampleD);
                    vResultObj.sampleDetailsList = vLabSampleD.ToList();
                }

                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
