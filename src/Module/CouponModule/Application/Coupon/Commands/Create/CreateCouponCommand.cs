using CouponModule.Application.Shared;
using CouponModule.Domain.Coupon.Builder;
using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Domain.Shared;
using MediatR;

namespace CouponModule.Application.Coupon.Commands.Create
{
    public class CreateCouponCommand : IBaseCommand
    {
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
        public long? MinPurchaseAmount { get; set; }

        public DiscountType Type { get; set; }
        public int Percentage { get; set; }
        public long Amount { get; set; }

    }
    public class CreateCouponCommandHandler : IBaseCommandHandler<CreateCouponCommand>
    {
        private readonly ICouponRepository _repository;
        private readonly ICouponBuilder _builder;

        public CreateCouponCommandHandler(ICouponRepository repository, ICouponBuilder builder)
        {
            _repository = repository;
            _builder = builder;
        }

        public async Task<OperationResult> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = _builder.WithCode(request.Code).WithExpireDate(request.ExpireDate).
                WithMinPurchaseAmount(request.MinPurchaseAmount).WithIsActive(request.IsActive)
                .WithOffer(request.Type, request.Percentage, request.Amount).Build();

            await _repository.AddAsync(coupon);
            await _repository.SaveChangesAsync();
            return OperationResult.SuccessCreated();
        }
    }
}
