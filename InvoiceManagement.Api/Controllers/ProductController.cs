using Microsoft.AspNetCore.Mvc;
using InvoiceManagement.Api.ApplicationServices.Dtos.ProductDtos;
using InvoiceManagement.Api.ApplicationServices.Services.Contracts;

namespace InvoiceManagement.Api.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region [- PrivateField -]
        private readonly IProductApplicationService _productApplicationService;
        private readonly ILogger<CustomerController> _logger;
        #endregion

        #region [- Ctor -]
        public ProductController(IProductApplicationService productApplicationService, ILogger<CustomerController> logger)
        {
            _productApplicationService = productApplicationService;
            _logger = logger;
        }
        #endregion

        #region [- Post() -]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostProductDto postProductDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(
                    "CreateProduct failed due to validation error. Data: {@ModelState}",
                    ModelState);

                return BadRequest(ModelState);
            }

            _logger.LogInformation(
                "CreateProduct request received. ProductName: {ProductName}, UnitPrice: {UnitPrice}",
                postProductDto.ProductName,
                postProductDto.UnitPrice);

            var result = await _productApplicationService.PostAsync(postProductDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "CreateProduct failed. ProductName: {ProductName}, Message: {Message}",
                    postProductDto.ProductName,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Product created successfully. ProductId: {ProductId}, ProductName: {ProductName}",
                result.Value,
                result.Value?.ProductName);

            return Ok(result.Value);
        }
        #endregion

        #region [- Put() -]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutProductDto putProductDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(
                    "UpdateProduct failed due to validation error. Data: {@ModelState}",
                    ModelState);

                return BadRequest(ModelState);
            }

            _logger.LogInformation(
                "UpdateProduct request received. ProductId: {ProductId}, ProductName: {ProductName}, UnitPrice: {UnitPrice}",
                putProductDto.ProductID,
                putProductDto.ProductName,
                putProductDto.UnitPrice);

            var result = await _productApplicationService.PutAsync(putProductDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "UpdateProduct failed. ProductId: {ProductId}, Message: {Message}",
                    putProductDto.ProductID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Product updated successfully. ProductId: {ProductId}",
                result.Value?.ProductID ?? putProductDto.ProductID);

            return Ok(result.Value);
        }
        #endregion

        #region [- Delete() -]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductDto deleteProductDto)
        {
            if (deleteProductDto.ProductID == Guid.Empty)
            {
                _logger.LogWarning(
                    "DeleteProduct request failed due to empty ProductID");

                return BadRequest("Null ProductID!");
            }

            _logger.LogInformation(
                "DeleteProduct request received. ProductId: {ProductId}",
                deleteProductDto.ProductID);

            var result = await _productApplicationService.DeleteAsync(deleteProductDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "DeleteProduct failed. ProductId: {ProductId}, Message: {Message}",
                    deleteProductDto.ProductID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "Product deleted successfully. ProductId: {ProductId}",
                deleteProductDto.ProductID);

            return Ok(result.Value);
        }
        #endregion

        #region [- GetById() -]
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetById([FromQuery] GetProductByIdDto getProductByIdDto)
        {
            if (getProductByIdDto.ProductID == Guid.Empty)
            {
                _logger.LogWarning(
                    "GetProductById failed due to empty ProductID");

                return BadRequest("Null ProductID!");
            }

            _logger.LogInformation(
                "GetProductById request received. ProductId: {ProductId}",
                getProductByIdDto.ProductID);

            var result = await _productApplicationService.GetByIdAsync(getProductByIdDto);

            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    "GetProductById failed. ProductId: {ProductId}, Message: {Message}",
                    getProductByIdDto.ProductID,
                    result.Message);

                return BadRequest(result.Message);
            }

            _logger.LogInformation(
                "GetProductById succeeded. ProductId: {ProductId}",
                getProductByIdDto.ProductID);

            return Ok(result.Value);
        }
        #endregion

        #region [- GetAll() -]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productApplicationService.GetAllAsync();

            var response = result.Value;

            return Ok(response);
        }
        #endregion
    }
}
