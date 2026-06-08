using CouponModule.Application.Shared;
using CouponModule.Domain.Coupon.UnitOfWork;

namespace CouponModule.Application.Coupon.Commands.ApplyDiscount
{
    public class ApplyDiscountCommand : IBaseCommand<long>
    {
        public string CouponCode { get; set; }
        public long PurchaseAmount { get; set; }
    }
    public class ApplyDiscountCommandHandler : IBaseCommandHandler<ApplyDiscountCommand, long>
    {
        private readonly ICouponUnitOfWork _unitOfWork;

        public ApplyDiscountCommandHandler(ICouponUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<long>> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ApplyDiscount(request.PurchaseAmount, request.CouponCode);

            return result.statusCode switch
            {
                Domain.Coupon.UnitOfWork.Models.CouponApplyDiscountStatusResult.Success
                => OperationResult<long>.Success(result.priceResult, result.message),
                
                Domain.Coupon.UnitOfWork.Models.CouponApplyDiscountStatusResult.BadRequest
                => OperationResult<long>.BadRequest(result.priceResult, result.message),
                
                Domain.Coupon.UnitOfWork.Models.CouponApplyDiscountStatusResult.NotFound
                => OperationResult<long>.NotFound(result.priceResult, result.message),

                _ => throw new Exception("Server Error")
            };
        }
    }
}
