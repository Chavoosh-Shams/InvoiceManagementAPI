using InvoiceManagement.Api.Models.Frameworks;
using InvoiceManagement.Api.Models.DomainModels.OrderHeaderAggregates;

namespace InvoiceManagement.Api.Models.DomainModels.CustomerAggregates
{
    public class Customer : IDbSetEntity
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public ICollection<OrderHeader> OrderHeaders { get; set; }

        public bool IsDeleted { get; set; }
    }
}