using InvoiceManagement.Api.ApplicationServices.Dtos.OrderDetailDtos;

namespace InvoiceManagement.Api.ApplicationServices.Dtos.OrderHeaderDtos
{
    public class PutOrderHeaderDto
    {
        public Guid OrderHeaderID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
        public List<PutOrderDetailDto> PutOrderDetailDtos { get; set; }
    }
}
