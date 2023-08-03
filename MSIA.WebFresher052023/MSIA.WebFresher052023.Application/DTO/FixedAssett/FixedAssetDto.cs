using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.FixedAssett
{
    public class FixedAssetDto
    {
        #region Fields
        /// <summary>
        /// Id của tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public Guid FixedAssetId { get; set; }
        /// <summary>
        /// Mã code của tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public string FixedAssetCode { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public string FixedAssetName { get; set; }
        /// <summary>
        /// Id tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public string DepartmentName { get; set; }
        /// <summary>
        /// Id loại tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public Guid FixedAssetCategoryId { get; set; }
        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public string FixedAssetCategoryCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public string FixedAssetCategoryName { get; set; }
        /// <summary>
        /// Ngày mua
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Ngày bắt đầu sử dụng
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public DateTime StartUsingDate { get; set; }
        /// <summary>
        /// Nguyên giá
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public decimal Cost { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public int Quantity { get; set; }
        /// <summary>
        /// Năm bắt đầu theo dõi tài sản trên phần mềm
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public int TrackedYear { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public int LifeTime { get; set; }
        /// <summary>
        /// Năm sử dụng
        /// </summary>
        /// Created by: ldtuan (31/07/2023)
        public int ProductionYear { get; set; }
        #endregion
    }
}
