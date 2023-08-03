using AutoMapper;
using MSIA.WebFresher052023.Application.Interface.Base;
using MSIA.WebFresher052023.Domain.Interface.Manager.Base;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;
using MSIA.WebFresher052023.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Application.Service.Base
{
    public abstract class BaseReadOnlyService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IBaseReadOnlyService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> where TModel : IHasKeyModel
    {
        #region Fields
        protected readonly IBaseReadOnlyRepository<TEntity, TModel> _baseReadOnlyRepository;
        protected readonly IMapper _mapper;
        protected readonly IBaseManager<TEntity, TModel> _manager;
        #endregion

        #region Constructor
        public BaseReadOnlyService(IBaseReadOnlyRepository<TEntity, TModel> baseReadOnlyRepository, IMapper mapper, IBaseManager<TEntity, TModel> manager)
        {
            _baseReadOnlyRepository = baseReadOnlyRepository;
            _mapper = mapper;
            _manager = manager;
        }
        #endregion

        #region Methods

        public virtual async Task<string> GetNewCode()
        {
            var code = await _baseReadOnlyRepository.GetNewCode();
            return code;
        }

        /// <summary>
        /// Gọi đến hàm GetAsync ở repository để xử lý lấy thông tin của bản ghi
        /// </summary>
        /// <param name="code">Mã code của bản ghi</param>
        /// <returns>Một bản ghi</returns>
        /// Created by: ldtuan (12/07/2023)
        public virtual async Task<TEntityDto?> GetAsync(string code)
        {
            var entity = await _baseReadOnlyRepository.FindByCodeAsync(code);
            var entityDto = _mapper.Map<TEntityDto>(entity);
            return entityDto;
        }

        /// <summary>
        /// Gọi đến hàm GetAllAsync ở repository để xử lý lấy danh sách toàn bộ bản ghi
        /// </summary>
        /// <returns>Toàn bộ bản ghi</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<List<TEntityDto>> GetAllAsync(int? pageNumber, int? pageLimit, string filterName)
        {
            List<TModel> entities;
            if (pageNumber == null && pageLimit == null)
            {
                entities = await _baseReadOnlyRepository.GetAllAsync();
            }
            else
            {
                if (filterName == null)
                {
                    filterName = "";
                }
                entities = await _baseReadOnlyRepository.GetFilterAsync(pageNumber, pageLimit, filterName);
            }
            List<TEntityDto> entitiesDto = new List<TEntityDto>();
            foreach (var entity in entities)
            {
                entitiesDto.Add(_mapper.Map<TEntityDto>(entity));
            }
            return entitiesDto;
        }

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns>tổng số bản ghi dạng int</returns>
        /// Created by: ldtuan (28/07/2023)
        public virtual async Task<int> GetCountAsync()
        {
            var count = await _baseReadOnlyRepository.GetCountAsync();
            return count;
        }
        #endregion
    }
}
