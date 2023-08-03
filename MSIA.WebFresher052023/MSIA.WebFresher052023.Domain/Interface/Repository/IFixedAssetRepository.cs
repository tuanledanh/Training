using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;

namespace MSIA.WebFresher052023.Domain.Interface.Repository
{
    public interface IFixedAssetRepository : IBaseRepository<FixedAsset, FixedAssetModel>
    {
        /// <summary>
        /// Lấy danh sách tài sản, có phân trang, tìm kiếm theo code và lọc theo phòng ban, loại tài sản
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageLimit">Số lượng tối đa bản ghi mỗi trang</param>
        /// <param name="filterName">Mã code dùng để search</param>
        /// <param name="departmentId">Id của phòng ban, dùng để lọc</param>
        /// <param name="assetTypeId">Id của loại tài sản, dùng để lọc</param>
        /// <returns>Danh sách loại tài sản đáp ứng đúng các điều kiện trên</returns>
        /// Created by: ldtuan (23/07/2023)
        Task<List<FixedAssetModel>> GetFilterSearchAsync(int? pageNumber, int? pageLimit, string? filterName, string departmentId, string assetTypeId);

        /// <summary>
        /// Lấy tổng số bản ghi thỏa mãn điều kiện lọc
        /// </summary>
        /// <param name="filterName">Mã code dùng để search</param>
        /// <param name="departmentId">Id của phòng ban, dùng để lọc</param>
        /// <param name="assetTypeId">Id của loại tài sản, dùng để lọc</param>
        /// <returns>Tổng bản ghi</returns>
        /// Created by: ldtuan (28/07/2023)
        public Task<int> GetCountFilterAsync(string? filterName, string departmentId, string assetTypeId);
    }
}
