using Dapper;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.DAL.Manager.BaseManager
{
    public class BaseManagerDAL<T> : IBaseManagerDAL<T>
    {
        public IEnumerable<dynamic> GetAllRecords(Guid officerID)
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_GetByOfficer";

            // tham số đầu vào cho Stored procedure
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
    }
}
