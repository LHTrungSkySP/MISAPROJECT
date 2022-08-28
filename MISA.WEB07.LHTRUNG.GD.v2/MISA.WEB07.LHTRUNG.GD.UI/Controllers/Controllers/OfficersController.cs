using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficersController : BasesController<Officer>
    {
        #region Feild
        private IOfficerBUS _officerBUS;

        #endregion

        #region Contructor
        public OfficersController(IOfficerBUS officerBUS) : base(officerBUS)
        {
            _officerBUS = officerBUS;
        }
        #endregion

    }
}
