using MISA.Web07.LHTrung.GD.BL.BaseBL;
using MISA.Web07.LHTrung.GD.Common.Entities;
using MISA.Web07.LHTrung.GD.Common.Enums.DTO;
using MISA.Web07.LHTrung.GD.DL;

namespace MISA.Web07.LHTrung.GD.BL.OfficerBL
{
    public class OfficerBL : BaseBL<Officer>, IOfficerBL
    {
        #region Field

        private IOfficerDL _officerDL;

        #endregion

        #region Constructor

        public OfficerBL(IOfficerDL officerDL) : base(officerDL)
        {
            _officerDL = officerDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)
        public int DeleteOfficerByID(Guid officerID)
        {
            return _officerDL.DeleteOfficerByID(officerID);
        }

        /// <summary>
        /// Sửa 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn sửa</param>
        /// <param name="officer">Đối tượng nhân viên muốn sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: TMSANG (09/06/2022)

        public Officer GetOfficerByID(Guid officerID)
        {
            throw new NotImplementedException();
        }

        public string GetNewOfficerCode()
        {
            throw new NotImplementedException();
        }

        public int InsertOfficer(Officer officer)
        {
            throw new NotImplementedException();
        }

        public int UpdateOfficer(Guid officerID, Officer officer)
        {
            throw new NotImplementedException();
        }

        public PagingData<Officer> FilterOfficers(string? keyword, Guid? subjectID, Guid? groupID, Guid? storageRoomID, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
