using Domain.Exceptions;
using MSIA.WebFresher052023.Domain.Interface.Manager.Base;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;
using MSIA.WebFresher052023.Domain.Model.Base;

namespace MSIA.WebFresher052023.Domain.Service
{
    public class BaseManager<TEntity, TModel> : IBaseManager<TEntity, TModel> where TModel : IHasKeyModel
    {
        #region Fields
        protected readonly IBaseRepository<TEntity, TModel> _baseRepository;

        #endregion

        #region Constructor
        public BaseManager(IBaseRepository<TEntity, TModel> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gửi thông báo lỗi trong trường hợp trùng mã code
        /// </summary>
        /// <param name="code">Mã code cần kiểm tra</param>
        /// <returns>Nếu mã code tồn tại thì thông báo lỗi, còn không thì không làm gì</returns>
        /// Created by: ldtuan (19/07/2023)
        public async Task CheckDuplicateCode(string code, string? oldCode = null)
        {
            var existEntity = await _baseRepository.FindByCodeAsync(code);
            if (existEntity != null && existEntity.GetKey() != oldCode)
            {
                throw new ConflictException();
            }
        }
        #endregion
    }
}
