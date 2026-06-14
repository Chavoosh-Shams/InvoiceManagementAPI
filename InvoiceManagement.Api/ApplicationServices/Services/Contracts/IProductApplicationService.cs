using InvoiceManagement.Api.ApplicationServices.Dtos.ProductDtos;

namespace InvoiceManagement.Api.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
         : IApplicationService<PostProductDto, PutProductDto, DeleteProductDto, GetProductByIdDto, GetAllProductDto>
    {

    }
}
