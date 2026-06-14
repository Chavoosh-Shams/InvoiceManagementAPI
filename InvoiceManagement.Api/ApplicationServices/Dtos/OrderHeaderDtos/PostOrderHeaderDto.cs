using InvoiceManagement.Api.ApplicationServices.Dtos.OrderDetailDtos;

namespace InvoiceManagement.Api.ApplicationServices.Dtos.OrderHeaderDtos
{
    public class PostOrderHeaderDto
    {
        public Guid CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
        public List<PostOrderDetailDto> PostOrderDetailDtos { get; set; }
    }
}
