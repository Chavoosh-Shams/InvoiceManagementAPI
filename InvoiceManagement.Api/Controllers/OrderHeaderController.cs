using Microsoft.AspNetCore.Mvc;
using InvoiceManagement.Api.ApplicationServices.Services.Contracts;
using InvoiceManagement.Api.ApplicationServices.Dtos.OrderHeaderDtos;

namespace InvoiceManagement.Api.Controllers
{
    [Route("api/OrderHeader")]
    [ApiController]
    public class OrderHeaderController : ControllerBase
    {
        #region [- PrivateField -]
        private readonly IOrderHeaderApplicationService _orderHeaderApplicationService;
        private readonly ILogger<OrderHeaderController> _logger;
        #endregion

        #region [- Ctor -]
        public OrderHeaderController(IOrderHeaderApplicationService orderHeaderApplicationService, ILogger<OrderHeaderController> logger)
        {
            _orderHeaderApplicationService = orderHeaderApplicationService;
            _logger = logger;
        }
        #endregion

        #region [- Post() -]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostOrderHeaderDto postOrderHeaderDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(
                    "CreateOrder request failed due to validation error. Data: {@ModelState}",
                    ModelState);

                return BadRequest(ModelState);
            }

            _logger.LogInformation(
                "CreateOrder request received. CustomerId: {CustomerId}, OrderDate: {OrderDate}",
                postOrderHeaderDto.CustomerID,
                postOrderHeaderDto.OrderDate);

            var result = await _orderHeaderApplicationService.PostAsync(postOrderHeaderDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "CreateOrder failed. CustomerId: {CustomerId}, Message: {Message}",
                    postOrderHeaderDto.CustomerID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Order created successfully. OrderId: {OrderId}, CustomerId: {CustomerId}",
                result.Value,
                result.Value?.CustomerID);

            return Ok(result.Value);
        }
        #endregion

        #region [- Put() -]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutOrderHeaderDto putOrderHeaderDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(
                    "UpdateOrder request failed due to validation error. Data: {@ModelState}",
                    ModelState);

                return BadRequest(ModelState);
            }

            _logger.LogInformation(
                "UpdateOrder request received. OrderId: {OrderId}, CustomerId: {CustomerId}",
                putOrderHeaderDto.OrderHeaderID,
                putOrderHeaderDto.CustomerID);

            var result = await _orderHeaderApplicationService.PutAsync(putOrderHeaderDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "UpdateOrder failed. OrderId: {OrderId}, Message: {Message}",
                    putOrderHeaderDto.OrderHeaderID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Order updated successfully. OrderId: {OrderId}",
                result.Value?.OrderHeaderID ?? putOrderHeaderDto.OrderHeaderID);

            return Ok(result.Value);
        }
        #endregion

        #region [- Delete() -]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderHeaderDto deleteOrderHeaderDto)
        {
            if (deleteOrderHeaderDto.OrderHeaderID == Guid.Empty)
            {
                _logger.LogWarning(
                    "DeleteOrder request failed due to empty OrderHeaderID");

                return BadRequest("Null OrderHeaderID!");
            }

            _logger.LogInformation(
                "DeleteOrder request received. OrderHeaderId: {OrderHeaderId}",
                deleteOrderHeaderDto.OrderHeaderID);

            var result = await _orderHeaderApplicationService.DeleteAsync(deleteOrderHeaderDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "DeleteOrder failed. OrderHeaderId: {OrderHeaderId}, Message: {Message}",
                    deleteOrderHeaderDto.OrderHeaderID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Order deleted successfully. OrderHeaderId: {OrderHeaderId}",
                deleteOrderHeaderDto.OrderHeaderID);

            return Ok(result.Value);
        }
        #endregion

        #region [- GetById() -]
        [HttpGet("GetOrderHeaderByIdDto")]
        public async Task<IActionResult> GetById([FromQuery] GetOrderHeaderByIdDto getOrderHeaderByIdDto)
        {

            if (getOrderHeaderByIdDto.OrderHeaderID == Guid.Empty)
            {
                _logger.LogWarning(
                    "GetOrderById failed due to empty OrderHeaderID");

                return BadRequest("Null OrderHeaderID");
            }

            _logger.LogInformation(
                "GetOrderById request received. OrderHeaderId: {OrderHeaderId}",
                getOrderHeaderByIdDto.OrderHeaderID);

            var result = await _orderHeaderApplicationService.GetByIdAsync(getOrderHeaderByIdDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "GetOrderById failed. OrderHeaderId: {OrderHeaderId}, Message: {Message}",
                    getOrderHeaderByIdDto.OrderHeaderID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "GetOrderById succeeded. OrderHeaderId: {OrderHeaderId}",
                getOrderHeaderByIdDto.OrderHeaderID);

            return Ok(result.Value);
        }
        #endregion

        #region [- GetAll() -]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderHeaderApplicationService.GetAllAsync();

            var response = result.Value;

            return Ok(response);
        }
        #endregion
    }
}
