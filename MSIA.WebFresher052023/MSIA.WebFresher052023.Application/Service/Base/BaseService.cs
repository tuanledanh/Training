using Application.DTO.Depart;
using AutoMapper;
using Domain.Entity;
using Domain.Exceptions;
using MSIA.WebFresher052023.Application.Interface.Base;
using MSIA.WebFresher052023.Domain.Entity.Base;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Manager.Base;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;
using MSIA.WebFresher052023.Domain.Model.Base;

namespace MSIA.WebFresher052023.Application.Service.Base
{
    public abstract class BaseService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyService<TEntity, TModel, TEntityDto,
        TEntityCreateDto, TEntityUpdateDto>,
        IBaseService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> where TModel : IHasKeyModel
    {
        #region Fields
        protected readonly IBaseRepository<TEntity, TModel> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<TEntity, TModel> baseRepository, IMapper mapper, IBaseManager<TEntity, TModel> manager, IUnitOfWork unitOfWork) : base(baseRepository, mapper, manager)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Xử lý thêm mới một bản ghi
        /// </summary>
        /// <param name="entityCreateDto">Thông tin của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> InsertAsync(TEntityCreateDto entityCreateDto)
        {
            var model = _mapper.Map<TModel>(entityCreateDto);
            await _manager.CheckDuplicateCode(model.GetKey());
            var entity = _mapper.Map<TEntity>(entityCreateDto);
            bool result = await _baseRepository.InsertAsync(entity);
            if (!result)
            {
                throw new Exception("Service: Không thể thêm mới " + typeof(TEntity).Name);
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Xử lý cập nhật một bản ghi đã tồn tại
        /// </summary>
        /// <param name="entityUpdateDto">Thông tin của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto)
        {
            var oldEntity = await _baseRepository.GetAsync(id);
            var oldModel = _mapper.Map<TModel>(oldEntity);
            var model = _mapper.Map<TModel>(entityUpdateDto);
            await _manager.CheckDuplicateCode(model.GetKey(), oldModel.GetKey());
            var entity = _mapper.Map(entityUpdateDto, oldEntity);
            bool result = await _baseRepository.UpdateAsync(entity);
            if (!result)
            {
                throw new Exception("Service: Không thể cập nhật " + typeof(TEntity).Name);
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Xử lý xóa một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _baseRepository.GetAsync(id);
            // GetAsync có throw exception nên k cần check lại
            bool result = await _baseRepository.DeleteAsync(entity);
            return result;
        }

        /// <summary>
        /// Xử lý xóa một bản ghi
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task DeleteManyAsync(List<Guid> ids)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entities = await _baseRepository.GetListByIdsAsync(ids);
                await _baseRepository.DeleteManyAsync(entities);
                if (ids.Count == 0)
                {
                    throw new Exception("Không được truyền danh sách rỗng");
                }
                if (entities.Count < ids.Count)
                {
                    throw new Exception("Không thể xóa");
                }
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        #endregion
    }
}
