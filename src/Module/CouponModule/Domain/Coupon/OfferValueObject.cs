using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace CouponModule.Domain.Coupon
{
    public class OfferValueObject
    {
        public DiscountType Type { get; set; }
        public int Percentage { get; set; }
        public long Amount { get; set; }

        public OfferValueObject(DiscountType discountType, int percentage, long amount)
        {
            Type = discountType;
            this.Percentage = percentage;
            Amount = amount;
        }
        private OfferValueObject()
        {
            
        }
    }
    public enum DiscountType
    {
        FixedAmount,
        Percentage
    }
}
