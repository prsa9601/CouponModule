namespace CouponModule.Domain.Coupon.UnitOfWork.Models
{
    public record CouponApplyDiscountResult(bool isSuccess, string message, 
        CouponApplyDiscountStatusResult statusCode, long priceResult);
    
    public enum CouponApplyDiscountStatusResult
    {
        Success,
        Error,
        NotFound,
        BadRequest,
    }
}
