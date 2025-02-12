using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Server.DAL.CartItems;

public sealed class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(item => item.Id);

        builder.HasOne(item => item.User)
            .WithMany(user => user.CartItems)
            .HasForeignKey(item => item.UserId);

        builder.HasOne(item => item.Product)
            .WithMany(product => product.CartItems)
            .HasForeignKey(item => item.ProductId);
    }
}