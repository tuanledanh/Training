using Application.DTO.Depart;
using AutoMapper;
using Domain.Entity;
using Domain.Model;

namespace Application.AutoMapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentModel>();
            CreateMap<DepartmentModel, DepartmentDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<DepartmentCreateDto, DepartmentModel>();
            CreateMap<DepartmentUpdateDto, DepartmentModel>();
        }
    }
}
