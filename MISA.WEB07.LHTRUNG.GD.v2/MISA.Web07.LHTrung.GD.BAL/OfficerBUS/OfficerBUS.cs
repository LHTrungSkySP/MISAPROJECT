using MISA.WEB07.LHTRUNG.GD.DAL;
using MISA.WEB07.LHTRUNG.GD.DTO;

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

        #endregion
    }
}
