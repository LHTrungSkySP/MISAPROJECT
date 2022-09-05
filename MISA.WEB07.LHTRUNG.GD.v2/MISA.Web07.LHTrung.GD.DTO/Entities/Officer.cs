using MISA.WEB07.LHTRUNG.GD.DTO.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB07.LHTRUNG.GD.DTO
{
    [Table("officer")]
    public class Officer
    {
        // ID nhân viên
        [Key]
        public Guid? OfficerID { get; set; } = Guid.NewGuid();

        // mã nhân viên
        [Required(ErrorMessage = "e001")]
        public string? OfficerCode { get; set; }

        // tên nhân viên
        [Required(ErrorMessage = "e002")]
        public string? OfficerName { get; set; }

        // ngày sinh
        public DateTime DateOfBirth { get; set; }

        // giới tính
        public Gender Gender { get; set; }

        // số chúng minh
        public string? IdentityNumber { get; set; }

        // ngày cấp
        public DateTime? GrantedDay { get; set; }

        // nơi cấp
        public string? GrantedPlace { get; set; }

        // email
        [EmailAddress(ErrorMessage = "e009")]
        public string? Email { get; set; }

        // số điện thoại
        public string? PhoneNumber { get; set; }

        // id tổ chuyên môn
        public Guid? GroupID { get; set; }

        // tên tổ chuyên môn
        public string? GroupName { get; set; }


        // có trình độ quản lý thiết bị ?
        public EMT? EMT { get; set; }

        // tình trạng làm việc
        public WorkStatus? WorkStatus { get; set; }

        // ngày nghỉ việc
        public DateTime? QuitDate { get; set; }

        // ngày tạo 
        public DateTime? CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        //ngày sửa dổi 
        public DateTime? ModifiedDate { get; set; }

        // người sửa đổi
        public string? ModifiedBy { get; set; }


        //// khóa ngoại tới Tổ (Group)  
        //[ForeignKey("GroupID")]
        //public Group? Group { get; set; }

    }
}
