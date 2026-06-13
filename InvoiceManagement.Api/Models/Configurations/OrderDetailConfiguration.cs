using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceManagement.Api.Models.DomainModels.OrderDetailAggregates;

namespace InvoiceManagement.Api.Models.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderDetailID);
            builder.HasIndex(od => new { od.OrderHeaderID, od.ProductID }).IsUnique();

            builder.Property(od => od.UnitPrice).IsRequired();
            builder.Property(od => od.Quantity).IsRequired();

            builder.Property(od => od.IsDeleted).IsRequired();

            builder.HasOne(od => od.OrderHeader)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.OrderHeaderID)
                .IsRequired();

            builder.HasOne(od => od.Product)
                .WithMany(od => od.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .IsRequired();
            builder.HasQueryFilter(od => !od.IsDeleted);
        }
    }
}