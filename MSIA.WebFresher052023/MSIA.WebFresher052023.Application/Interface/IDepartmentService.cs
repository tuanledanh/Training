using Application.DTO.Depart;
using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Application.Interface.Base;

namespace Application.Interface
{
    public interface IDepartmentService : IBaseService<Department, DepartmentModel, DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>
    {
    }
}
