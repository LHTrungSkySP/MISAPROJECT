using MISA.Web07.LHTrung.GD.Common.Entities;

namespace MISA.Web07.LHTrung.GD.DL
{
    public interface IOfficerDL : IBaseDL<Officer>
    {
        /// <summary>
        /// Xóa 1 nhân viên
        /// </summary>
        /// <param name="OficerID">ID của nhân viên muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: LHTrung
        public int DeleteOfficerByID(Guid officerID);
        public int UpdateOfficerByID(Guid officerID, Officer officer);

    }
}
