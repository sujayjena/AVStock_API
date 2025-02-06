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
    public class MasterInventoryController : CustomBaseController
    {
        private ResponseModel _response;
        private IFileManager _fileManager;

        private readonly IMasterInventoryRepository _masterInventoryRepository;

        public MasterInventoryController(IFileManager fileManager, IMasterInventoryRepository masterInventoryRepository)
        {
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
            _masterInventoryRepository = masterInventoryRepository;
        }

        #region Inwarding

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveInwarding(Inwarding_Request parameters)
        {
            int result = await _masterInventoryRepository.SaveInwarding(parameters);

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
        public async Task<ResponseModel> GetInwardingList(Inwarding_Search parameters)
        {
            IEnumerable<Inwarding_Response> lstRoles = await _masterInventoryRepository.GetInwardingList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetInwardingById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _masterInventoryRepository.GetInwardingById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion
    }
}
