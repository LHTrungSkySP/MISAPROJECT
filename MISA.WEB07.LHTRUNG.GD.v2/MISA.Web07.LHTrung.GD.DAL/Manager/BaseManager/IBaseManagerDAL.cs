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

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Thêm mới thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public Guid InsertOneRecord(T officerID);

        /// <summary>
        /// xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (xóa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by:  LHTRUNG
        public int Reset(Guid officerID);
    }
}
