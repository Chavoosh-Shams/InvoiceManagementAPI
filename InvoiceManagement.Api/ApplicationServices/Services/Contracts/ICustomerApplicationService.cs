using InvoiceManagement.Api.ApplicationServices.Dtos.CustomerDtos;

namespace InvoiceManagement.Api.ApplicationServices.Services.Contracts
{
    public interface ICustomerApplicationService
        : IApplicationService<PostCustomerDto, PutCustomerDto, DeleteCustomerDto, GetCustomerByIdDto, GetAllCustomerDto>
    {

    }
}
