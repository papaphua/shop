using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Server.DAL.Products;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.HasOne(product => product.ProductType)
            .WithMany(type => type.Products)
            .HasForeignKey(product => product.ProductTypeId);
    }
}