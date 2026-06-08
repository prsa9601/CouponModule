using CouponModule.Application.Shared.Query.Filter;
using MediatR;

namespace CouponModule.Application.Shared.Query
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {
    }
    public interface IQueryRequest<TResponse> : IRequest<TResponse>
    {
    }

    public class QueryFilter<TResponse, TParam> : IQuery<TResponse>
    where TResponse : BaseFilter
    where TParam : BaseFilterParam
    {
        public TParam FilterParams { get; set; }
        public QueryFilter(TParam filterParams)
        {
            FilterParams = filterParams;
        }
    }

    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TResponse : class
        where TRequest : IQuery<TResponse>
    {

    }
    public interface IQueryRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQueryRequest<TResponse>
    {

    }

}
