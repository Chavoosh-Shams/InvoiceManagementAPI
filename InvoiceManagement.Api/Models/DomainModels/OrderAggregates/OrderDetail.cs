using InvoiceManagement.Api.Models.Frameworks;
using InvoiceManagement.Api.Models.DomainModels.ProductAggregates;

namespace InvoiceManagement.Api.Models.DomainModels.OrderAggregates
{
    public class OrderDetail : IDbSetEntity
    {
        public Guid OrderDetailID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Guid OrderHeaderID { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public Guid ProductID { get; set; }
        public Product Product { get; set; }

        public bool IsDeleted { get; set; }
    }
}
