using MISA.WEB07.LHTRUNG.GD.DAL.Manager.SubjectMNGDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;

namespace MISA.WEB07.LHTRUNG.GD.BUS.Manager.SubjectMNGBUS
{
    public class SubjectManagerBUS : BaseBUS<SubjectManager>, ISubjectManagerBUS
    {
        #region Feild
        private ISubjectManagerDAL _subjectManagerDAL;
        #endregion

        #region Contructor
        public SubjectManagerBUS(ISubjectManagerDAL subjectManagerDAL) : base(subjectManagerDAL)
        {
            _subjectManagerDAL = subjectManagerDAL;
        }
        #endregion

        #region Method
        #endregion
    }
}
