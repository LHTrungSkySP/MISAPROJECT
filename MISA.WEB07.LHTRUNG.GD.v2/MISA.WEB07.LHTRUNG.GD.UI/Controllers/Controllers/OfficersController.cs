using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;
using MISA.WEB07.LHTRUNG.GD.DTO.Exceptions;
using MISA.WEB07.LHTRUNG.GD.UI.Helpers;
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
        #endregion

        #region Contructor
        public OfficersController(IOfficerBUS officerBUS) : base(officerBUS)
        {
            _officerBUS = officerBUS;
        }
        #endregion

        #region Method
        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="subjectID">ID môn </param>
        /// <param name="groupID">ID phòng ban</param>
        /// <param name="storageRoomID">ID phòng ban</param>
        /// <param name="sortBy">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
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
            try
            {
                var results = _officerBUS.FilterOfficer(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
                if (results != null)
                {
                    var officers = results.ListID;
                    var totalCount = results.TotalCount;
                    return StatusCode(StatusCodes.Status200OK, results);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(ex, HttpContext));
            }

        }

        /// <summary>
        /// API Lấy thông tin chi tiết vê OfficerID
        /// </summary>
        /// <returns>Một đối tượng gồm:
        /// + Thông tin cá nhân của nhân viên 
        /// + Danh sách các môn học do nhân viên đso dạy
        /// + Danh sách kho phòng nhân viên đó quản lý</returns>
        /// Created by: LHTrung
        /// 
        [HttpGet("GetDetail/{officerID}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOfficerDetail([FromRoute] Guid officerID)
        {
            try
            {
                var result = _officerBUS.GetOfficerDetail(officerID);
                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(ex, HttpContext));
            }

        }

        /// <summary>
        /// API Lấy danh sách thông tin chi tiết nhân viên theo kết quả lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm (mã NV, Tên NV, SĐT)</param> 
        /// <param name="subjectID">ID môn học</param>
        /// <param name="groupID">ID tổ bộ môn</param>
        /// <param name="storageRoomID">ID phòng kho</param>
        /// <param name="pageSize">Số bản ghi trong một trang</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách thông tin chi tiết nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
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
            try
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }

        /// <summary>
        /// API thêm mới thông tin chi tiết vê OfficerID
        /// </summary>
        /// <param name="officerDetail" chứa thông tin cần thêm mới 
        /// <returns>id nhân viên đc chèn</returns>
        /// Created by: LHTrung
        /// 
        [HttpPost("officerDetail")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult InsertOfficersDetail([FromBody] OfficerDetail officerDetail)
        {
            try
            {
                var record = officerDetail.officer;
                var validateResutl = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validateResutl != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validateResutl);
                }
                return StatusCode(StatusCodes.Status201Created, _officerBUS.InsertDetailOfficer(officerDetail));
            }
            catch (ValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.errorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult(mySqlException, HttpContext));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }

        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        [HttpPut("officerDetail")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateDetailOneOfficer([FromBody] OfficerDetail officerDetail)
        {
            try
            {
                var record = officerDetail.officer;
                var validateResutl = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validateResutl != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validateResutl);
                }
                return StatusCode(StatusCodes.Status200OK, _officerBUS.UpdateOfficerDetail(officerDetail));
            }
            catch (ValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.errorResult);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(ex, HttpContext));
            }

        }


        /// <summary>
        /// API Thêm mới 1 bản ghi Officer
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Created by: TMSANG (24/08/2022)
        [HttpPost]
        public override IActionResult InsertOneRecord(
            [FromBody] Officer record)
        {
            try
            {
                var validateResutl = HandleError.ValidateEntity(ModelState, HttpContext);
                if (validateResutl != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, validateResutl);
                }
                var recordID = _officerBUS.InsertOneRecord(record);

                return StatusCode(StatusCodes.Status201Created, recordID);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult(mySqlException, HttpContext));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(ex, HttpContext));
            }
        }
        #endregion

    }
}
