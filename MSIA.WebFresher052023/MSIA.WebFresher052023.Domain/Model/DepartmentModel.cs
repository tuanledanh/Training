using MSIA.WebFresher052023.Domain.Model.Base;

namespace Domain.Model
{
    public class DepartmentModel : IHasKeyModel
    {
        #region Fields
        /// <summary>
        /// Id của phòng ban
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã code của phòng ban
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string DepartmentName { get; set; }

        /// <summary>
        /// Nhận được giá trị của thuộc tính khóa trong một đối tượng cụ thể 
        /// mà không cần truy cập trực tiếp vào thuộc tính đó, TEntity có thể xài để lấy đc id
        /// </summary>
        /// <returns>Id của tài sản</returns>
        /// Created by: ldtuan (19/07/2023)
        public string GetKey()
        {
            return DepartmentCode;
        }
        #endregion
    }
}
