﻿namespace MISA.WEB07.LHTRUNG.GD.BUS.Manager.BaseManager
{
    public interface IBaseManagerBUS<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi liên quan đến officerID trong barng T
        /// </summary>
        /// <returns>tất cả bản ghi liên quan đến officerID trong barng T</returns>
        /// Created by:  LHTrung
        public IEnumerable<dynamic> GetAllRecords(Guid id);
    }
}