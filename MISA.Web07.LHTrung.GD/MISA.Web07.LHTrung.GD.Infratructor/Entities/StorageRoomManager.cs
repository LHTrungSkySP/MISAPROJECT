using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Web07.LHTrung.GD.Core.Entities
{
    [Table("StorageRoomManager")]
    public class StorageRoomManager
    {
        // ID quản lý phòng kho
        [Key]
        public Guid StorageRoomManagerID;

        // ID phòng kho
        public Guid StorageRoomID;

        // ID nhân viên
        public Guid OfficerID;

        // Tên phòng kho
        public string? StorageRoomName;

        // ngày tạo 
        public DateTime CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        // ngày sửa dổi
        public DateTime ModifiedDate { get; set; }

        // người sửa đổi
        public string? ModifiedBy { get; set; }

        // khóa ngoại tới Môn học (subject)
        [ForeignKey("StorageRoomID")]
        public StorageRoom? StorageRoom { get; set; }

        // khóa ngoại đến nhân viên (Officer)
        [ForeignKey("OfficerID")]
        public Officer? Officer { get; set; }

    }
}
