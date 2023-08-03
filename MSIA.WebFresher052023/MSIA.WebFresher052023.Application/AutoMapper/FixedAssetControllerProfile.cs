using Application.DTO.FixedAssetCategoryy;
using AutoMapper;
using Domain.Entity;
using Domain.Model;

namespace Application.AutoMapper
{
    public class FixedAssetControllerProfile : Profile
    {
        public FixedAssetControllerProfile()
        {
            CreateMap<FixedAssetCategory, FixedAssetCategoryDto>();
            CreateMap<FixedAssetCategory, FixedAssetCategoryModel>();
            CreateMap<FixedAssetCategoryModel, FixedAssetCategoryDto>();
            CreateMap<FixedAssetCategoryCreateDto, FixedAssetCategory>();
            CreateMap<FixedAssetCategoryUpdateDto, FixedAssetCategory>();
            CreateMap<FixedAssetCategoryCreateDto, FixedAssetCategoryModel>();
            CreateMap<FixedAssetCategoryUpdateDto, FixedAssetCategoryModel>();
        }
    }
}
