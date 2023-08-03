namespace MSIA.WebFresher052023.Domain.Interface.Manager.Base
{
    public interface IBaseManager<TEntity, TModel>
    {
        #region Methods
        /// <summary>
        /// Gửi thông báo lỗi trong trường hợp trùng mã code
        /// </summary>
        /// <param name="code">Mã code cần kiểm tra</param>
        /// <returns>Nếu mã code tồn tại thì thông báo lỗi, còn không thì không làm gì</returns>
        /// Created by: ldtuan (19/07/2023)
        Task CheckDuplicateCode(string code, string? oldCode = null);
        #endregion
    }
}
