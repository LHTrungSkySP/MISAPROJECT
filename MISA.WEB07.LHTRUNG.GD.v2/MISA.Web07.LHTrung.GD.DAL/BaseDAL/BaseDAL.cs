using Dapper;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL
{
    public class BaseDAL<T> : IBaseDAL<T>
    {
        /// <summary>
        /// lấy toàn bộ bản ghi của 1 bảng
        /// </summary>
        /// <returns>Tất cả bản ghi của 1 bảng</returns>
        /// Created by: LHTrung
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            //// chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_GetAll";

            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var records = mySqlConnection.Query(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                return records;
            }
        }


        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Thêm mới thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public virtual Guid? InsertOneRecord(T record)
        {
            //return Guid.NewGuid();
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
                try
                {
                    var id = mySqlConnection.Query<Guid>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return id.FirstOrDefault();

                }
                catch
                {
                    return null;
                }
            }

        }

        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public virtual int UpdateOneRecord(T record)
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_UpdateOne";

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
                int rowAffected = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (rowAffected > 0)
                {
                    return rowAffected;
                }
                else
                {
                    return rowAffected;
                }
            }
        }


        /// <summary>
        /// xóa một bản ghi
        /// </summary>
        /// <param name="recordID">ID Đối tượng bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Thêm mới thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung

        public virtual Guid DeleteOneRecord(Guid recordID)
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_DeleteOne";

            // tham số đầu vào cho Stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@v_{className}ID", recordID);


            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var id = mySqlConnection.Query<Guid>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (id != null)
                {
                    var result = id.FirstOrDefault();
                    return result;
                }
                else
                {
                    return Guid.Empty;
                }

            }

        }

        /// <summary>
        /// lấy mã số mới
        /// </summary>
        /// <returns>Mã số mới</returns>
        /// Created by: LHTrung

        public virtual string GetNewCode()
        {
            //lấy kiểu dữ liệu của T ( tên bảng )
            string className = typeof(T).Name;

            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_{className.ToLower()}_GetMaxCode";

            // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                var code = mySqlConnection.Query<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                if (code != null)
                {
                    return code.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
