using CouponModule.Application.Coupon.Commands.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponModule.Infrastructure.DB
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<Context>();
            var mediatR = scope.ServiceProvider.GetRequiredService<IMediator>();

            // اگر دیتابیس وجود نداشته باشد، ایجادش کن
            await context.Database.EnsureCreatedAsync();

            // بررسی کن که آیا جدول Coupon (یا هر جدول دیگر) خالی است
            if (!context.Coupons.Any())
            {
                // اضافه کردن سه رکورد تصادفی
                var random = new Random();
                var coupons = new List<Domain.Coupon.Coupon>();

                for (int i = 0; i < 3; i++)
                {
                    var command = new CreateCouponCommand
                    {
                        Code = $"RANDOM_{random.Next(100, 999)}",
                        IsActive = true,
                        ExpireDate = DateTime.Now.AddDays(random.Next(1, 30)),
                        MinPurchaseAmount = random.Next(10000, 100000),
                        Percentage = random.Next(5, 50),
                        Amount = random.Next(1000000, 999999999),
                        Type = i % 2 == 0 ? Domain.Coupon.DiscountType.Percentage : Domain.Coupon.DiscountType.FixedAmount,

                    };
                    await mediatR.Send(command);
                }

                await context.Coupons.AddRangeAsync(coupons);
                await context.SaveChangesAsync();
            }
        }
    }
}