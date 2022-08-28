namespace MISA.WEB07.LHTRUNG.GD.DAL
{
    public interface IBaseDAL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng (officer, subject,...)</returns>
        /// Created by:  LHTRUNG
        public IEnumerable<dynamic> GetAllRecords();
    }
}
