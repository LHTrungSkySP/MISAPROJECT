using MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;

namespace MISA.WEB07.LHTRUNG.GD.DAL.OfficerDAL
{
    public interface IOfficerDAL : IBaseDAL<Officer>
    {
        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="positionID">ID vị trí</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
        public PagingData? FilterOfficer(
            string? keyword,
            Guid? subjectID,
            Guid? groupID,
            Guid? storageRoomID,
            string sortBy = "ModifiedDate DESC",
            int pageSize = 10,
            int pageNumber = 1);

        ///<summary>
        /// lấy thông tin chi tiết cảu toàn bộ officer 
        ///</summary>
        ///
        public OfficerDetailPaging? GetOfficersDetail(
            string? keyword,
            Guid? subjectID,
            Guid? groupID,
            Guid? storageRoomID,
            string sortBy = "ModifiedDate DESC",
            int pageSize = 10,
            int pageNumber = 1);

        /// <summary>
        /// API Lấy thông tin chi tiết vê OfficerID
        /// </summary>
        /// <returns>Một đối tượng gồm:
        /// + Thông tin cá nhân của nhân viên 
        /// + Danh sách các môn học do nhân viên đso dạy
        /// + Danh sách kho phòng nhân viên đó quản lý</returns>
        /// Created by: LHTrung
        /// 
        public OfficerDetail? GetOfficerDetail(Guid officerID);

        /// <summary>
        /// API thêm mới thông tin chi tiết vê OfficerID
        /// </summary>
        /// <param name="officerDetail" chứa thông tin cần thêm mới 
        /// <returns>id của thằng đc chèn</returns>
        /// Created by: LHTrung
        /// 
        public Guid? InsertDetailOfficer(OfficerDetail officerDetail);


        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public Guid? UpdateOfficerDetail(OfficerDetail officerDetail);
    }
}
