using System.Data.Common;

namespace MSIA.WebFresher052023.Domain.Interface.Repository.Base
{
    public interface IBaseRepository<TEntity, TModel> : IBaseReadOnlyRepository<TEntity, TModel>
    {
        #region Methods
        /// <summary>
        /// Hàm tạo mới 1 bản ghi có sẵn
        /// </summary>
        /// <param name="entity">Thông tin mới tạo bản ghi</param>
        /// <returns>True hoặc false tương ứng với tạo thành công hay thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<bool> InsertAsync(TEntity entity);

        /// <summary>
        /// Hàm cập nhật 1 bản ghi có sẵn
        /// </summary>
        /// <param name="entity">Thông tin mới muốn cập nhật vào bản ghi cũ</param>
        /// <returns>True hoặc false tương ứng với cập nhật thành công hay thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa 1 bản ghi có sẵn
        /// </summary>
        /// <param name="entity">Bản ghi cần xóa</param>
        /// <returns>True hoặc false tương ứng với xóa thành công hay thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa danh sách bản ghi
        /// </summary>
        /// <param name="code">Bản ghi cần xóa</param>
        /// <returns>True hoặc false tương ứng với xóa thành công hay thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        Task<bool> DeleteManyAsync(List<TEntity> entities);
        #endregion
    }
}
