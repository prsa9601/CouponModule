using CouponModule.Application.Coupon.Queries.DTOs;
using CouponModule.Application.Shared.Query;
using CouponModule.Domain.Coupon.Repositories;

namespace CouponModule.Application.Coupon.Queries.GetById
{
    public record GetCouponByIdQuery(Guid id) : IQuery<CouponDto>;

    public class GetCouponByIdQueryHandler : IQueryHandler<GetCouponByIdQuery, CouponDto>
    {
        private readonly ICouponRepository _repository;

        public GetCouponByIdQueryHandler(ICouponRepository repository)
        {
            _repository = repository;
        }

        public async Task<CouponDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _repository.GetByIdAsync(request.id);
            return coupon.Map();
        }
    }
}
