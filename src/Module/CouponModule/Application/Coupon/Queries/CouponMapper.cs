using CouponModule.Application.Coupon.Queries.DTOs;

namespace CouponModule.Application.Coupon.Queries
{
    public static class CouponMapper
    {
        public static CouponDto Map(this Domain.Coupon.Coupon coupon)
        {
            if (coupon == null || coupon == default)
                return null;
            return new CouponDto
            {
                CreationDate = coupon.CreationDate,
                ExpireDate = coupon.ExpireDate,
                Code = coupon.Code,
                Id = coupon.Id,
                IsActive = coupon.IsActive,
                MinPurchaseAmount = coupon.MinPurchaseAmount,
                Offer = coupon.Offer,
            };
        }
    }
}
