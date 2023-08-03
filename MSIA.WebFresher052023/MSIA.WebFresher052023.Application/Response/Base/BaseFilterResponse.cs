using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Application.Response.Base
{
    /// <summary>
    /// Class để format dữ liệu trả về khi filter
    /// </summary>
    /// Created by: ldtuan (28/07/2023)
    public class BaseFilterResponse<TEntityDto>
    {
        public BaseFilterResponse(int? totalPages, int? totalRecords, List<TEntityDto>? data)
        {
            TotalPages = totalPages;
            TotalRecords = totalRecords;
            Data = data;
        }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        /// Created by: ldtuan (28/07/2023)
        public int? TotalPages { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// Created by: ldtuan (28/07/2023)
        public int? TotalRecords { get; set; }

        /// <summary>
        /// Tất cả dữ liệu trả về
        /// </summary>
        /// Created by: ldtuan (28/07/2023)
        public List<TEntityDto>? Data { get; set; }
    }
}
