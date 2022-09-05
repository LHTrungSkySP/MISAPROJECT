using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.StorageRoomMNGBUS;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.SubjectMNGBUS;
using MISA.WEB07.LHTRUNG.GD.DAL;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficersController : BasesController<Officer>
    {
        #region Feild
        private IOfficerBUS _officerBUS;

        private ISubjectManagerBUS _subjectManagerBUS;

        private IStorageRoomMNGBUS _storageRoomMNGBUS;

        #endregion

        #region Contructor
        public OfficersController(IOfficerBUS officerBUS) : base(officerBUS)
        {
            _officerBUS = officerBUS;
        }
        #endregion

        #region Method
        /// <summary>
        /// phân trang
        /// </summary>
        [HttpGet("GetPaging")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterOfficer(
            [FromQuery] string? keyword,
            [FromQuery] Guid? subjectID,
            [FromQuery] Guid? groupID,
            [FromQuery] Guid? storageRoomID,
            [FromQuery] string sortBy = "ModifiedDate DESC",
            [FromQuery] int pageSize = 50,
            [FromQuery] int pageNumber = 1)
        {
            var results = _officerBUS.FilterOfficer(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
            if (results != null)
            {
                var officers = results.Data;
                var totalCount = results.TotalCount;
                return StatusCode(StatusCodes.Status200OK, new PagingData()
                {
                    Data = officers,
                    TotalCount = totalCount
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        [HttpGet("GetDetail")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOfficerDetail([FromRoute] Guid officerID)
        {
            var result = _officerBUS.GetOfficerDetail(officerID);
            if (result != null)
            {
                return StatusCode(StatusCodes.Status200OK, new OfficerDetail()
                {
                    officer = result.officer,
                    subjects = result.subjects,
                    storageRooms = result.storageRooms
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("GetDetails")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOfficersDetail(
            [FromQuery] string? keyword,
            [FromQuery] Guid? subjectID,
            [FromQuery] Guid? groupID,
            [FromQuery] Guid? storageRoomID,
            [FromQuery] string sortBy = "ModifiedDate DESC",
            [FromQuery] int pageSize = 50,
            [FromQuery] int pageNumber = 1)
        {
            var result = _officerBUS.GetOfficersDetail(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
            if (result != null)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost("officerDetail")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult PostOfficersDetail([FromBody] OfficerDetail officerDetail)
        {
            var result = _officerBUS.InsertDetailOfficer(officerDetail);
            if (result != null)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }


        [HttpGet("{officerID}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult Getabc([FromRoute] Guid officerID)
        {
            // chuẩn bị câu lệnh Procedure 

            ///<summary>
            /// lấy id của các phòng do officerID quản lý
            ///</summary>
            string storedProcedureName = $"Proc_officer_GetAllDetail";

            // tham số đầu vào cho Stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("@v_OfficerID", officerID);
            var tam8 = officerID;
            // connect with database
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var tam = multipleResults.ToString();

                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    var result = new OfficerDetail();

                    result.officer = multipleResults.Read<Officer>().Single();
                    result.storageRooms = multipleResults.Read<StorageRoom>().ToList();
                    result.subjects = multipleResults.Read<Subject>().ToList();


                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
        }
        #endregion

    }
}
