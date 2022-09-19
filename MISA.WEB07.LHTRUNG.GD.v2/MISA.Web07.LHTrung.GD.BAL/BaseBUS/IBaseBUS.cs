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

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Thêm mới thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public Guid? InsertOneRecord(T record);

        /// <summary>
        /// sửa 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi sẽ thay thế bản ghi cũ</param>
        /// <param name="recordID">ID Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by:  LHTRUNG
        public int? UpdateOneRecord(T record);

        /// <summary>
        /// xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (xóa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by:  LHTRUNG
        public int DeleteOneRecord(Guid recordID);

        /// <summary>
        /// lấy mã số mới
        /// </summary>
        /// <returns>Mã số mới</returns>
        /// Created by: LHTrung

        public string GetNewCode();

        /// <summary>
        /// Kiểm tra mã mới
        /// </summary>
        /// <returns>mã mới có trùng không</returns>
        /// Created by: LHTrung
        public bool CheckDuplicateCode(string Code);


        ///// <summary>
        ///// Kiểm tra dữ liệu đầu vào
        ///// </summary>
        ///// <returns>dữ liệu Input có đúng định dạng không</returns>
        ///// Created by: LHTrung
        //public ErrorResult Validate(T record);
    }
}
