using MSIA.WebFresher052023.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class FixedAssetCategoryModel : IHasKeyModel
    {
        #region Fields
        /// <summary>
        /// Id của loại tài sản
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
        /// Tỷ lệ hao mòn (%)
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public float? DepreciationRate { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public int? LifeTime { get; set; }

        /// <summary>
        /// Nhận được giá trị của thuộc tính khóa trong một đối tượng cụ thể 
        /// mà không cần truy cập trực tiếp vào thuộc tính đó, TEntity có thể xài để lấy đc id
        /// </summary>
        /// <returns>Id của tài sản</returns>
        /// Created by: ldtuan (19/07/2023)
        public string GetKey()
        {
            return FixedAssetCategoryCode;
        }
        #endregion
    }
}
