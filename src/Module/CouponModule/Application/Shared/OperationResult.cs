namespace CouponModule.Application.Shared
{
    public class OperationResult<TData>
    {
        public const string SuccessMessage = "عملیات با موفقیت انجام شد";
        public const string ErrorMessage = "عملیات با شکست مواجه شد";
        public const string NotFoundMessage = "داده ای یافت نشد";
        public const string BadRequestMessage = "داده ورودی نامعتبر است";

        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
        public TData Data { get; set; }

        public static OperationResult<TData> Success(TData data)
        {
            return new OperationResult<TData>
            {
                Data = data,
                IsSuccess = true,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Success,
                    Description = SuccessMessage,
                    Title = "موفق",
                }
            };
        }

        public static OperationResult<TData> NotFound()
        {
            return new OperationResult<TData>
            {
                Data = default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.NotFound,
                    Description = NotFoundMessage,
                    Title = "ناموفق",
                }
            };
        }

        public static OperationResult<TData> Error()
        {
            return new OperationResult<TData>
            {
                Data = default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = ErrorMessage,
                    Title = "ناموفق",
                }
            };
        }

        public static OperationResult<TData> Error(TData data, string? message)
        {
            return new OperationResult<TData>
            {
                Data = data != null ? data : default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = message != null ? message : ErrorMessage,
                    Title = "ناموفق",
                }
            };
        }

        public static OperationResult<TData> NotFound(TData data, string? message)
        {
            return new OperationResult<TData>
            {
                Data = data != null ? data : default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = message != null ? message : ErrorMessage,
                    Title = "ناموفق",
                }
            };
        }

        public static OperationResult<TData> BadRequest(TData data, string? message)
        {
            return new OperationResult<TData>
            {
                Data = data != null ? data : default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = message != null ? message : ErrorMessage,
                    Title = "ناموفق",
                }
            };
        }


        public static OperationResult<TData> Success(TData data, string message)
        {
            return new OperationResult<TData>
            {
                Data = data,
                IsSuccess = true,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Success,
                    Description = message,
                    Title = "موفق",
                }
            };
        }

        public static OperationResult<TData> NotFound(string message)
        {
            return new OperationResult<TData>
            {
                Data = default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.NotFound,
                    Description = message,
                    Title = "ناموفق",
                }
            };
        }
    
        public static OperationResult<TData> BadRequest(string message)
        {
            return new OperationResult<TData>
            {
                Data = default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.BadRequest,
                    Description = message,
                    Title = "badRequest",
                }
            };
        }

        public static OperationResult<TData> Error(string message)
        {
            return new OperationResult<TData>
            {
                Data = default(TData),
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = message,
                    Title = "ناموفق",
                }
            };
        }
    }

    public class OperationResult
    {
        public const string SuccessMessage = "عملیات با موفقیت انجام شد";
        public const string ErrorMessage = "عملیات با شکست مواجه شد";
        public const string NotFoundMessage = "داده ای یافت نشد";
        public const string BadRequestMessage = "داده ورودی نامعتبر است";

        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }

        public static OperationResult Success()
        {
            return new OperationResult
            {
                IsSuccess = true,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Success,
                    Description = SuccessMessage,
                    Title = "موفق",
                }
            };
        }
       
        public static OperationResult SuccessCreated()
        {
            return new OperationResult
            {
                IsSuccess = true,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.created,
                    Description = SuccessMessage,
                    Title = "موفق",
                }
            };
        }

        public static OperationResult NotFound()
        {
            return new OperationResult
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.NotFound,
                    Description = NotFoundMessage,
                    Title = "ناموفق",
                }
            };
        }

        public static OperationResult BadRequest()
        {
            return new OperationResult
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.BadRequest,
                    Description = NotFoundMessage,
                    Title = "درخواست نامعتبر",
                }
            };
        }

        public static OperationResult Error()
        {
            return new OperationResult
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = ErrorMessage,
                    Title = "ناموفق",
                }
            };
        }


        public static OperationResult Success(string message)
        {
            return new OperationResult
            {
                IsSuccess = true,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Success,
                    Description = message,
                    Title = "موفق",
                }
            };
        }

        public static OperationResult NotFound(string message)
        {
            return new OperationResult
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.NotFound,
                    Description = message,
                    Title = "ناموفق",
                }
            };
        }
      
        public static OperationResult BadRequest(string message)
        {
            return new OperationResult
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.BadRequest,
                    Description = message,
                    Title = "ناموفق",
                }
            };
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult
            {
                IsSuccess = false,
                MetaData = new MetaData
                {
                    AppStatusCode = OperationResultStatus.Error,
                    Description = message,
                    Title = "ناموفق",
                }
            };
        }
    }

    public class MetaData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public OperationResultStatus AppStatusCode { get; set; }
    }

    public enum OperationResultStatus
    {
        BadRequest = 400,
        Error = 10,
        Success = 200,
        created = 201,
        NotFound = 404,
        UnAuthorize = 401,
        ServerError = 500
    }
}