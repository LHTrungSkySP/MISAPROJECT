namespace MISA.WEB07.LHTRUNG.GD.DAL.Manager.BaseManager
{
    public interface IBaseManagerDAL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi liên quan đến Officer trong bảng T
        /// </summary>
        /// <param name="officerID">ID nhân viên cần lấy các bản ghi liên quan</param>
        /// <returns>tất cả bản ghi liên quan đến OfficerID</returns>
        /// Created by:  LHTRUNG
        public IEnumerable<dynamic> GetAllRecords(Guid officerID);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: LHTrung
        public Guid InsertOneRecord(T officerID);

        /// <summary>
        /// xóa các bản ghi liên quan đến OfficerID
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (xóa thành công thì sẽ trả về n bản ghi liên quan đến OfficerID đã bị xóa)</returns>
        /// Created by:  LHTRUNG
        public int Reset(Guid officerID);
    }
}
