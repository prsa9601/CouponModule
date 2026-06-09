namespace CouponModule.Domain.Coupon.Builder
{
    public interface ICouponBuilder
    {
        ICouponBuilder WithCode(string code);
        ICouponBuilder WithExpireDate(DateTime expireDate);
        ICouponBuilder WithIsActive(bool isActive);
        ICouponBuilder WithMinPurchaseAmount(long? minPurchaseAmount);
        ICouponBuilder WithOffer(DiscountType type, int percentage, long amount);

        Coupon Build();
    }
}
