using InvoiceManagement.Api.Models.Frameworks;
using InvoiceManagement.Api.Models.DomainModels.OrderAggregates;

namespace InvoiceManagement.Api.Models.DomainModels.ProductAggregates
{
    public class Product : IDbSetEntity
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public bool IsDeleted { get; set; }
    }
}
