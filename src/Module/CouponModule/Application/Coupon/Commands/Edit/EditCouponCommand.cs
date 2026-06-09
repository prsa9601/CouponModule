using CouponModule.Application.Shared;
using CouponModule.Domain.Coupon;
using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Domain.Coupon.Service;

namespace CouponModule.Application.Coupon.Commands.Edit
{
    public class EditCouponCommand : IBaseCommand
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
        public long? MinPurchaseAmount { get; set; }


        public DiscountType Type { get; set; }
        public int Percentage { get; set; }
        public long Amount { get; set; }
    }
    public class EditCouponCommandHandler : IBaseCommandHandler<EditCouponCommand>
    {
        private readonly ICouponRepository _repository;
        private readonly ICouponDomainService _service;

        public EditCouponCommandHandler(ICouponRepository repository, ICouponDomainService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(EditCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _repository.GetByIdAsync(request.Id);
            coupon.Edit(request.Code, request.IsActive, request.ExpireDate, request.MinPurchaseAmount, 
                new OfferValueObject(request.Type, request.Percentage, request.Amount), _service);

            await _repository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}
