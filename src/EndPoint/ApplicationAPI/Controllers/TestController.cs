using ApplicationAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// پرتاب اسنثتا
        /// </summary>
        [HttpGet("error")]
        public void Error()
        {
            RandomExceptionGenerator.ThrowRandom();
        }

        /// <summary>
        /// یک اکسپایر دیت سی دقیقه ای برای استفاده در متد ساخت کوپن بهمون میده
        /// </summary>
        /// <returns>یک اکسپایر دیت سی دقیقه ای</returns>
        [HttpGet("GetExpireDate")]
        public DateTime GetExpireDate()
        {
            return DateTime.Now.AddMinutes(30);
        }
    }
}
