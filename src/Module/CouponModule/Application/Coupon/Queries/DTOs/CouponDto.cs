using CouponModule.Application.Shared.Query;
using CouponModule.Application.Shared.Query.Filter;
using CouponModule.Domain.Shared;

namespace CouponModule.Application.Coupon.Queries.DTOs
{
    public class CouponDto : BaseDto
    {
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
        public long? MinPurchaseAmount { get; set; }

        public OfferValueObject Offer { get; set; }
    }
    public class CouponFilterParam : BaseFilterParam
    {

    }
    public class CouponFilterResult : BaseFilter<CouponDto, CouponFilterParam>
    {

    }

}
