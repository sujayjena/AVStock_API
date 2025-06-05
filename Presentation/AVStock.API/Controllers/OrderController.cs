using AVStock.API.CustomAttributes;
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
    public class OrderController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IOrderRepository _orderRepository;
        private IFileManager _fileManager;

        public OrderController(IOrderRepository orderRepository, IFileManager fileManager)
        {
            _orderRepository = orderRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> SaveOrder(Order_Request parameters)
        {
            int result = await _orderRepository.SaveOrder(parameters);

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

                foreach(var item in parameters.OrderDetailsList)
                {
                    var vOrderDetails_Request = new OrderDetails_Request();
                    vOrderDetails_Request.Id = item.Id;
                    vOrderDetails_Request.OrderId = result;
                    vOrderDetails_Request.ServiceId = item.ServiceId;
                    vOrderDetails_Request.IsActive = item.IsActive;

                    var vOrderDetails = await _orderRepository.SaveOrderDetails(vOrderDetails_Request);
                }
            }

            _response.Id = result;
            return _response;

        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> GetOrderList(Order_Search parameters)
        {
            var objList = await _orderRepository.GetOrderList(parameters);
            _response.Data = objList.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> GetOrderById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _orderRepository.GetOrderById(Id);
                if (vResultObj != null)
                {
                    var orderD = new OrderDetails_Search();
                    orderD.OrderId = vResultObj.Id;

                    var vOrderD = await _orderRepository.GetOrderDetailsList(orderD);
                    vResultObj.OrderDetailsList = vOrderD.ToList();
                }

                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
