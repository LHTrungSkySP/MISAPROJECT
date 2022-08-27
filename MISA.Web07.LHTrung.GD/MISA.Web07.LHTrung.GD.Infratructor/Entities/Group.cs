using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Web07.LHTrung.GD.Core.Entities
{
    /*Tổ chuyên môn*/
    [Table("Group")]
    public class Group
    {
        // id tổ chuyên môn
        [Key]
        public Guid GroupID { get; set; }

        // mã tổ chuyên môn
        [Required(ErrorMessage = "e003")]
        public string? GroupCode { get; set; }

        // tên tổ chuyên môn
        [Required(ErrorMessage = "e004")]
        public string? GroupName { get; set; }

        // ngày tạo 
        public DateTime CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        // ngày sửa dổi
        public DateTime ModifiedDate { get; set; }

        // người sửa đổi
        public string? ModifiedBy { get; set; }
    }
}
