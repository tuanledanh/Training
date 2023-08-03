namespace MSIA.WebFresher052023.Domain.Entity.Base
{
    public abstract class BaseEntity
    {
        #region Fields
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created by: ldtuan (12/07/2023)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        /// Created by: ldtuan (12/07/2023)
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        /// Created by: ldtuan (12/07/2023)
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        /// Created by: ldtuan (12/07/2023)
        public string? ModifiedBy { get; set; }
        #endregion
    }
}
