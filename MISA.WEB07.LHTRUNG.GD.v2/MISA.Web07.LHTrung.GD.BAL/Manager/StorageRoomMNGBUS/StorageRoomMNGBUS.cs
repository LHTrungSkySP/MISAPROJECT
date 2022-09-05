using MISA.WEB07.LHTRUNG.GD.BUS.Manager.BaseManager;
using MISA.WEB07.LHTRUNG.GD.DAL.Manager.StorageRoomMNGDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.BUS.Manager.StorageRoomMNGBUS
{
    public class StorageRoomMNGBUS : BaseManagerBUS<StorageRoomManager>, IStorageRoomMNGBUS
    {
        #region Feild
        private IStorageRoomManagerDAL _storageRoomMNGBUS;
        #endregion

        #region Contructor
        public StorageRoomMNGBUS(IStorageRoomManagerDAL storageRoomMNGDAL) : base(storageRoomMNGDAL)
        {
            _storageRoomMNGBUS = storageRoomMNGDAL;
        }
        #endregion

        #region Method
        #endregion
    }
}
