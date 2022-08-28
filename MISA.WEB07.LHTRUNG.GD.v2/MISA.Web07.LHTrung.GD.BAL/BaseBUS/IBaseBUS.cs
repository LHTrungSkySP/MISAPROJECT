namespace MISA.WEB07.LHTRUNG.GD.BUS
{
    public interface IBaseBUS<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by:  LHTrung

        public IEnumerable<dynamic> GetAllRecords();
    }
}
