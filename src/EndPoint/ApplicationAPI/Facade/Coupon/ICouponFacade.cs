using CouponModule.Application.Coupon.Commands.ApplyDiscount;
using CouponModule.Application.Coupon.Commands.Create;
using CouponModule.Application.Coupon.Commands.Edit;
using CouponModule.Application.Coupon.Commands.Remove;
using CouponModule.Application.Coupon.Queries.DTOs;
using CouponModule.Application.Coupon.Queries.GetById;
using CouponModule.Application.Coupon.Queries.GetFilter;
using CouponModule.Application.Shared;
using MediatR;

namespace ApplicationAPI.Facade.Coupon
{
    public interface ICouponFacade
    {
        Task<OperationResult> Create(CreateCouponCommand command);
        Task<OperationResult> Edit(EditCouponCommand command);
        Task<OperationResult> Remove(Guid id);
        Task<OperationResult<long>> ApplyDiscount(ApplyDiscountCommand command);
        Task<CouponDto?> GetId(Guid id);
        Task<CouponFilterResult> GetFilter(CouponFilterParam param);
    }
    public class CouponFacade : ICouponFacade
    {
        private readonly IMediator _mediator;

        public CouponFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult<long>> ApplyDiscount(ApplyDiscountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateCouponCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditCouponCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CouponFilterResult> GetFilter(CouponFilterParam param)
        {
            return await _mediator.Send(new GetCouponFilterQuery(param));
        }

        public async Task<CouponDto?> GetId(Guid id)
        {
            return await _mediator.Send(new GetCouponByIdQuery(id));
        }

        public async Task<OperationResult> Remove(Guid id)
        {
            return await _mediator.Send(new RemoveCouponCommand
            {
                Id = id,
            });
        }
    }
}
