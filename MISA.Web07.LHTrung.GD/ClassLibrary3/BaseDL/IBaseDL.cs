namespace MISA.Web07.LHTrung.GD.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by:  LHTrung
        public IEnumerable<dynamic> GetAllRecords();

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Thêm mới thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public Guid InsertOneRecord(T record);


        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Xóa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public void DeleteOneRecord(Guid recordID);

        /// <summary>
        /// Update một bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi muốn Update</param>
        /// <param name="record">Đối tượng bản ghi mới thay thế Đối tượng cũ</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Xóa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public void UpdateOneRecord(Guid recordID, T record);

        /// <summary>
        /// Update một bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi muốn Update</param>
        /// <param name="record">Đối tượng bản ghi mới thay thế Đối tượng cũ</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Xóa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public T GetOneRecord(Guid recordID);
    }
}
