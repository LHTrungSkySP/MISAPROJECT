using MISA.Web07.LHTrung.GD.Core.Entities;

namespace MISA.Web07.LHTrung.GD.Core.Interfaces.Services
{
    public interface IOfficerService
    {
        int InsertService(Officer officer);
        int UpdateService(Officer officer, Guid OfficerID);
        int DeleteService(Officer officer, Guid OfficerID);
    }
}
