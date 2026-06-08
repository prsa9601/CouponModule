using CouponModule.Domain.Coupon.Repositories;
using CouponModule.Domain.Coupon.UnitOfWork;
using CouponModule.Infrastructure.DB;
using CouponModule.Infrastructure.DB.Coupon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponModule.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection InfrastructureConfig(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<ICouponUnitOfWork, CouponUnitOfWork>();
            services.DataBaseConfig(configuration);

            return services;
        }
    }
}
