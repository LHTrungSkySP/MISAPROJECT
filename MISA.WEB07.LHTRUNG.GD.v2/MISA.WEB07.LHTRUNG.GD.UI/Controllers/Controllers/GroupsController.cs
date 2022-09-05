using Microsoft.AspNetCore.Mvc;
using MISA.WEB07.LHTRUNG.GD.BUS.GroupBUS;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.UI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : BasesController<Group>
    {
        #region Feild
        private IGroupBUS _group;
        #endregion

        #region Contructor
        public GroupsController(IGroupBUS group) : base(group)
        {
            _group = group;
        }
        #endregion
    }
}
