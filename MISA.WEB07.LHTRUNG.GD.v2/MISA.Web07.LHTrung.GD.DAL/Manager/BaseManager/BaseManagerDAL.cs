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
            var parameters = new DynamicParameters();
            parameters.Add($"@v_OfficerID", officerID);

            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var result = mySqlConnection.Query(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
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
