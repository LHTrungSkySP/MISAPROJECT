using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Web07.LHTrung.GD.Core.Entities
{
    /*Môn*/
    [Table("subject")]
    public class Subject
    {
        /*id môn học */
        [Key]
        public Guid SubjectID { get; set; }

        //mã môn học 
        public string? SubjectCode { get; set; }

        //tên môn học 
        public string? SubjectName { get; set; }

        //ngày tạo môn học
        public DateTime CreatedDate { get; set; }

        //người tạo môn học 
        public string? CreatedBy { get; set; }

        //ngày sửa dổi 
        public DateTime? ModifiedDate { get; set; }

        // người sửa dổi
        public string? ModifiedBy { get; set; }
    }
}
