using Dapper;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.DAL.Manager.BaseManager
{
    public class BaseManagerDAL<T> : IBaseManagerDAL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi liên quan đến Officer
        /// </summary>
        /// <param name="officerID">ID nhân viên cần lấy các bản ghi liên quan</param>
        /// <returns>tất cả bản ghi liên quan đến OfficerID</returns>
        /// Created by:  LHTRUNG
        public IEnumerable<dynamic> GetAllRecords(Guid officerID)
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_GetByOfficer";

            // tham số đầu vào cho Stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@v_OfficerID", officerID);

            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var result = mySqlConnection.Query(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// xóa các bản ghi liên quan đến OfficerID
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (xóa thành công thì sẽ trả về n bản ghi liên quan đến OfficerID đã bị xóa)</returns>
        /// Created by:  LHTRUNG
        public int Reset(Guid officerID)
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_ResetByOfficerID";

            // tham số đầu vào cho Stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@v_OfficerID", officerID);

            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: LHTrung
        public Guid InsertOneRecord(T record)
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_InsertOne";

            // tham số đầu vào cho Stored procedure
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                string propertyName = $"@v_{property.Name}";
                var propertyValue = property.GetValue(record);
                parameters.Add(propertyName, propertyValue);
            }

            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var id = mySqlConnection.Query<Guid>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return id.FirstOrDefault();
            }
        }
    }
}
