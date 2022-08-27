using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Web07.LHTrung.GD.Common.Entities
{
    /*kho phòng*/
    [Table("storageroom")]
    public class StorageRoom
    {
        [Key]
        // id kho phòng
        public Guid StorageRoomID { get; set; }

        // mã kho phòng
        public string? StorageRoomCode { get; set; }

        // tên kho phòng
        public string? StorageRoomName { get; set; }

        // ngày tạo kho phòng
        public DateTime CreatedDate { get; set; }

        //người tạo kho phòng 
        public string? CreatedBy { get; set; }

        // ngày sửa đổi
        public DateTime ModifiedDate { get; set; }

        // người sửa dổi
        public string? ModifiedBy { get; set; }
    }
}
