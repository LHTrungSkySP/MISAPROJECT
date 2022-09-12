using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.BaseManager;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseManagerController<T> : ControllerBase
    {
        #region
        private IBaseManagerBUS<T> _baseManagerBUS;
        #endregion

        #region Contructor
        public BaseManagerController(IBaseManagerBUS<T> baseBUS)
        {
            _baseManagerBUS = baseBUS;
        }
        #endregion

        #region Method

        /// <summary>
        /// API get 1 table
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>toàn bộ bản ghi của 1 bảng</returns>
        /// Created by: LHTrung

        [HttpGet("{id}")]
        public virtual IActionResult GetAllRecords([FromRoute] Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseManagerBUS.GetAllRecords(id));
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
                var recordID = _baseManagerBUS.InsertOneRecord(record);

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
                return StatusCode(StatusCodes.Status400BadRequest, mySqlException.Message);
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
                var recordID = _baseManagerBUS.Reset(id);

                if (recordID > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, id);
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
