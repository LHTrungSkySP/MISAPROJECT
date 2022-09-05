using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.StorageRoomBUS;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageRoomsController : BasesController<StorageRoom>
    {
        #region Feild
        private IStorageRoomBUS _storageRoom;
        #endregion

        #region Controller
        public StorageRoomsController(IStorageRoomBUS storageRoom) : base(storageRoom)
        {
            _storageRoom = storageRoom;
        }
        #endregion
    }
}
