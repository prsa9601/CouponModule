using CouponModule.Domain.Coupon.Builder;
using CouponModule.Domain.Coupon.Service;
using CouponModule.Domain.Shared;
using System.Data;

namespace CouponModule.Application.Coupon.Builder
{
    public class CouponBuilder : ICouponBuilder
    {
        private string _code;
        private DateTime _expireDate;
        private bool _isActive;
        private long? _minPurchaseAmount;
        private OfferValueObject _offer;

        private readonly ICouponDomainService _service;

        public CouponBuilder(ICouponDomainService service)
        {
            _service = service;
        }

        public Domain.Coupon.Coupon Build()
        {
            var coupon = new Domain.Coupon.Coupon(_code, _expireDate, _service);
            
            if(_offer != default && _offer != null)
                coupon.SetOffer(_offer);

            if(_minPurchaseAmount != null && _minPurchaseAmount!= default)
                coupon.SetMinPurchaseAmount(_minPurchaseAmount);

            if (_isActive!= null)
                    coupon.SetActivity(_isActive);

            return coupon;
        }

        public ICouponBuilder WithCode(string code)
        {
            _code = code;
            return this;
        }

        public ICouponBuilder WithExpireDate(DateTime expireDate)
        {
            _expireDate = expireDate;
            return this;
        }

        public ICouponBuilder WithIsActive(bool isActive)
        {
            _isActive = isActive;
            return this;
        }

        public ICouponBuilder WithMinPurchaseAmount(long? minPurchaseAmount)
        {
            _minPurchaseAmount = minPurchaseAmount;
            return this;
        }

        public ICouponBuilder WithOffer(DiscountType type, int percentage, long amount)
        {
            _offer = new OfferValueObject(type, percentage, amount);
            return this;
        }
    }
}
