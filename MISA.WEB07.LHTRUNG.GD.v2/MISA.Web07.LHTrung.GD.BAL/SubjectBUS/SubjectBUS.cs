using MISA.WEB07.LHTRUNG.GD.DAL.SubjectDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.BUS.StorageRoomBUS
{
    public class SubjectBUS : BaseBUS<Subject>, ISubjectBUS
    {
        #region Feild
        private ISubjectDAL _subjectDAL;
        #endregion

        #region Contructor
        public SubjectBUS(ISubjectDAL subjectDAL) : base(subjectDAL)
        {
            _subjectDAL = subjectDAL;
        }
        #endregion

        #region Method
        #endregion
    }
}
