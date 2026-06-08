using ApplicationAPI.Facade.Coupon;
using CouponModule.Application.Coupon.Commands.ApplyDiscount;
using CouponModule.Application.Coupon.Commands.Create;
using CouponModule.Application.Coupon.Commands.Edit;
using CouponModule.Application.Coupon.Queries.DTOs;
using CouponModule.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponFacade _facade;

        public CouponController(ICouponFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// ساخت کوپن
        /// </summary>
        /// <param name="command"></param>
        /// <returns>OperationResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Link = 'https://localhost:7048/api/Coupon'
        ///     POST 
        ///     {
        ///       "code": "CodeRandom",
        ///       "isActive": true,
        ///       "expireDate": "2026-06-09T01:47:38.9081854+03:30",
        ///       "minPurchaseAmount": 32000,
        ///       "type": 1,
        ///       "percentage": 12,
        ///       "amount": 12000
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<OperationResult> Create(CreateCouponCommand command)
        {
            return await _facade.Create(command);
        }

        /// <summary>
        /// اعتبار سنجی کد تخفیف و اعمال آن روی مبلغ کل
        /// </summary>
        /// <param name="command"></param>
        /// <returns>OperationResult(long)</returns>
        [HttpPost("Validate")]
        public async Task<OperationResult<long>> ApplyDiscount(ApplyDiscountCommand command)
        {
            return await _facade.ApplyDiscount(command);
        }

        /// <summary>
        /// ویرایش کوپن
        /// </summary>
        /// <param name="command"></param>
        /// <returns>OperationResult</returns>
        [HttpPut]
        public async Task<OperationResult> Edit(EditCouponCommand command)
        {
            return await _facade.Edit(command);
        }

        /// <summary>
        /// حذف کوپن
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OperationResult</returns>
        [HttpDelete("Remove/{id:Guid}")]
        public async Task<OperationResult> Remove(Guid id)
        {
            return await _facade.Remove(id);
        }

        /// <summary>
        /// دریافت کوپن با آی دی
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns>کوپن</returns>
        [HttpGet]
        public async Task<CouponDto?> GetId(Guid couponId)
        {
            return await _facade.GetId(couponId);
        }

        /// <summary>
        /// دریافت کوپن ها به صورت فیلتر شده
        /// </summary>
        /// <param name="param"></param>
        /// <returns>لیستی از کوپن ها به صورت paginations</returns>
        [HttpGet("GetFilter")]
        public async Task<CouponFilterResult> GetFilter([FromQuery] CouponFilterParam param)
        {
            return await _facade.GetFilter(param);
        }

    }
}
