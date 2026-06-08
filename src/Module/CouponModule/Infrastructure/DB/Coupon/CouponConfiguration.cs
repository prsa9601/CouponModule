using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CouponModule.Infrastructure.DB.Coupon
{
    public class CouponConfiguration : IEntityTypeConfiguration<Domain.Coupon.Coupon>
    {
        public void Configure(EntityTypeBuilder<Domain.Coupon.Coupon> builder)
        {
            builder.OwnsOne(b => b.Offer, offer =>
            {
            });
            builder.HasIndex(i => i.Code).IsUnique();
            builder.Property(i => i.Code).IsRequired().HasMaxLength(10);
            builder.Property(i => i.MinPurchaseAmount).IsRequired(false).HasDefaultValue((long)0);
        }
    }
}
