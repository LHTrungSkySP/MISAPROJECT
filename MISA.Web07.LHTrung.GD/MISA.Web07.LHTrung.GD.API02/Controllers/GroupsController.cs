using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Web07.LHTrung.GD.Common.Entities;
using MISA.Web07.LHTrung.GD.DL;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.Web07.LHTrung.GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách tổ
        /// </summary>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Group>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllGroups()
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString);

                // Chuẩn bị câu lệnh truy vấn
                string getAllGroupsCommand = "SELECT * FROM `group`;";

                // Thực hiện gọi vào DB để chạy câu lệnh truy vấn ở trên
                var group = mySqlConnection.Query<Group>(getAllGroupsCommand);

                // Xử lý dữ liệu trả về
                if (group != null)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, group);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
