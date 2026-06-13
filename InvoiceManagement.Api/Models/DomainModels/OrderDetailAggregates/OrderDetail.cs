using InvoiceManagement.Api.Models.Frameworks;
using InvoiceManagement.Api.Models.DomainModels.ProductAggregates;
using InvoiceManagement.Api.Models.DomainModels.OrderHeaderAggregates;

namespace InvoiceManagement.Api.Models.DomainModels.OrderDetailAggregates
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