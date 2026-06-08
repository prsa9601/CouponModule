namespace CouponModule.Domain.Coupon.Service
{
    public interface ICouponDomainService
    {
        bool CodeIsDuplicated(string code);
    }
}
