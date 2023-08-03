using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Domain.Interface.Repository.Base
{
    public interface IBaseReadOnlyRepository<TEntity, TModel>
    {
        #region Methods
        /// <summary>
        /// Hàm tự sinh mã code mới dựa trên mã code cũ
        /// </summary>
        /// <returns>Mã code</returns>
        /// Created by: ldtuan (26/07/2023)
        Task<string> GetNewCode();

        /// <summary>
        /// Hàm lấy 1 bản ghi dựa vào id
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>TEntity</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Hàm lấy 1 bản ghi dựa vào id
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>TEntity có thể null</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<TEntity?> FindAsync(Guid id);

        /// <summary>
        /// Hàm lấy 1 bản ghi dựa vào mã code, dùng để hiển thị
        /// </summary>
        /// <param name="code">Mã code của bản ghi</param>
        /// <returns>TModel có thể null</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<TModel?> FindByCodeAsync(string code);

        /// <summary>
        /// Hàm lấy 1 bản ghi dựa vào mã code, dùng để check mã trùng
        /// </summary>
        /// <param name="code">Mã code của bản ghi</param>
        /// <returns>TEntity</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<TEntity?> GetByCodeAsync(string code);

        /// <summary>
        /// Hàm lấy danh sách bản ghi, có phân trang và lọc
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageLimit">Số bản ghi tối đa</param>
        /// <param name="filterName">Tên của bản ghi để thực hiện lọc</param>
        /// <returns>Danh sách TEntity</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<List<TModel>> GetFilterAsync(int? pageNumber, int? pageLimit, string? filterName);

        /// <summary>
        /// Hàm lấy danh sách toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách TEntity</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<List<TModel>> GetAllAsync();

        /// <summary>
        /// Lấy danh sách các bản ghi trong danh sách id
        /// </summary>
        /// <param name="ids">Danh sách id của các bản ghi cần lấy dữ liệu</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ldtuan (24/07/2023)
        Task<List<TEntity>> GetListByIdsAsync(List<Guid> ids);

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns>tổng số bản ghi dạng int</returns>
        /// Created by: ldtuan (28/07/2023)
        Task<int> GetCountAsync();
        #endregion
    }
}
