using Application.DTO.Depart;
using Application.Interface;
using Domain.Entity;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using MSIA.WebFresher052023.API.Controllers.Base;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : BaseSearchPagingController<Department, DepartmentModel, DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>
    {
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
        }
    }
}
