using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.StorageRoomMNGBUS;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageRoomMNGsController : ControllerBase
    {
        #region
        private IStorageRoomMNGBUS _storageRoomMNGBUS;
        #endregion

        #region Contructor
        public StorageRoomMNGsController(IStorageRoomMNGBUS subjectManagerBUS)
        {
            _storageRoomMNGBUS = subjectManagerBUS;
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
        public IActionResult GetAllRecords([FromRoute] Guid id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _storageRoomMNGBUS.GetAllRecords(id));
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
