namespace Application.DTO.Depart
{
    public class DepartmentDto
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
        #endregion
    }
}