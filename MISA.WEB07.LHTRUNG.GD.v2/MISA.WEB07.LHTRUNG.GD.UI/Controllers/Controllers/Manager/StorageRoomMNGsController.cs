using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.StorageRoomMNGBUS;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.UI.Controllers.BaseControllers;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageRoomMNGsController : BaseManagerController<StorageRoomManager>
    {
        #region
        private IStorageRoomMNGBUS _storageRoomMNGBUS;
        #endregion

        #region Contructor
        public StorageRoomMNGsController(IStorageRoomMNGBUS storageRoomMNGBUS) : base(storageRoomMNGBUS)
        {
            _storageRoomMNGBUS = storageRoomMNGBUS;
        }
        #endregion

        #region Method
        #endregion

    }
}
