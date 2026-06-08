using MediatR;

namespace CouponModule.Application.Shared
{
    public interface IBaseCommand : IRequest<OperationResult>{}
    public interface IBaseCommand<T> : IRequest<OperationResult<T>>{}
    public interface IBaseCommandHandler<TRequest> : IRequestHandler<TRequest, OperationResult> where TRequest : IBaseCommand{}
  
    public interface IBaseCommandHandler<TRequest, TResponse> : 
        IRequestHandler<TRequest, OperationResult<TResponse>> where TRequest : IBaseCommand<TResponse>{}
}
