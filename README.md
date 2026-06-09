API مدیریت کوپن
یک API RESTful با ASP.NET Core برای مدیریت کوپن‌های تخفیف. این API نقاط پایانی برای ساخت، اعتبارسنجی، ویرایش، حذف و دریافت کوپن‌ها به همراه یک نقطه پایانی تست برای شبیه‌سازی استثناهای تصادفی فراهم می‌کند.

🚀 فناوری‌های استفاده شده
.NET 10 (یا .NET 8+)

ASP.NET Core Web API

Swagger / OpenAPI

Entity Framework Core (بر اساس ساختار ماژول)

میان‌افزار سفارشی مدیریت خطا

📦 پیش‌نیازها
.NET 10 SDK (یا جدیدتر)

یک پایگاه داده سازگار (SQL Server، PostgreSQL و ...) – که در CouponModule تنظیم می‌شود

🔧 نصب و اجرا
کلون کردن مخزن

bash
git clone https://github.com/your-repo/coupon-api.git
cd coupon-api
بازگرداندن وابستگی‌ها

bash
dotnet restore
تنظیم رشته اتصال پایگاه داده
فایل appsettings.json را با تنظیمات پایگاه داده خود ویرایش کنید.

اعمال مهاجرت‌ها (در صورت استفاده از مهاجرت)

bash
dotnet ef database update
اجرای برنامه

bash
dotnet run --project src/EndPoint/ApplicationAPI
باز کردن Swagger UI در آدرس:
https://localhost:7048/swagger

📚 نقاط پایانی API
همه نقاط پایانی با پیشوند /api/[controller] در دسترس هستند.

🧪 کنترلر تست (TestController)
متد	آدرس	توضیحات
GET	/api/Test/error	پرتاب یک استثنای تصادفی (برای تست مدیریت خطا)
GET	/api/Test/GetExpireDate	بازگرداندن تاریخ فعلی + ۳۰ دقیقه (ابزاری برای محاسبه انقضای کوپن)
🎟️ کنترلر کوپن (CouponController)
متد	آدرس	توضیحات
POST	/api/Coupon	ساخت کوپن جدید
POST	/api/Coupon/Validate	اعتبارسنجی کد تخفیف و اعمال تخفیف بر روی مبلغ خرید
PUT	/api/Coupon	ویرایش کوپن موجود
DELETE	/api/Coupon/Remove/{id}	حذف کوپن با شناسه GUID
GET	/api/Coupon?couponId={id}	دریافت یک کوپن با شناسه
GET	/api/Coupon/GetFilter	دریافت لیست صفحه‌بندی شده/فیلتر شده کوپن‌ها (پارامترهای کوئری)
📝 نمونه درخواست‌ها
1. ساخت کوپن
http
POST /api/Coupon
Content-Type: application/json

{
  "code": "SUMMER30",
  "isActive": true,
  "expireDate": "2026-12-31T23:59:59",
  "minPurchaseAmount": 50000,
  "type": 1,
  "percentage": 30,
  "amount": 0
}
2. اعتبارسنجی و اعمال تخفیف
http
POST /api/Coupon/Validate
Content-Type: application/json

{
  "couponCode": "SUMMER30",
  "purchaseAmount": 120000
}
پاسخ (موفق):

json
{
  "isSuccess": true,
  "data": 84000,   // مبلغ نهایی پس از تخفیف
  "message": "تخفیف با موفقیت اعمال شد"
}
3. دریافت کوپن‌های فیلتر شده
http
GET /api/Coupon/GetFilter?page=1&pageSize=10&isActive=true
⚠️ مدیریت خطا
API شامل یک هندلر سراسری خطا (CouponAPIExceptionHandler) است که استثناهای مدیریت نشده را می‌گیرد و یک پاسخ JSON استاندارد برمی‌گرداند:

json
{
  "statusCode": 400,
  "exception": "ArgumentException",
  "message": "کد کوپن نمی‌تواند خالی باشد"
}

برای تست این هندلر از نقطه پایانی `TestController/error` استفاده کنید تا انواع مختلف استثنا را شبیه‌سازی کنید.

---

## 🛠️ نکات توسعه

- **مستندسازی XML**: مستندات Swagger با XML پشتیبانی می‌شود. برای تولید فایل XML، مقدار `<GenerateDocumentationFile>true</GenerateDocumentationFile>` را در فایل `.csproj` خود تنظیم کنید.
- **مدل پاسخ**: بیشتر نقاط پایانی `OperationResult` یا `OperationResult<T>` را برمی‌گردانند که شامل `IsSuccess`، `Message` و `Data` اختیاری است.
- **الگوی Facade**: منطق کسب‌وکار در `ICouponFacade` کپسوله شده است (پیاده‌سازی در `CouponModule` قرار دارد).
