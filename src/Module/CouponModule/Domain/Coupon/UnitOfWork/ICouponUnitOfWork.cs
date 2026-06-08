using CouponModule.Domain.Coupon.UnitOfWork.Models;
using CouponModule.Domain.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CouponModule.Domain.Coupon.UnitOfWork
{
    public interface ICouponUnitOfWork
    {
        Task<CouponApplyDiscountResult> ApplyDiscount(long totalPrice, string code);
    }
}
