using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Domain.Coupon.UnitOfWork;
using CouponModule.Domain.Coupon.UnitOfWork.Models;

namespace CouponModule.Infrastructure.DB.Coupon
{
    internal class CouponUnitOfWork : ICouponUnitOfWork
    {
        private readonly ICouponRepository _repository;
        private readonly Context _context;

        public CouponUnitOfWork(ICouponRepository repository, Context context)
        {
            _repository = repository;
            _context = context;
        }
        /// <summary>
        /// چک کردن validate های کوپن و در صورت اوکی بودن اعمال تخفیف 
        /// </summary>
        /// <param name="totalPrice"></param>
        /// <param name="code"></param>
        /// <returns> مقدار نهایی قیمت با اعمال تخفیف</returns>
        public async Task<CouponApplyDiscountResult> ApplyDiscount(long totalPrice, string code)
        {
            var coupon = await _repository.GetFilterAsync(i => i.Code.Equals(code));

            if (coupon == null)
                return new CouponApplyDiscountResult(false, "notFound: coupon is notFound", 
                    CouponApplyDiscountStatusResult.Success, totalPrice);

            if (coupon.MinPurchaseAmount > totalPrice)
                return new CouponApplyDiscountResult(false, "badRequest: The purchase amount is too small for this discount.",
                    CouponApplyDiscountStatusResult.BadRequest, totalPrice);

            if (coupon.ExpireDate < DateTime.Now)
                return new CouponApplyDiscountResult(false, "badRequest: tokenIsExpired",
                    CouponApplyDiscountStatusResult.BadRequest, totalPrice);

            if (!coupon.IsActive)
                return new CouponApplyDiscountResult(false, "badRequest: tokenIsNotActive",
                CouponApplyDiscountStatusResult.BadRequest, totalPrice);

            if (coupon.Offer.Type == Domain.Shared.DiscountType.Percentage)
            {
                int offerPercentage = coupon.Offer.Percentage;
                long offerAmount = (totalPrice * offerPercentage) / 100;
                totalPrice = totalPrice - offerAmount;
            }

            else if (coupon.Offer.Type == Domain.Shared.DiscountType.FixedAmount)
            {
                long offerPercentage = coupon.Offer.Amount;
                totalPrice = totalPrice - offerPercentage;
            }
            long offerAmountForReport = coupon.Offer.Type == Domain.Shared.DiscountType.Percentage ?
                coupon.Offer.Percentage : coupon.Offer.Amount;

            return new CouponApplyDiscountResult(true, $"success: Discount Is Applyed =>" +
                $" total Price with discount {totalPrice} =>" +
                $" offer type is {coupon.Offer.Type.ToString()} => " +
                $" offer amount is {offerAmountForReport}",
                CouponApplyDiscountStatusResult.Success, totalPrice);
        }
    }
}
