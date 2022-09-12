using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.Manager.SubjectMNGBUS;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.UI.Controllers.BaseControllers;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers.Manager
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectMNGsController : BaseManagerController<SubjectManager>
    {
        #region
        private ISubjectManagerBUS _subjectManagerBUS;
        #endregion

        #region Contructor
        public SubjectMNGsController(ISubjectManagerBUS subjectManagerBUS) : base(subjectManagerBUS)
        {
            _subjectManagerBUS = subjectManagerBUS;
        }
        #endregion


    }
}
