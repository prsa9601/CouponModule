using Azure.Core;
using CouponModule.Application.Coupon.Queries.DTOs;
using CouponModule.Application.Coupon.Queries.GetFilter;
using CouponModule.Application.Shared.Query;
using CouponModule.Infrastructure.DB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CouponModule.Application.Coupon.Queries.GetFilter
{
    public class GetCouponFilterQuery : QueryFilter<CouponFilterResult, CouponFilterParam>
    {
        public GetCouponFilterQuery(CouponFilterParam filterParams) : base(filterParams)
        {
        }
    }
    public class GetCouponFilterQueryHandler : IQueryHandler<GetCouponFilterQuery, CouponFilterResult>
    {
        private readonly Context _context;

        public GetCouponFilterQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<CouponFilterResult> Handle(GetCouponFilterQuery request, CancellationToken cancellationToken)
        {
            var @param = request.FilterParams;
            var result = _context.Coupons.OrderByDescending(i => i.CreationDate).AsQueryable();

            var skip = (@param.PageId - 1) * @param.Take;
            var coupons = await result.Skip(skip).Take(@param.Take)
                .Select(coupon => coupon.Map()).ToListAsync(cancellationToken);

            var model = new CouponFilterResult()
            {
                Data = coupons.Where(i => i != null || i != default).ToList(),
                FilterParams = @param
            };

            model.GeneratePaging(result, @param.Take, @param.PageId);
            return model;
        }
    }
}
