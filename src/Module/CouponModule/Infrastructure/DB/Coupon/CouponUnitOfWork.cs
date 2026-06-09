using CouponModule.Domain.Coupon;
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

            long oldPrice = totalPrice;
             totalPrice = DiscountCalculation(totalPrice, coupon.Offer.Type, coupon.Offer.Percentage, coupon.Offer.Amount);

            long offerAmountForReport = coupon.Offer.Type == DiscountType.Percentage ?
                coupon.Offer.Percentage : coupon.Offer.Amount;

            return new CouponApplyDiscountResult(true, $"success: Discount Is Applyed =>" +
                $" total Price without discount {oldPrice} =>" +
                $" total Price with discount {totalPrice} =>" +
                $" offer type is {coupon.Offer.Type.ToString()} => " +
                $" offer amount is {offerAmountForReport}",
                CouponApplyDiscountStatusResult.Success, totalPrice);
        }
        private long DiscountCalculation(long totalPrice, DiscountType type, int pecentageDiscount, long amountDiscount)
        {
            if (type == DiscountType.Percentage)
            {
                long offerAmount = (totalPrice * pecentageDiscount) / 100;
                return totalPrice - offerAmount;
            }

            else if (type == DiscountType.FixedAmount)
            {
                return totalPrice - amountDiscount;
            }
            else 
                return totalPrice;  
        }
    }
}
