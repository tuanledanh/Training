using Domain.Exceptions;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructor
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Xử lý request và gọi chuỗi middleware tiếp theo trong pipeline
        /// Nếu trong quá trình thực thi xảy ra ngoại lệ, sẽ chuyển hướng đến phương thức HandleExceptionAsync để xử lý
        /// </summary>
        /// <param name="context">HttpContext của request hiện tại</param>
        /// <returns>Task</returns>
        /// Created by: ldtuan (17/07/2023)
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Xử lý ngoại lệ và trả về thông tin lỗi dưới dạng JSON
        /// </summary>
        /// <param name="context">HttpContext của request hiện tại</param>
        /// <param name="exception">Ngoại lệ được xử lý</param>
        /// <returns>Task</returns>
        /// Created by: ldtuan (17/07/2023)
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                // Xử lý ngoại lệ NotFoundException
                case NotFoundException notFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(new BaseException()
                    {
                        ErrorCode = notFoundException.ErrorCode,
                        UserMessage = "Không tìm thấy tài nguyên",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? "");
                    break;

                // Xử lý ngoại lệ ConflictException
                case ConflictException:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;

                    await context.Response.WriteAsync(
                            new BaseException()
                            {
                                ErrorCode = StatusCodes.Status409Conflict,
                                UserMessage = "Mã tài sản bị trùng",
                                DevMessage = exception.Message,
                                TraceId = context.TraceIdentifier,
                                MoreInfo = exception.HelpLink
                            }.ToString() ?? "");
                    break;

                // Xử lý các ngoại lệ khác
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(new BaseException()
                    {
                        ErrorCode = StatusCodes.Status500InternalServerError,
                        UserMessage = "Lỗi hệ thống",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? "");
                    break;
            }
        }
        #endregion

    }
}
