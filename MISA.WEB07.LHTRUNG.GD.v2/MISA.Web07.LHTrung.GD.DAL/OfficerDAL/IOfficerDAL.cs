using MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;

namespace MISA.WEB07.LHTRUNG.GD.DAL.OfficerDAL
{
    public interface IOfficerDAL : IBaseDAL<Officer>
    {
        /// <summary>
        /// API Lấy danh sách ID nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm (mã NV, Tên NV, SĐT)</param> 
        /// <param name="subjectID">ID môn học</param>
        /// <param name="groupID">ID tổ bộ môn</param>
        /// <param name="storageRoomID">ID phòng kho</param>
        /// <param name="pageSize">Số bản ghi trong một trang</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách ID nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
        public PagingData FilterOfficer(
            string? keyword,
            Guid? subjectID,
            Guid? groupID,
            Guid? storageRoomID,
            string sortBy = "ModifiedDate DESC",
            int pageSize = 10,
            int pageNumber = 1);

        /// <summary>
        /// API Lấy danh sách thông tin chi tiết nhân viên theo kết quả lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm (mã NV, Tên NV, SĐT)</param> 
        /// <param name="subjectID">ID môn học</param>
        /// <param name="groupID">ID tổ bộ môn</param>
        /// <param name="storageRoomID">ID phòng kho</param>
        /// <param name="pageSize">Số bản ghi trong một trang</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách thông tin chi tiết nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
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
        /// <param name="officerID">ID nhân viên</param>
        /// <returns>Một đối tượng gồm:
        /// + Thông tin cá nhân của nhân viên 
        /// + Danh sách các môn học do nhân viên đso dạy
        /// + Danh sách kho phòng nhân viên đó quản lý</returns>
        /// Created by: LHTrung
        /// 
        public OfficerDetail GetOfficerDetail(Guid officerID);

        /// <summary>
        /// API thêm mới thông tin chi tiết vê OfficerID
        /// </summary>
        /// <param name="officerDetail" chứa thông tin cần thêm mới 
        /// <returns>id của thằng đc chèn</returns>
        /// Created by: LHTrung
        /// 
        public Guid? InsertDetailOfficer(OfficerDetail officerDetail);


        /// <summary>
        /// Sửa chi tiết một bản ghi của Officer
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public int UpdateOfficerDetail(OfficerDetail officerDetail);
    }
}
