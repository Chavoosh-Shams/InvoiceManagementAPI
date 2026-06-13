using InvoiceManagement.Api.Models.Frameworks;
using InvoiceManagement.Api.Models.DomainModels.CustomerAggregates;
using InvoiceManagement.Api.Models.DomainModels.OrderDetailAggregates;

namespace InvoiceManagement.Api.Models.DomainModels.OrderHeaderAggregates
{
    public class OrderHeader : IDbSetEntity
    {
        public Guid OrderHeaderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }

        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public bool IsDeleted { get; set; }
    }
}