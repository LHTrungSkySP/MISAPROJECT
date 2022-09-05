using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities
{
    public static class EntityUnitities
    {
        /// <summary>
        /// Lấy tên bảng của entity
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của entity</typeparam>
        /// <returns>Tên bảng</returns>
        /// Created by: LHTrung

        public static string GetNameTable<T>()
        {
            string tableName = typeof(T).Name;
            var tableAttributes = typeof(T).GetTypeInfo().GetCustomAttributes<TableAttribute>();
            if (tableAttributes.Count() > 0)
            {
                tableName = tableAttributes.First().Name;
            }
            return tableName;
        }
    }
}
