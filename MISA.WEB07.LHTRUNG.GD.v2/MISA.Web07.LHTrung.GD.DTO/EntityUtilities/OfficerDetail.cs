namespace MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities
{
    public class OfficerDetail
    {
        /// <summary>
        /// thông tin cá nhân nhân viên
        /// </summary>
        public Officer? officer { get; set; }

        /// <summary>
        /// Thông tin chi tiết về những môn học mà nhân viên dạy
        /// </summary>

        public List<Subject>? subjects { get; set; }

        /// <summary>
        /// Thông tin chi tiết về những phòng kho mà nhân viên quản lý
        /// </summary>
        /// 
        public List<StorageRoom>? storageRooms { get; set; }
    }
}
