using CouponModule.Domain.Coupon.Service;
using CouponModule.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CouponModule.Domain.Coupon
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
        public long? MinPurchaseAmount { get; set; }

        public OfferValueObject Offer { get; set; }

        private Coupon()
        {

        }
        public Coupon(string code, DateTime expireDate, ICouponDomainService service)
        {
            Guard(code, service);
            Code = code;
            ExpireDate = expireDate;
        }

        public void Edit(string code, bool isActive, DateTime expireDate, long? minPurchaseAmount, 
            OfferValueObject offer, ICouponDomainService service)
        {
            Guard(code, service);
            Code = code;
            IsActive = isActive;
            ExpireDate = expireDate;
            MinPurchaseAmount = minPurchaseAmount;
            Offer = offer;
        }

        public void SetOffer(OfferValueObject offer)
        {
            Offer = offer;
        }

        public void SetMinPurchaseAmount(long? minPurchaseAmount)
        {
            MinPurchaseAmount = minPurchaseAmount;
        }

        public void ChangeActivity()
        {
            IsActive = IsActive == true ? false : true;
        }
      
        public void SetActivity(bool isActive)
        {
            IsActive = isActive;
        }

        private void Guard(string code, ICouponDomainService service)
        {
            if (code == Code) return;
            else if (service.CodeIsDuplicated(code))
            {
                throw new DuplicateNameException("کد نمیتواند تکراری باشد.");
            }
        }
    }
}
