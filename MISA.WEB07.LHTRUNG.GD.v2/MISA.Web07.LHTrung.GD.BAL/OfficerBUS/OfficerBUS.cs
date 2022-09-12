using MISA.WEB07.LHTRUNG.GD.DAL.OfficerDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;

namespace MISA.WEB07.LHTRUNG.GD.BUS
{
    public class OfficerBUS : BaseBUS<Officer>, IOfficerBUS
    {
        #region Field
        private IOfficerDAL _officerDAL;
        #endregion

        #region Contructor
        public OfficerBUS(IOfficerDAL officerDAL) : base(officerDAL)
        {
            _officerDAL = officerDAL;
        }
        #endregion

        #region Method
        public PagingData? FilterOfficer(string? keyword, Guid? subjectID, Guid? groupID, Guid? storageRoomID, string sortBy = "ModifiedDate DESC", int pageSize = 10, int pageNumber = 1)
        {
            return _officerDAL.FilterOfficer(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
        }

        public OfficerDetail? GetOfficerDetail(Guid officerID)
        {
            var tam = officerID;
            System.Console.WriteLine(tam);
            return _officerDAL.GetOfficerDetail(officerID);
        }

        public OfficerDetailPaging? GetOfficersDetail(string? keyword, Guid? subjectID, Guid? groupID, Guid? storageRoomID, string sortBy = "ModifiedDate DESC", int pageSize = 10, int pageNumber = 1)
        {
            return _officerDAL.GetOfficersDetail(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
        }



        /// <summary>
        /// API thêm mới thông tin chi tiết vê OfficerID
        /// </summary>
        /// <param name="officerDetail" chứa thông tin cần thêm mới 
        /// <returns>id nhân viên đc chèn</returns>
        /// Created by: LHTrung
        /// 
        public Guid? InsertDetailOfficer(OfficerDetail officerDetail)
        {
            return _officerDAL.InsertDetailOfficer(officerDetail);
        }

        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public Guid? UpdateOfficerDetail(OfficerDetail officerDetail)
        {
            return _officerDAL.UpdateOfficerDetail(officerDetail);
        }
        #endregion
    }
}
