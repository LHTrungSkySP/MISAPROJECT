using MISA.WEB07.LHTRUNG.GD.DAL.GroupDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.BUS.GroupBUS
{
    public class GroupBUS : BaseBUS<Group>, IGroupBUS
    {
        #region Feild
        private IGroupDAL _groupDAL;

        #endregion

        #region Contructor
        public GroupBUS(IGroupDAL groupDAL) : base(groupDAL)
        {
            _groupDAL = groupDAL;
        }
        #endregion

        #region Method
        #endregion
    }
}
