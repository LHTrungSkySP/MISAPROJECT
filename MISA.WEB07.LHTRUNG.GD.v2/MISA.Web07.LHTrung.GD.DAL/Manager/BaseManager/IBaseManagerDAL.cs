namespace MISA.WEB07.LHTRUNG.GD.DAL.Manager.BaseManager
{
    public interface IBaseManagerDAL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi liên quan đến Officer
        /// </summary>
        /// <returns>tất cả bản ghi liên quan đến OfficerID</returns>
        /// Created by:  LHTRUNG
        public IEnumerable<dynamic> GetAllRecords(Guid officerID);
    }
}
