using Microsoft.AspNetCore.Mvc.ModelBinding;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;
using MySqlConnector;
using System.Diagnostics;
namespace MISA.WEB07.LHTRUNG.GD.UI.Helpers
{
    public static class HandleError
    {
        /// <summary>
        /// Validate 1 entity trả về đối tượng chứa thông tin lỗi
        /// </summary>
        /// <param name="modelState">Đối tượng modelstate hứng được khi gọi API</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        public static ErrorResult? ValidateEntity(ModelStateDictionary modelState, HttpContext httpContext)
        {
            if (!modelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in modelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                var errorResult = new ErrorResult(
                    DTO.Enums.ErrorCode.Validate,
                    "Dữ liệu này không được phép bỏ trống",
                    errors,
                    "https://openapi.misa.com.vn/errorcode",
                    Activity.Current?.Id ?? httpContext?.TraceIdentifier);

                return errorResult;
            }

            return null;
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp exception
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        public static ErrorResult? GenerateExceptionResult(Exception exception, HttpContext httpContext)
        {
            Console.WriteLine(exception.Message);
            return new ErrorResult(
                DTO.Enums.ErrorCode.Exception,
                "Có lỗi xảy ra. Vui lòng liên hệ MISA!",
                exception.Message,
                "https://openapi.misa.com.vn/errorcode/e002",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }

        /// <summary>
        /// Sinh ra đối tượng lỗi trả về khi gặp lỗi trùng mã
        /// </summary>
        /// <param name="exception">Đối tượng exception gặp phải</param>
        /// <param name="httpContext">Context khi gọi API sử dụng để lấy được traceId</param>
        /// <returns>Đối tượng chứa thông tin lỗi trả về cho client</returns>
        public static ErrorResult? GenerateDuplicateCodeErrorResult(MySqlException mySqlException, HttpContext httpContext)
        {
            if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
            {
                var errorResult = new ErrorResult(
                    DTO.Enums.ErrorCode.DuplicateCode,
                    "Trùng mã",
                    $"{mySqlException.Message}",
                    "https://openapi.misa.com.vn/errorcode/e003",
                    Activity.Current?.Id ?? httpContext?.TraceIdentifier);
                return errorResult;
            }

            Console.WriteLine(mySqlException.Message);
            return new ErrorResult(
                DTO.Enums.ErrorCode.Exception,
                "Có lỗi xảy ra. Vui lòng liên hệ MISA!",
                "Catched an exception",
                "https://openapi.misa.com.vn/errorcode/e002",
                Activity.Current?.Id ?? httpContext?.TraceIdentifier);
        }
    }
}
