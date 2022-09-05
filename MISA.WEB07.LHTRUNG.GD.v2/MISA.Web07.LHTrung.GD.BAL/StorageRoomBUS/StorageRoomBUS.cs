using MISA.WEB07.LHTRUNG.GD.DAL.StorageRoomDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.BUS.StorageRoomBUS
{
    public class StorageRoomBUS : BaseBUS<StorageRoom>, IStorageRoomBUS
    {
        #region Feild
        private IStorageRoomDAL _storageRoomDAL;
        #endregion

        #region Contructor
        public StorageRoomBUS(IStorageRoomDAL storageRoomDAL) : base(storageRoomDAL)
        {
            _storageRoomDAL = storageRoomDAL;
        }
        #endregion

    }
}
