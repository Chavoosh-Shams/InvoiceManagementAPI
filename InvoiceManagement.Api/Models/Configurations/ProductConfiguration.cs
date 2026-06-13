using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceManagement.Api.Models.DomainModels.ProductAggregates;

namespace InvoiceManagement.Api.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
