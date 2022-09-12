using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region
        private IBaseBUS<T> _baseBUS;
        #endregion

        #region Contructor
        public BasesController(IBaseBUS<T> baseBUS)
        {
            _baseBUS = baseBUS;
        }
        #endregion

        #region Method

        /// <summary>
        /// API get 1 table
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>toàn bộ bản ghi của 1 bảng</returns>
        /// Created by: LHTrung

        [HttpGet]
        public virtual IActionResult GetAllRecords()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBUS.GetAllRecords());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// API Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID của bản ghi vừa thêm mới</returns>
        /// Created by: TMSANG (24/08/2022)
        [HttpPost]
        public virtual IActionResult InsertOneRecord(
            [FromBody] T record
            )
        {
            try
            {
                var recordID = _baseBUS.InsertOneRecord(record);

                if (recordID != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status201Created, recordID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e004");
                }
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status207MultiStatus, mySqlException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual IActionResult DeleteOneRecord([FromRoute] Guid id)
        {
            try
            {
                var recordID = _baseBUS.DeleteOneRecord(id);

                if (recordID != Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status201Created, recordID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "ngu");
                }
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut]
        public virtual IActionResult UpdateOneRecord([FromBody] T record)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBUS.UpdateOneRecord(record));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet("NewCode")]
        public virtual IActionResult GetNewCode()
        {
            try
            {
                var newCode = _baseBUS.GetNewCode();

                if (newCode != null)
                {
                    return StatusCode(StatusCodes.Status200OK, newCode);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "ngu");
                }
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
