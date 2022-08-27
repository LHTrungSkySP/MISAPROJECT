using Microsoft.AspNetCore.Mvc;
using MISA.Web07.LHTrung.GD.Common.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.Web07.LHTrung.GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageRoomsController : ControllerBase
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách kho phòng
        /// </summary>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<StorageRoom>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllStorageRooms()
        {
            return StatusCode(StatusCodes.Status200OK, new List<StorageRoom>
            {
                new StorageRoom
                {
                    StorageRoomID = Guid.NewGuid(),
                    StorageRoomCode = "R01",
                    StorageRoomName = "Phòng Tóa - Lý",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new StorageRoom
                {
                    StorageRoomID = Guid.NewGuid(),
                    StorageRoomCode = "S02",
                    StorageRoomName = "Phòng Hóa - Sinh",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new StorageRoom
                {
                    StorageRoomID = Guid.NewGuid(),
                    StorageRoomCode = "S03",
                    StorageRoomName = "Kho Phòng chung",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
            });
        }
    }
}
