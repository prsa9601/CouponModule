using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Domain.Coupon.Service;
using CouponModule.Infrastructure.DB;

namespace CouponModule.Application.Coupon.Service
{
    public class CouponDomainService : ICouponDomainService
    {
        private readonly Context _context;

        public CouponDomainService(Context context)
        {
            _context = context;
        }

        public bool CodeIsDuplicated(string code)
        {
            return _context.Coupons.Any(i => i.Code == code);
        }
    }
}
