using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.SubjectMNGBUS;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectMNGsController : ControllerBase
    {
        #region
        private ISubjectManagerBUS _subjectManagerBUS;
        #endregion

        #region Contructor
        public SubjectMNGsController(ISubjectManagerBUS subjectManagerBUS)
        {
            _subjectManagerBUS = subjectManagerBUS;
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
        public IActionResult GetAllRecords()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _subjectManagerBUS.InsertOneRecord);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        #endregion
    }
}
