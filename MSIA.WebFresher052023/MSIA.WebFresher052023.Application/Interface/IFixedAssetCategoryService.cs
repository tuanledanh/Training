using Application.DTO.FixedAssetCategoryy;
using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Application.Interface.Base;

namespace Application.Interface
{
    public interface IFixedAssetCategoryService : IBaseService<FixedAssetCategory, FixedAssetCategoryModel, FixedAssetCategoryDto, FixedAssetCategoryCreateDto, FixedAssetCategoryUpdateDto>
    {
    }
}
