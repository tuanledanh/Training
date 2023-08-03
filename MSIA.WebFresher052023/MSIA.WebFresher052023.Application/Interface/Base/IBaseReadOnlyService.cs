using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Application.Interface.Base
{
    public interface IBaseReadOnlyService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        #region Methods
        /// <summary>
        /// Hàm tự sinh 1 mã code mới dựa trên mã code cũ
        /// </summary>
        /// <returns>Mã Code</returns>
        /// Created by: ldtuan (26/07/2023)
        Task<string> GetNewCode();

        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="code">Mã code của bản ghi</param>
        /// <returns>TEntityDto</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<TEntityDto> GetAsync(string code);

        /// <summary>
        /// Hàm lấy danh sách toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách TEntityDto</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<List<TEntityDto>> GetAllAsync(int? pageNumber, int? pageLimit, string filterName);

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns>tổng số bản ghi dạng int</returns>
        /// Created by: ldtuan (28/07/2023)
        Task<int> GetCountAsync();
        #endregion
    }
}
