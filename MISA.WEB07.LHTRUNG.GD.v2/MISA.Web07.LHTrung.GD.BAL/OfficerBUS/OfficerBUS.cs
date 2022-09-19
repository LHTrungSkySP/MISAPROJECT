using MISA.WEB07.LHTRUNG.GD.DAL.OfficerDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;
using MISA.WEB07.LHTRUNG.GD.DTO.Enums;
using MISA.WEB07.LHTRUNG.GD.DTO.Resources;
using System.Text.RegularExpressions;

namespace MISA.WEB07.LHTRUNG.GD.BUS
{
    public class OfficerBUS : BaseBUS<Officer>, IOfficerBUS
    {
        #region Field
        private IOfficerDAL _officerDAL;
        #endregion

        #region Contructor
        public OfficerBUS(IOfficerDAL officerDAL) : base(officerDAL)
        {
            _officerDAL = officerDAL;
        }
        #endregion

        #region Method
        /// <summary>
        /// API Lấy danh sách ID nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm (mã NV, Tên NV, SĐT)</param> 
        /// <param name="subjectID">ID môn học</param>
        /// <param name="groupID">ID tổ bộ môn</param>
        /// <param name="storageRoomID">ID phòng kho</param>
        /// <param name="pageSize">Số bản ghi trong một trang</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách ID nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
        public PagingData FilterOfficer(string? keyword, Guid? subjectID, Guid? groupID, Guid? storageRoomID, string sortBy = "ModifiedDate DESC", int pageSize = 10, int pageNumber = 1)
        {
            return _officerDAL.FilterOfficer(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
        }

        /// <summary>
        /// API Lấy thông tin chi tiết vê OfficerID
        /// </summary>
        /// <returns>Một đối tượng gồm:
        /// + Thông tin cá nhân của nhân viên 
        /// + Danh sách các môn học do nhân viên đso dạy
        /// + Danh sách kho phòng nhân viên đó quản lý</returns>
        /// Created by: LHTrung
        /// 
        public OfficerDetail GetOfficerDetail(Guid officerID)
        {
            return _officerDAL.GetOfficerDetail(officerID);
        }

        /// <summary>
        /// API Lấy danh sách thông tin chi tiết nhân viên theo kết quả lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm (mã NV, Tên NV, SĐT)</param> 
        /// <param name="subjectID">ID môn học</param>
        /// <param name="groupID">ID tổ bộ môn</param>
        /// <param name="storageRoomID">ID phòng kho</param>
        /// <param name="pageSize">Số bản ghi trong một trang</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách thông tin chi tiết nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: LHTrung
        public OfficerDetailPaging? GetOfficersDetail(string? keyword, Guid? subjectID, Guid? groupID, Guid? storageRoomID, string sortBy = "ModifiedDate DESC", int pageSize = 10, int pageNumber = 1)
        {
            return _officerDAL.GetOfficersDetail(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);
        }



        /// <summary>
        /// API thêm mới thông tin chi tiết vê OfficerID
        /// </summary>
        /// <param name="officerDetail" chứa thông tin cần thêm mới 
        /// <returns>id nhân viên đc chèn</returns>
        /// Created by: LHTrung
        /// 
        public Guid? InsertDetailOfficer(OfficerDetail officerDetail)
        {
            return _officerDAL.InsertDetailOfficer(officerDetail);
        }

        /// <summary>
        /// Sửa một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng (Sửa thành công thì sẽ trả về 1 bản ghi bị ảnh hưởng)</returns>
        /// Created by: LHTrung
        public int UpdateOfficerDetail(OfficerDetail officerDetail)
        {
            return _officerDAL.UpdateOfficerDetail(officerDetail);
        }

        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        /// <returns>dữ liệu Input có đúng định dạng không</returns>
        /// Created by: LHTrung
        public ErrorResult? Validate(Officer officer)
        {
            var errors = new Dictionary<int, string>();
            // validate mã nhân viên
            if (officer.OfficerCode == null)
            {
                errors.Add((int)ErrorCode.OfficerCodeFail, String.Format(Resource.InfoNotEmpty, "Mã nhân viên"));
            }
            else
            {
                if (officer.OfficerCode.Length != 5)
                {
                    errors.Add((int)ErrorCode.OfficerCodeFail, String.Format(Resource.lengthNotTrue, "Mã nhân viên"));
                }
                else
                {
                    Regex rexCodeNumber = new Regex(@"[0-9]\w+");
                    Regex rexStrNumber = new Regex(@"[A-z]\w");

                    Match matchedNumber = rexCodeNumber.Match(officer.OfficerCode);
                    Match matchedStr = rexStrNumber.Match(officer.OfficerCode);
                    if (matchedNumber.Length == 0)
                    {
                        errors.Add((int)ErrorCode.OfficerCodeFail, String.Format(Resource.InfoNotTrue, "Mã nhân viên"));
                    }
                    else if (int.Parse(matchedNumber.Value) > 999 || int.Parse(matchedNumber.Value) < 0)
                    {
                        errors.Add((int)ErrorCode.OfficerCodeFail, String.Format(Resource.InfoOutSize, "Mã nhân viên"));
                    }
                    else if (matchedStr.Value != "NV")
                    {
                        errors.Add((int)ErrorCode.OfficerCodeFail, String.Format(Resource.InfoNotTrue, "Mã nhân viên"));
                    }
                }
            }
            ///<summary>validate số điện thoại</summary>

            // Create a Regex  
            Regex rexPhoneNumber = new Regex(@"[0-9]\w+");

            if (officer.PhoneNumber != "")
            {
                Match matchedNumber = rexPhoneNumber.Match(officer.PhoneNumber);
                if (matchedNumber.Value.Length != officer.PhoneNumber.Length || officer.PhoneNumber.Length < 10)
                {
                    errors.Add((int)ErrorCode.PhoneNumberFail, Resource.phoneNumberFail);
                }
            }
            // validate email
            if (officer.Email != "")
            {
                if (!IsValidEmail(officer.Email))
                {
                    errors.Add((int)ErrorCode.EmailFail, Resource.emailFail);
                }
            }

            // valiadate ngày nghỉ việc
            if (officer.QuitDate != null)
            {
                if (officer.QuitDate > DateTime.Now)
                {
                    errors.Add((int)ErrorCode.QuitDateFail, Resource.quitDate_exp);
                }
            }
            if (errors.Count > 0)
            {
                return new ErrorResult(ErrorCode.Validate, Resource.valiadate_exp, errors, "", "");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// valiadate email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true nếu emial đsung định dạng</returns>
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
