namespace MISA.Web07.LHTrung.GD.BL.BaseBL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by:  TMSANG (23/08/2022)
        public IEnumerable<dynamic> GetAllRecords();
    }
}
