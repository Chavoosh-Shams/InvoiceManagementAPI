using InvoiceManagement.Api.ApplicationServices.Dtos.OrderHeaderDtos;

namespace InvoiceManagement.Api.ApplicationServices.Services.Contracts
{
    public interface IOrderHeaderApplicationService
        : IApplicationService<PostOrderHeaderDto, PutOrderHeaderDto, DeleteOrderHeaderDto, GetOrderHeaderByIdDto, GetAllOrderHeaderDto>
    {

    }
}
