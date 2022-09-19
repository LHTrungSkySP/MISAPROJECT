namespace MISA.WEB07.LHTRUNG.GD.DTO.Enums
{
    /// <summary>
    /// Mã lỗi nội bộ
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Lỗi do exception chưa xác định được
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Lỗi do validate dữ liệu thất bại
        /// </summary>
        Validate = 2,

        /// <summary>
        /// Lỗi do trùng mã
        /// </summary>
        DuplicateCode = 3,

        /// <summary>
        /// Lỗi số điện thoại sai định dạng
        /// </summary>            
        PhoneNumberFail = 4,

        /// <summary>
        /// Lỗi email sai định dạng
        /// </summary>     
        EmailFail = 5,

        /// <summary>
        /// Lỗi ngày nghỉ việc sai 
        /// </summary>  
        QuitDateFail = 6,

        /// <summary>
        /// Lỗi mã nhân viên sai định dạng
        /// </summary>  
        OfficerCodeFail = 7
    }
}
