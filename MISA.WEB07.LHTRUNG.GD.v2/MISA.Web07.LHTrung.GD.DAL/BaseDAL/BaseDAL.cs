using Dapper;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.DAL
{
    public class BaseDAL<T> : IBaseDAL<T>
    {
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                // Chuẩn bị câu lệnh SELECT 
                string className = typeof(T).Name; //lấy kiểu dữ liệu của T ( tên bảng )

                //// chuẩn bị tên của Stored procedure cần dùng
                //string storedProcedureName = $"Proc_className}_GetPaging";

                string getAllRecordsCommand = $"SELECT * FROM {className}";

                // Thực hiện gọi vào DB để chạy câu lệnh SELECT 
                var records = mySqlConnection.Query(getAllRecordsCommand);

                return records;
            }
        }
    }
}
