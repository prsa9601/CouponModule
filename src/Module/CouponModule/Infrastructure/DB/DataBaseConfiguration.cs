using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CouponModule.Infrastructure.DB
{
    public static class DataBaseConfiguration
    {
        public static IServiceCollection DataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<Context>(options =>
                options.UseSqlServer(configuration.GetSection("ConnectionStrings")["DefaultConnection"]));

            return services;
        }
    }
}
