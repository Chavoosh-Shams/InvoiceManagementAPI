using Microsoft.AspNetCore.Mvc;
using InvoiceManagement.Api.ApplicationServices.Dtos.CustomerDtos;
using InvoiceManagement.Api.ApplicationServices.Services.Contracts;

namespace InvoiceManagement.Api.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region [- PrivateField -]
        private readonly ICustomerApplicationService _customerApplicationService;
        private readonly ILogger<CustomerController> _logger;
        #endregion

        #region [- Ctor -]
        public CustomerController(ICustomerApplicationService customerApplicationService, ILogger<CustomerController> logger)
        {
            _customerApplicationService = customerApplicationService;
            _logger = logger;
        }
        #endregion

        #region [- Post() -]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCustomerDto postCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Validation failed for PostCustomerDto: {@ModelState}", ModelState);
                return BadRequest(ModelState);
            }
                

            var result = await _customerApplicationService.PostAsync(postCustomerDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning("Customer creation failed: {Message}", result.Message);
                return BadRequest(result.Message);
            }

            var response = result.Value;

            _logger.LogInformation("Customer created successfully. CustomerId: {CustomerId}", result.Value);

            return Ok(response);
        }
        #endregion

        #region [- Put() -]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutCustomerDto putCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(
                    "Validation failed while updating customer. Data: {@ModelState}",
                    ModelState);

                return BadRequest(ModelState);
            }

            var result = await _customerApplicationService.PutAsync(putCustomerDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "Customer update failed. Message: {Message}, CustomerId: {CustomerId}",
                    result.Message,
                    putCustomerDto.CustomerID);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Customer updated successfully. CustomerId: {CustomerId}",
                result.Value?.CustomerID ?? putCustomerDto.CustomerID);

            return Ok(result.Value);
        }
        #endregion

        #region [- Delete() -]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerDto deleteCustomerDto)
        {
            if (deleteCustomerDto.CustomerID == Guid.Empty)
            {
                _logger.LogWarning(
                    "DeleteCustomer request failed due to empty CustomerID");

                return BadRequest("Null CustomerID!");
            }

            _logger.LogInformation(
                "DeleteCustomer request received. CustomerId: {CustomerId}",
                deleteCustomerDto.CustomerID);

            var result = await _customerApplicationService.DeleteAsync(deleteCustomerDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "Customer deletion failed. CustomerId: {CustomerId}, Message: {Message}",
                    deleteCustomerDto.CustomerID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Customer deleted successfully. CustomerId: {CustomerId}",
                deleteCustomerDto.CustomerID);

            return Ok(result.Value);
        }
        #endregion

        #region [- GetById() -]
        [HttpGet("GetCustomerByIdDto")]
        public async Task<IActionResult> GetById([FromQuery] GetCustomerByIdDto getCustomerByIdDto)
        {
            if (getCustomerByIdDto.CustomerID == Guid.Empty)
            {
                _logger.LogWarning(
                    "GetCustomerById failed due to empty CustomerID");

                return BadRequest("Null CustomerID");
            }

            _logger.LogInformation(
                "GetCustomerById request received. CustomerId: {CustomerId}",
                getCustomerByIdDto.CustomerID);

            var result = await _customerApplicationService.GetByIdAsync(getCustomerByIdDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "GetCustomerById failed. CustomerId: {CustomerId}, Message: {Message}",
                    getCustomerByIdDto.CustomerID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "GetCustomerById succeeded. CustomerId: {CustomerId}",
                getCustomerByIdDto.CustomerID);

            return Ok(result.Value);
        }
        #endregion

        #region [- GetAll() -]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerApplicationService.GetAllAsync();

            var response = result.Value;

            return Ok(response);
        }
        #endregion
    }
}
