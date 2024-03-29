﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB07.LHTRUNG.GD.DTO
{
    [Table("StorageRoomManager")]
    public class StorageRoomManager
    {
        // ID quản lý phòng kho
        [Key]
        public Guid StorageRoomManagerID { get; set; }

        // ID phòng kho
        public Guid StorageRoomID { get; set; }

        // ID nhân viên
        public Guid OfficerID { get; set; }

        // ngày tạo 
        public DateTime? CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        // ngày sửa dổi
        public DateTime? ModifiedDate { get; set; }

        // người sửa đổi
        public string? ModifiedBy { get; set; }

    }
}
