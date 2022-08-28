using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS;

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
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
        #endregion
        //[HttpGet("new-code")]
        //[SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        //[SwaggerResponse(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(StatusCodes.Status500InternalServerError)]
        //public IActionResult GetNewEmployeeCode()
        //{
        //    return StatusCode(StatusCodes.Status200OK, "NV00003");
        //}

    }
}
