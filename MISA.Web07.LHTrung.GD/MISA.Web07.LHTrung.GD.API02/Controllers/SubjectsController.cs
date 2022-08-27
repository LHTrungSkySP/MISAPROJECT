using Microsoft.AspNetCore.Mvc;
using MISA.Web07.LHTrung.GD.Common.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace MISA.Web07.LHTrung.GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        /// <summary>
        /// API Lấy toàn bộ danh sách môn học
        /// </summary>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Subject>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllSubjects()
        {
            return StatusCode(StatusCodes.Status200OK, new List<Subject>
            {
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S01",
                    SubjectName = "Toán",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S02",
                    SubjectName = "Lý",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S03",
                    SubjectName = "Hóa",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S04",
                    SubjectName = "Ngữ Văn",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S05",
                    SubjectName = "Lý",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S06",
                    SubjectName = "Sinh",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                },
                new Subject
                {
                    SubjectID = Guid.NewGuid(),
                    SubjectCode = "S07",
                    SubjectName = "Sử",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "admin",
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = "admin"
                }
            });
        }
    }
}
