using CouponModule.Application.Shared;
using CouponModule.Domain.Coupon.Repositories;

namespace CouponModule.Application.Coupon.Commands.Remove
{
    public class RemoveCouponCommand : IBaseCommand
    {
        public Guid Id { get; set; }
    }
    public class RemoveCouponCommandHandler : IBaseCommandHandler<RemoveCouponCommand>
    {
        private readonly ICouponRepository _repository;

        public RemoveCouponCommandHandler(ICouponRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveCouponCommand request, CancellationToken cancellationToken)
        {
            bool isSuccess = await _repository.RemoveExpressionAsync(i => i.Id == request.Id);
            await _repository.SaveChangesAsync();
            return isSuccess ? OperationResult.Success() : OperationResult.Error();
        }
    }
}
