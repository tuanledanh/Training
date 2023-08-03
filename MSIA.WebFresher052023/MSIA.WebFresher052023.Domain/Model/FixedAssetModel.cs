using MSIA.WebFresher052023.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class FixedAssetModel : IHasKeyModel
    {
        #region Fields
        /// <summary>
        /// Id của tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public Guid FixedAssetId { get; set; }
        /// <summary>
        /// Mã code của tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string FixedAssetCode { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string FixedAssetName { get; set; }
        /// <summary>
        /// Số lượng tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public int Quantity { get; set; }
        /// <summary>
        /// Giá tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public decimal Cost { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public int LifeTime { get; set; }
        /// <summary>
        /// Năm theo dõi
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public int TrackedYear { get; set; }
        /// <summary>
        /// Ngày mua hàng
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Ngày bắt đầu sử dụng
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public DateTime StartUsingDate { get; set; }
        /// <summary>
        /// Khóa chính của bảng loại tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public Guid FixedAssetCategoryId { get; set; }
        /// <summary>
        /// Mã code của loại tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string FixedAssetCategoryCode { get; set; }
        /// <summary>
        /// Tên của loại tài sản
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string FixedAssetCategoryName { get; set; }
        /// <summary>
        /// Khóa chính của bảng phòng ban
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
            return FixedAssetCode;
        }
        #endregion
    }
}
