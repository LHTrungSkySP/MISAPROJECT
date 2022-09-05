﻿using Dapper;
using MISA.WEB07.LHTRUNG.GD.DAL.BaseDAL;
using MISA.WEB07.LHTRUNG.GD.DTO;
using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;
using MySqlConnector;

namespace MISA.WEB07.LHTRUNG.GD.DAL.OfficerDAL
{
    public class OfficerDAL : BaseDAL<Officer>, IOfficerDAL
    {
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
        /// Created by: LHTrung
        public PagingData FilterOfficer(string? keyword, Guid? subjectID, Guid? groupID, Guid? storageRoomID, string sortBy = "ModifiedDate DESC", int pageSize = 10, int pageNumber = 1)
        {
            // chuẩn bị tên của Stored procedure cần dùng
            string storedProcedureName = $"Proc_officer_GetPaging";

            // tham số đầu vào cho Stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("@v_Offset", (pageNumber - 1) * pageSize);
            parameters.Add("@v_Limit", pageSize);
            parameters.Add("@v_Sort", sortBy);

            var orConditions = new List<string>();
            var andConditions = new List<string>();
            string whereClause = "";

            if (keyword != null)
            {
                orConditions.Add($"OfficerCode LIKE '%{keyword}%'");
                orConditions.Add($"OfficerName LIKE '%{keyword}%'");
                orConditions.Add($"PhoneNumber LIKE '%{keyword}%'");
            }
            if (orConditions.Count > 0)
            {
                whereClause = $"({string.Join(" OR ", orConditions)})";
            }

            if (storageRoomID != null)
            {
                andConditions.Add($"StorageRoomID LIKE '%{storageRoomID}%'");
            }
            if (subjectID != null)
            {
                andConditions.Add($"SubjectID LIKE '%{subjectID}%'");
            }
            if (groupID != null)
            {
                andConditions.Add($"GroupID LIKE '%{groupID}%'");
            }

            if (andConditions.Count > 0)
            {
                whereClause += $" AND {string.Join(" AND ", andConditions)}";
            }

            parameters.Add("@v_Where", whereClause);

            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    var results = new PagingData();
                    results.Data = multipleResults.Read<Guid>().ToList();
                    results.TotalCount = multipleResults.Read<long>().Single();

                    return results;
                }
                else
                {
                    return null;
                }
            }

        }
        ///<summary>
        /// lấy thông tin chi tiết officerID 
        ///</summary>
        public OfficerDetail GetOfficerDetail(Guid officerID)
        {
            // chuẩn bị câu lệnh Procedure 

            ///<summary>
            /// lấy id của các phòng do officerID quản lý
            ///</summary>
            string storedProcedureName = $"Proc_officer_GetAllDetail";

            // tham số đầu vào cho Stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("@v_OfficerID", officerID);
            // connect with database
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
            {
                // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    var results = new OfficerDetail();

                    results.officer = multipleResults.Read<Officer>().Single();
                    results.storageRooms = multipleResults.Read<StorageRoom>().ToList();
                    results.subjects = multipleResults.Read<Subject>().ToList();
                    return results;
                }
                else
                {
                    return null;
                }
            }
        }

        ///<summary>
        /// lấy thông tin chi tiết cảu toàn bộ officer 
        ///</summary>
        ///
        public virtual OfficerDetailPaging GetOfficersDetail(string? keyword,
            Guid? subjectID,
            Guid? groupID,
            Guid? storageRoomID,
            string sortBy = "ModifiedDate DESC",
            int pageSize = 10,
            int pageNumber = 1)
        {
            // chuẩn bị câu lệnh Procedure 

            ///<summary>
            /// phân trang
            ///</summary>
            PagingData paging = FilterOfficer(keyword, subjectID, groupID, storageRoomID, sortBy, pageSize, pageNumber);

            ///<summary>
            /// lấy id của các phòng do officerID quản lý
            ///</summary>
            var listID = paging.Data;

            OfficerDetailPaging officerDetailPaging = new OfficerDetailPaging();
            // connect with database

            // Xử lý kết quả trả về từ DB
            if (listID != null)
            {
                foreach (var item in listID)
                {
                    officerDetailPaging.listOfficerDetail.Add(GetOfficerDetail(item));
                }
                officerDetailPaging.Total = paging.TotalCount;
                return officerDetailPaging;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// API thêm mới thông tin chi tiết vê OfficerID
        /// </summary>
        /// <param name="officerDetail" chứa thông tin cần thêm mới 
        /// <returns>id nhân viên đc chèn</returns>
        /// Created by: LHTrung
        /// 
        public Guid InsertDetailOfficer(OfficerDetail officerDetail)
        {
            var id = InsertOneRecord(officerDetail.officer);
            var officer = officerDetail.officer;
            if (officerDetail.subjects != null)
            {
                // gọi vào procedure trong store
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
                {
                    // reset 
                    string storedProcedureNameReset = $"Proc_subjectmanager_ResetAllSubject";
                    var parameter = new DynamicParameters();
                    parameter.Add("@v_officerid", id);
                    mySqlConnection.Execute(storedProcedureNameReset, parameter, commandType: System.Data.CommandType.StoredProcedure);

                    // chuẩn bị câu lệnh procedure thêm mới môn học được cá nhân dạy
                    string storedProcedureName = $"Proc_subjectmanager_InsertOne";
                    foreach (var item in officerDetail.subjects)
                    {
                        // chuẩn bị tham số
                        var parameters = new DynamicParameters();
                        parameters.Add("@v_subjectmanagerid", Guid.NewGuid());
                        parameters.Add("@v_subjectid", item.SubjectID);
                        parameters.Add("@v_officerid", id);
                        parameters.Add("@v_createddate", officer.CreatedDate);
                        parameters.Add("@v_createdby", officer.CreatedBy);
                        parameters.Add("@v_modifieddate", officer.ModifiedDate);
                        parameters.Add("@v_modifiedby", officer.ModifiedBy);

                        // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
                        mySqlConnection.Query(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
            }

            if (officerDetail.storageRooms != null)
            {


                // gọi vào procedure trong store
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ContextString))
                {
                    // reset 
                    string storedProcedureNameReset = $"Proc_storageroommanager_ResetAllStorageRoom";
                    var parameter = new DynamicParameters();
                    parameter.Add("@v_officerid", id);
                    mySqlConnection.Execute(storedProcedureNameReset, parameter, commandType: System.Data.CommandType.StoredProcedure);

                    // chuẩn bị câu lệnh procedure thêm mới kho phòng được cá nhân ql         
                    string storedProcedureName = $"Proc_storageroommanager_InsertOne";

                    foreach (var item in officerDetail.storageRooms)
                    {
                        // chuẩn bị tham số
                        var parameters = new DynamicParameters();
                        parameters.Add("@v_storageroomid", item.StorageRoomID);
                        parameters.Add("@v_officerid", id);
                        parameters.Add("@v_createddate", officer.CreatedDate);
                        parameters.Add("@v_createdby", officer.CreatedBy);
                        parameters.Add("@v_modifieddate", officer.ModifiedDate);
                        parameters.Add("@v_modifiedby", officer.ModifiedBy);

                        // Thực hiện gọi vào DB để chạy câu lệnh Stored procedure
                        mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    }
                }
            }
            return id;
            // chuẩn bị tham số

        }
    }
}
