using MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL;
using System.Text.RegularExpressions;

namespace MISA.WEB07.LHTRUNG.GD.BUS
{
    public class BaseBUS<T> : IBaseBUS<T>
    {
        #region Feild

        private IBaseDAL<T> _baseDAL;

        #endregion

        #region Contructor

        public BaseBUS(IBaseDAL<T> baseDAL)
        {
            _baseDAL = baseDAL;
        }

        public int DeleteOneRecord(Guid recordID)
        {
            return _baseDAL.DeleteOneRecord(recordID);
        }


        #endregion

        #region Method
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của một bảng</returns>
        /// Created by:  LHTrung
        public IEnumerable<dynamic> GetAllRecords()
        {
            return _baseDAL.GetAllRecords();
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Thêm mới thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: TMSANG (24/08/2022)
        public Guid? InsertOneRecord(T record)
        {
            return _baseDAL.InsertOneRecord(record);
        }

        public int? UpdateOneRecord(T record)
        {
            return _baseDAL.UpdateOneRecord(record);
        }

        public string GetNewCode()
        {
            string newCode = _baseDAL.GetNewCode();
            // Create a Regex  
            Regex rexCodeNumber = new Regex(@"[0-9]\w+");
            Regex rexStrNumber = new Regex(@"[A-Z]\w");

            // Get all matches  
            Match matchedNumber = rexCodeNumber.Match(newCode);
            Match matchedStr = rexStrNumber.Match(newCode);

            string kq = matchedStr.Value + (int.Parse(matchedNumber.Value) + 1);

            return kq;
        }
        /// <summary>
        /// Kiểm tra mã mới
        /// </summary>
        /// <returns>mã mới có trùng không</returns>
        /// Created by: LHTrung
        public bool CheckDuplicateCode(string Code)
        {
            return _baseDAL.CheckDuplicateCode(Code);
        }

        ///// <summary>
        ///// Kiểm tra dữ liệu đầu vào
        ///// </summary>
        ///// <returns>dữ liệu Input có đúng định dạng không</returns>
        ///// Created by: LHTrung
        //public virtual ErrorResult Validate(T record)
        //{
        //    return HandleError.ValidateEntity(ModelState, HttpContext);;
        //}
        #endregion

    }
}
