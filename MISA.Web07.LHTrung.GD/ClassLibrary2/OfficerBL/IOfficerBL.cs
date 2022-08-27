using MISA.Web07.LHTrung.GD.BL.BaseBL;
using MISA.Web07.LHTrung.GD.Common.Entities;
using MISA.Web07.LHTrung.GD.Common.Enums.DTO;

namespace MISA.Web07.LHTrung.GD.BL.OfficerBL
{
    public interface IOfficerBL : IBaseBL<Officer>
    {
        /// <summary>
        /// Thêm mới 1 nhân viên
        /// </summary>
        /// <param name="officer">Đối tượng nhân viên muốn thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public int InsertOfficer(Officer officer);

        /// <summary>
        /// Sửa 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn sửa</param>
        /// <param name="officer">Đối tượng nhân viên muốn sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public int UpdateOfficer(Guid officerID, Officer officer);

        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public int DeleteOfficerByID(Guid officerID);


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
        /// Created by: TMSANG (09/06/2022)
        public PagingData<Officer> FilterOfficers(
             string? keyword,
             Guid? subjectID,
             Guid? groupID,
             Guid? storageRoomID,
             int pageSize = 10,
             int pageNumber = 1);


        /// <summary>
        /// Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: TMSANG (09/06/2022)
        public Officer GetOfficerByID(Guid officerID);

        /// <summary>
        /// Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: TMSANG (09/06/2022)
        public string GetNewOfficerCode();
    }
}
