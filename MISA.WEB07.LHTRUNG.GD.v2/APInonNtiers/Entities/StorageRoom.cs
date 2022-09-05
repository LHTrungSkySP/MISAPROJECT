using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APInonNtiers
{
    /*kho phòng*/
    [Table("storageroom")]
    public class StorageRoom
    {
        [Key]
        // id kho phòng
        public Guid StorageRoomID { get; set; }

        // mã kho phòng
        [Required(ErrorMessage = "e001")]
        public string? StorageRoomCode { get; set; }

        // tên kho phòng
        [Required(ErrorMessage = "e002")]
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
