using System.Data.Common;
namespace MSIA.WebFresher052023.Domain.Interface
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        #region Fields
        DbConnection Connection { get; }
        DbTransaction? Transaction { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Bắt đầu một giao dịch mới
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        void BeginTransaction();

        /// <summary>
        /// Bắt đầu một giao dịch mới (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        Task BeginTransactionAsync();

        /// <summary>
        /// Lưu các thay đổi trong giao dịch và kết thúc
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        void Commit();

        /// <summary>
        /// Lưu các thay đổi trong giao dịch và kết thúc (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        Task CommitAsync();

        /// <summary>
        /// Hoàn tác các thay đổi trong giao dịch và kết thúc
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        void Rollback();

        /// <summary>
        /// Hoàn tác các thay đổi trong giao dịch và kết thúc (phiên bản bất đồng bộ)
        /// </summary>
        /// Created by: ldtuan (19/07/2023)
        Task RollbackAsync(); 
        #endregion
    }
}
