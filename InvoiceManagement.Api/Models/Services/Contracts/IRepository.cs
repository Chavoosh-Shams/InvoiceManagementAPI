using InvoiceManagement.Api.Frameworks.ResponseFrameworks.Contracts;

namespace InvoiceManagement.Api.Models.Services.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IResponse<T>> InsertAsync(T entity);
        Task<IResponse<T>> UpdateAsync(T entity);
        Task<IResponse<T>> DeleteAsync(T entity);
        Task<IResponse<T>> SelectByIdAsync(T entity);
        Task<IResponse<IEnumerable<T>>> SelectAllAsync();
    }
}
