using MISA.WEB07.LHTRUNG.GD.DAL.Manager.BaseManager;

namespace MISA.WEB07.LHTRUNG.GD.BUS.Manager.BaseManager
{
    public class BaseManagerBUS<T> : IBaseManagerBUS<T>
    {
        #region Feild
        private IBaseManagerDAL<T> _baseManagerDAL;
        #endregion

        #region Contructor
        public BaseManagerBUS(IBaseManagerDAL<T> baseManagerDAL)
        {
            _baseManagerDAL = baseManagerDAL;
        }

        #endregion

        #region Method
        /// <summary>
        /// Lấy tất cả bản ghi liên quan đến officerID trong barng T
        /// </summary>
        /// <returns>tất cả bản ghi liên quan đến officerID trong barng T</returns>
        /// Created by:  LHTrung
        public IEnumerable<dynamic> GetAllRecords(Guid id)
        {
            return _baseManagerDAL.GetAllRecords(id);
        }
        #endregion
    }

}
