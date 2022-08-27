using MISA.Web07.LHTrung.GD.BL.BaseBL;
using MISA.Web07.LHTrung.GD.DL;
using System.Text.RegularExpressions;

namespace MISA.Web07.LHTrung.GD.BL.GroupBL
{
    public class GroupBL : BaseBL<Group>, IGroupBL
    {
        #region Field

        private IGroupDL _groupDL;

        #endregion

        #region Constructor

        public GroupBL(IGroupDL groupDL) : base(groupDL)
        {
            _groupDL = groupDL;
        }

        #endregion
    }
}
