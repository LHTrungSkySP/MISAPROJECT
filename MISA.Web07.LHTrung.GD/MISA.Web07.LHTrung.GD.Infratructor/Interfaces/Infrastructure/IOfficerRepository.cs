using MISA.Web07.LHTrung.GD.Core.Entities;

namespace MISA.Web07.LHTrung.GD.Core.Interfaces.Infrastructure
{
    public interface IOfficerRepository
    {
        IEnumerable<Officer> GetAll();

        Officer GetById(Guid officerID);

        int Insert(Officer officer);

        int Update(Officer officer, Guid officerID);

        int Delete(Guid officerID);

        IEnumerable<Officer> GetPaging(int pageSize, int pageIndex);
    }
}
