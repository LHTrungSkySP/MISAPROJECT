using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : BasesController<Subject>
    {
        #region
        private ISubjectBUS _subject;
        #endregion

        #region Contructor
        public SubjectsController(ISubjectBUS subject) : base(subject)
        {
            _subject = subject;
        }

        #endregion

        #region Method
        #endregion


    }
}
