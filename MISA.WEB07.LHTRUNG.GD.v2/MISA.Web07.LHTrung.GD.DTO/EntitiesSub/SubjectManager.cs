using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB07.LHTRUNG.GD.DTO
{
    [Table("SubjectManager")]
    public class SubjectManager
    {
        // ID quản lý phòng kho
        [Key]
        public Guid SubjectManagerID;

        // ID phòng kho
        public Guid SubjectID;

        // ID nhân viên
        public Guid OfficerID;

        // Tên phòng kho
        public string? SubjectName;

        // ngày tạo 
        public DateTime CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        // ngày sửa dổi
        public DateTime ModifiedDate { get; set; }

        // người sửa đổi
        public string? ModifiedBy { get; set; }

        // khóa ngoại tới Môn học (subject)
        [ForeignKey("SubjectID")]
        public Subject? Subject { get; set; }

        // khóa ngoại đến nhân viên (Officer)
        [ForeignKey("OfficerID")]
        public Officer? Officer { get; set; }
    }
}
