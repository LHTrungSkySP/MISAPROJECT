using Dapper;
using MISA.Web07.LHTrung.GD.Common.Entities;
using MySqlConnector;

namespace MISA.Web07.LHTrung.GD.DL
{
    public class OfficerDL : BaseDL<Officer>, IOfficerDL
    {

        public int DeleteOfficerByID(Guid officerID)
        {
            // Khởi tạo kết nối tới DB MySQL
            var mySqlConnection = new MySqlConnection(CONNECTION_STRING);

            // Chuẩn bị câu lệnh DELETE
            string deleteOfficerCommand = "DELETE FROM officer WHERE OfficerID = @OfficerID";

            // Chuẩn bị tham số đầu vào cho câu lệnh DELETE
            var parameters = new DynamicParameters();
            parameters.Add("@OfficerID", officerID);

            // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
            int numberOfAffectedRows = mySqlConnection.Execute(deleteOfficerCommand, parameters);

            return numberOfAffectedRows;
        }

        public IEnumerable<dynamic> GetAllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
