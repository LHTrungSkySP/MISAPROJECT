using MISA.WEB07.LHTRUNG.GD.DAL;

namespace MISA.WEB07.LHTRUNG.GD.BUS
{
    public class BaseBUS<T> : IBaseBUS<T>
    {
        #region Feild

        private IBaseDAL<T> _baseDAL;
        //private IOfficerDAL _officerDAL;

        #endregion

        #region Contructor

        public BaseBUS(IBaseDAL<T> baseDAL)
        {
            _baseDAL = baseDAL;
        }


        #endregion

        #region Method

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by:  LHTrung

        public IEnumerable<dynamic> GetAllRecords()
        {
            return _baseDAL.GetAllRecords();
        }
        #endregion

    }
}
