using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Infrastructure.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponModule.Infrastructure.DB.Coupon
{
    internal class CouponRepository : BaseRepository<Domain.Coupon.Coupon>, ICouponRepository
    {
        public CouponRepository(Context context) : base(context)
        {
        }
    }
}
