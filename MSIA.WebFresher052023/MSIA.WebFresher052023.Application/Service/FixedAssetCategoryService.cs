using Application.DTO.FixedAssetCategoryy;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Application.Service.Base;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Manager;
using MSIA.WebFresher052023.Domain.Interface.Repository;

namespace Application.Service
{
    public class FixedAssetCategoryService : BaseService<FixedAssetCategory, FixedAssetCategoryModel, FixedAssetCategoryDto, FixedAssetCategoryCreateDto, FixedAssetCategoryUpdateDto>, IFixedAssetCategoryService
    {
        #region Fields
        private readonly IFixedAssetCategoryManager _fixedAssetCategoryManager; 
        #endregion

        #region Constructor
        public FixedAssetCategoryService(IFixedAssetCategoryRepository fixedAssetCategoryRepository, IMapper mapper, IFixedAssetCategoryManager fixedAssetCategoryManager, IUnitOfWork unitOfWork) : base(fixedAssetCategoryRepository, mapper, fixedAssetCategoryManager, unitOfWork)
        {
            _fixedAssetCategoryManager = fixedAssetCategoryManager;
        }
        #endregion
    }
}
