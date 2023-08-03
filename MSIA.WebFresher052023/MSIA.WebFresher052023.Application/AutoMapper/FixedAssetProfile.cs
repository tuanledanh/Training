using Application.DTO.FixedAssett;
using AutoMapper;
using Domain.Entity;
using Domain.Model;

namespace Application.AutoMapper
{
    public class FixedAssetProfile : Profile
    {
        public FixedAssetProfile()
        {
            CreateMap<FixedAsset, FixedAssetDto>();
            CreateMap<FixedAsset, FixedAssetModel>();
            CreateMap<FixedAssetModel, FixedAssetDto>();
            CreateMap<FixedAssetCreateDto, FixedAsset>();
            CreateMap<FixedAssetUpdateDto, FixedAsset>();
            CreateMap<FixedAssetCreateDto, FixedAssetModel>();
            CreateMap<FixedAssetUpdateDto, FixedAssetModel>();
        }
    }
}
