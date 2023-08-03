using System.Text.Json;

namespace Domain.Exceptions
{
    public class BaseException
    {
        #region Properties
        /// <summary>
        /// Mã lỗi
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public int ErrorCode { get; set; }

        /// <summary>
        /// Thông báo lỗi dành cho dev
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string? DevMessage { get; set; }

        /// <summary>
        /// Thông báo lỗi dành cho người dùng
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string? UserMessage { get; set; }

        /// <summary>
        /// Mã theo dõi (Lưu trữ mã duy nhất để theo dõi các yêu cầu và lỗi liên quan trong hệ thống)
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string? TraceId { get; set; }

        /// <summary>
        /// Thông tin thêm (Lưu trữ các thông tin bổ sung liên quan đến lỗi, ví dụ như URL hướng dẫn sửa lỗi, tài liệu hỗ trợ)
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Các lỗi khác
        /// </summary>
        /// Created by: ldtuan (17/07/2023)
        public object? Errors { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Chuyển đổi đối tượng thành chuỗi JSON
        /// </summary>
        /// <returns>Chuỗi JSON biểu diễn đối tượng</returns>
        /// Created by: ldtuan (17/07/2023)
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        } 
        #endregion
    }
}
