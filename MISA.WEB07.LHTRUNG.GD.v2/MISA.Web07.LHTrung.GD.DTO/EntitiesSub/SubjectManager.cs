using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB07.LHTRUNG.GD.DTO
{
    [Table("SubjectManager")]
    public class SubjectManager
    {
        // ID quản lý phòng kho
        [Key]
        public Guid SubjectManagerID { get; set; }

        // ID phòng kho
        public Guid SubjectID { get; set; }

        // ID nhân viên
        public Guid OfficerID { get; set; }

        // ngày tạo 
        public DateTime? CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        // ngày sửa dổi
        public DateTime? ModifiedDate { get; set; }

        // người sửa đổi
        public string? ModifiedBy { get; set; }
    }
}
