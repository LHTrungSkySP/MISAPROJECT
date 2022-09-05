namespace MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities
{
    public class PagingData
    {
        /// <summary>
        /// Mảng đối tượng thỏa mãn điều kiện lọc và phân trang 
        /// </summary>
        public List<Guid> Data { get; set; } = new List<Guid>();

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public long TotalCount { get; set; }
    }
}
