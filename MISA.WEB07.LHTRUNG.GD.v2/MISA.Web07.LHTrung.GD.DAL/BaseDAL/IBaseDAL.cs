namespace MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL
{
    public interface IBaseDAL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng (officer, subject,...)</returns>
        /// Created by:  LHTRUNG
        public IEnumerable<dynamic> GetAllRecords();

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi được them mới (Thêm mới thành công thì sẽ trả về id nhân viên được thêm mới)</returns>
        /// Created by: LHTrung
        public Guid? InsertOneRecord(T record);

        /// <summary>
        /// sửa 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi đã cập nhật lại thông tin</param>
        /// <returns>Số bản ghi bị ảnh hưởng (sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by:  LHTRUNG
        public int UpdateOneRecord(T record);

        /// <summary>
        /// xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>ID bản ghi bị xóa thành công</returns>
        /// Created by:  LHTRUNG
        public int DeleteOneRecord(Guid recordID);

        /// <summary>
        /// lấy mã số mới
        /// </summary>
        /// <returns>Mã số mới (VD: NV003)</returns>
        /// Created by: LHTrung
        public string GetNewCode();

        /// <summary>
        /// Kiểm tra mã mới
        /// </summary>
        /// <returns>Mã số mới</returns>
        /// Created by: LHTrung
        public bool CheckDuplicateCode(string Code);

    }
}
