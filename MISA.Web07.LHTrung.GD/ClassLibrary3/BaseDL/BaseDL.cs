using Dapper;
using MySqlConnector;

namespace MISA.Web07.LHTrung.GD.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Field

        protected const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";

        #endregion

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by: TMSANG (23/08/2022)
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
            {
                // Chuẩn bị câu lệnh SELECT 
                string className = typeof(T).Name;
                string getAllRecordsCommand = $"SELECT * FROM {className}";

                // Thực hiện gọi vào DB để chạy câu lệnh SELECT 
                var records = mySqlConnection.Query(getAllRecordsCommand);

                return records;
            }
        }
    }
}
