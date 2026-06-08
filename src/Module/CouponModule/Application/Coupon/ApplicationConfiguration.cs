using CouponModule.Application.Coupon.Builder;
using CouponModule.Application.Coupon.Commands.Create;
using CouponModule.Application.Coupon.Queries.GetById;
using CouponModule.Application.Coupon.Service;
using CouponModule.Domain.Coupon.Builder;
using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Domain.Coupon.Service;
using CouponModule.Infrastructure.DB;
using CouponModule.Infrastructure.DB.Coupon;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

namespace CouponModule.Application.Coupon
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ApplicationConfig(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICouponBuilder, CouponBuilder>();
            services.AddScoped<ICouponDomainService, CouponDomainService>();

            //MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationConfiguration).Assembly,
                    typeof(CreateCouponCommandHandler).Assembly
                    , typeof(GetCouponByIdQuery).Assembly
                );
            });
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(YourHandler).Assembly));


            Infrastructure.InfrastructureConfiguration.InfrastructureConfig(services, configuration);
            return services;
        }
    }
}
