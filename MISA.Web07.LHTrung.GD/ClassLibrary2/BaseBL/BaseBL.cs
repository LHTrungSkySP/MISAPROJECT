using MISA.Web07.LHTrung.GD.DL;

namespace MISA.Web07.LHTrung.GD.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;
        private IGroupDL groupDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        public BaseBL(IGroupDL groupDL)
        {
            this.groupDL = groupDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by:  TMSANG (23/08/2022)
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        #endregion
    }
}
