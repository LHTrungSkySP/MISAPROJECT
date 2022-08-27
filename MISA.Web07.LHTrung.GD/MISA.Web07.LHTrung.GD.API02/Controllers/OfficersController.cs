using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Web07.LHTrung.GD.Common.Entities;
using MISA.Web07.LHTrung.GD.Common.Enums.DTO;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;


namespace MISA.Web07.LHTrung.GD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficersController : ControllerBase
    {
        private const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";
        private readonly MySqlConnection _mySqlConnection = new MySqlConnection(CONNECTION_STRING);
        /// <summary>
        /// API Thêm mới 1 nhân viên
        /// </summary>
        /// <param name="officer">Đối tượng nhân viên muốn thêm mới</param>
        /// <returns>ID của nhân viên vừa thêm mới</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult InsertOfficer([FromBody] Officer officer)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL


                // Chuẩn bị câu lệnh INSERT INTO
                string insertOfficerCommand = "INSERT INTO officer (OfficerID, OfficerCode, FullName, DateOfBirth, Gender, IdentityNumber, GrantedDay, GrantedPlace, Email, PhoneNumber, GroupID, GroupName, SubjectName, EMT, WorkStatus, QuitDate, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, StorageRoomName) " +
                    "VALUES (@OfficerID, @OfficerCode, @FullName, @DateOfBirth, @Gender, @IdentityNumber, @GrantedDay, @GrantedPlace, @Email, @PhoneNumber, @GroupID, @GroupName, @SubjectName, @EMT, @WorkStatus, @QuitDate, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy, @StorageRoomName);";
                // Chuẩn bị tham số đầu vào cho câu lệnh INSERT INTO
                var officerID = Guid.NewGuid();
                var parameters = new DynamicParameters();
                parameters.Add("@OfficerID", officerID);
                parameters.Add("@OfficerCode", officer.OfficerCode);
                parameters.Add("@FullName", officer.FullName);
                parameters.Add("@DateOfBirth", officer.DateOfBirth);
                parameters.Add("@Gender", officer.Gender);
                parameters.Add("@IdentityNumber", officer.IdentityNumber);
                parameters.Add("@GrantedPlace", officer.GrantedPlace);
                parameters.Add("@GrantedDay", officer.GrantedDay);
                parameters.Add("@Email", officer.Email);
                parameters.Add("@PhoneNumber", officer.PhoneNumber);
                parameters.Add("@GroupID", officer.GroupID);
                parameters.Add("@GroupName", officer.GroupName);
                parameters.Add("@SubjectName", officer.SubjectName);
                parameters.Add("@EMT", officer.EMT);
                parameters.Add("@WorkStatus", officer.WorkStatus);
                parameters.Add("@QuitDate", officer.QuitDate);
                parameters.Add("@CreatedDate", officer.CreatedDate);
                parameters.Add("@CreatedBy", officer.CreatedBy);
                parameters.Add("@ModifiedDate", officer.ModifiedDate);
                parameters.Add("@ModifiedBy", officer.ModifiedBy);
                parameters.Add("@StorageRoomName", officer.StorageRoomName);

                // Thực hiện gọi vào DB để chạy câu lệnh INSERT INTO với tham số đầu vào ở trên
                int numberOfAffectedRows = _mySqlConnection.Execute(insertOfficerCommand, parameters);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status201Created, officerID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Sửa 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn sửa</param>
        /// <param name="officer">Đối tượng nhân viên muốn sửa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpPut("{officerID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateOfficer([FromRoute] Guid officerID, [FromBody] Officer officer)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị câu lệnh UPDATE
                string updateOfficerCommand = "UPDATE officer " +
                    "SET OfficerCode = @OfficerCode, " +
                    "OfficerName = @OfficerName, " +
                    "DateOfBirth = @DateOfBirth, " +
                    "Gender = @Gender, " +
                    "IdentityNumber = @IdentityNumber, " +
                    "IdentityIssuedPlace = @IdentityIssuedPlace, " +
                    "IdentityIssuedDate = @IdentityIssuedDate, " +
                    "Email = @Email, " +
                    "PhoneNumber = @PhoneNumber, " +
                    "PositionID = @PositionID, " +
                    "DepartmentID = @DepartmentID, " +
                    "TaxCode = @TaxCode, " +
                    "Salary = @Salary, " +
                    "JoiningDate = @JoiningDate, " +
                    "WorkStatus = @WorkStatus, " +
                    "ModifiedDate = @ModifiedDate, " +
                    "ModifiedBy = @ModifiedBy " +
                    "WHERE OfficerID = @OfficerID;";

                // Chuẩn bị tham số đầu vào cho câu lệnh UPDATE
                var parameters = new DynamicParameters();

                parameters.Add("@OfficerID", officerID);
                parameters.Add("@OfficerCode", officer.OfficerCode);
                parameters.Add("@FullName", officer.FullName);
                parameters.Add("@DateOfBirth", officer.DateOfBirth);
                parameters.Add("@Gender", officer.Gender);
                parameters.Add("@IdentityNumber", officer.IdentityNumber);
                parameters.Add("@GrantedPlace", officer.GrantedPlace);
                parameters.Add("@GrantedDay", officer.GrantedDay);
                parameters.Add("@Email", officer.Email);
                parameters.Add("@PhoneNumber", officer.PhoneNumber);
                parameters.Add("@GroupID", officer.GroupID);
                parameters.Add("@GroupName", officer.GroupName);
                parameters.Add("@SubjectName", officer.SubjectName);
                parameters.Add("@EMT", officer.EMT);
                parameters.Add("@WorkStatus", officer.WorkStatus);
                parameters.Add("@QuitDate", officer.QuitDate);
                parameters.Add("@ModifiedDate", officer.ModifiedDate);
                parameters.Add("@ModifiedBy", officer.ModifiedBy);
                parameters.Add("@StorageRoomName", officer.StorageRoomName);

                // Thực hiện gọi vào DB để chạy câu lệnh UPDATE với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(updateOfficerCommand, parameters);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, officerID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }

            }
            catch (MySqlException mySqlException)
            {
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e003");
                }

                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Xóa 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn xóa</param>
        /// <returns>ID của nhân viên vừa xóa</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpDelete("{officerID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteOfficerByID([FromRoute] Guid officerID)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị câu lệnh DELETE
                string deleteOfficerCommand = "DELETE FROM officer WHERE OfficerID = @OfficerID";

                // Chuẩn bị tham số đầu vào cho câu lệnh DELETE
                var parameters = new DynamicParameters();
                parameters.Add("@OfficerID", officerID);

                // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(deleteOfficerCommand, parameters);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, officerID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="positionID">ID vị trí</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Officer>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterOfficers(
            [FromQuery] string? keyword,
            [FromQuery] Guid? subjectID,
            [FromQuery] Guid? groupID,
            [FromQuery] Guid? storageRoomID,
            [FromQuery] int pageSize = 50,
            [FromQuery] int pageNumber = 1)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_officer_GetPaging";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("@v_Offset", (pageNumber - 1) * pageSize);
                parameters.Add("@v_Limit", pageSize);
                parameters.Add("@v_Sort", "ModifiedDate DESC");

                var orConditions = new List<string>();
                var andConditions = new List<string>();
                string whereClause = "";

                if (keyword != null)
                {
                    orConditions.Add($"OfficerCode LIKE '%{keyword}%'");
                    orConditions.Add($"FullName LIKE '%{keyword}%'");
                    orConditions.Add($"PhoneNumber LIKE '%{keyword}%'");
                }
                if (orConditions.Count > 0)
                {
                    whereClause = $"({string.Join(" OR ", orConditions)})";
                }

                if (subjectID != null)
                {
                    andConditions.Add($"SubjectID LIKE '%{subjectID}%'");
                }
                if (groupID != null)
                {
                    andConditions.Add($"GroupID LIKE '%{groupID}%'");
                }
                if (storageRoomID != null)
                {
                    andConditions.Add($"StorageRoomID LIKE '%{storageRoomID}%'");
                }

                if (andConditions.Count > 0)
                {
                    whereClause += $" AND {string.Join(" AND ", andConditions)}";
                }

                parameters.Add("@v_Where", whereClause);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    var officers = multipleResults.Read<Officer>().ToList();
                    var totalCount = multipleResults.Read<long>().Single();
                    return StatusCode(StatusCodes.Status200OK, new PagingData<Officer>()
                    {
                        Data = officers,
                        TotalCount = totalCount
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="officerID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet("{officerID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Officer))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOfficerByID([FromRoute] Guid officerID)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_officer_GetByOfficerID";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("@v_OfficerID", officerID);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var officer = mySqlConnection.QueryFirstOrDefault<Officer>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (officer != null)
                {
                    return StatusCode(StatusCodes.Status200OK, officer);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: TMSANG (09/06/2022)
        [HttpGet("new-code")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNewOfficerCode()
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = "Server=localhost;Port=3306;Database=misa.web07.gd.lhtrung;Uid=root;Pwd=LHTrungSkySP123!@#;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_officer_GetMaxCode";

                // Thực hiện gọi vào DB để chạy stored procedure ở trên
                string maxOfficerCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý sinh mã nhân viên mới tự động tăng
                // Cắt chuỗi mã nhân viên lớn nhất trong hệ thống để lấy phần số
                // Mã nhân viên mới = "NV" + Giá trị cắt chuỗi ở  trên + 1
                // "NV99997"
                string newOfficerCode = "NV" + (Int64.Parse(maxOfficerCode.Substring(2)) + 1).ToString();

                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, newOfficerCode);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
