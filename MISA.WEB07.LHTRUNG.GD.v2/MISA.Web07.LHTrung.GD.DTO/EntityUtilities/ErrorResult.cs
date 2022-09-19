using MISA.WEB07.LHTRUNG.GD.DTO.Enums;

namespace MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities
{
    /// <summary>
    /// Thông tin lỗi trả về cho client
    /// </summary>
    public class ErrorResult
    {
        #region Property

        /// <summary>
        /// Định danh của mã lỗi nội bộ
        /// </summary>
        public ErrorCode ErrorCode { get; set; } = ErrorCode.Exception;

        /// <summary>
        /// Thông báo cho user. Không bắt buộc, tùy theo đặc thù từng dịch vụ và client tích hợp
        /// </summary>
        public string? UserMsg { get; set; }

        /// <summary>
        /// Thông báo cho Dev. Thông báo ngắn gọn để thông báo cho Dev biết vấn đề đang gặp phải
        /// </summary>
        public object? DevMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết hơn về vấn đề. Ví dụ: Đường dẫn mô tả về mã lỗi
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Mã để tra cứu thông tin log: ELK, file log,...
        /// </summary>
        public string? TraceId { get; set; }

        #endregion

        #region Constructor

        public ErrorResult()
        {

        }

        public ErrorResult(ErrorCode errorCode, string? userMsg, object? devMsg, string? moreInfo, string? traceId)
        {
            ErrorCode = errorCode;  //Định danh của mã lỗi nội bộ
            UserMsg = userMsg;      //Thông báo cho user. Không bắt buộc, tùy theo đặc thù từng dịch vụ và client tích hợp
            DevMsg = devMsg;        //Thông báo cho Dev. Thông báo ngắn gọn để thông báo cho Dev biết vấn đề đang gặp phải
            MoreInfo = moreInfo;    //Thông tin chi tiết hơn về vấn đề. Ví dụ: Đường dẫn mô tả về mã lỗi
            TraceId = traceId;      //Mã để tra cứu thông tin log: ELK, file log,...
        }

        #endregion
    }
}
