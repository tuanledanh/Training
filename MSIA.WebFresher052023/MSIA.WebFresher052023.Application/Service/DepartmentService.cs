using Application.DTO.Depart;
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
    public class DepartmentService : BaseService<Department, DepartmentModel, DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>, IDepartmentService
    {
        #region Fields
        private readonly IDepartmentManager _departmentManager; 
        #endregion

        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IDepartmentManager departmentManager, IUnitOfWork unitOfWork) : base(departmentRepository, mapper, departmentManager, unitOfWork)
        {
            _departmentManager = departmentManager;
        }
        #endregion
    }
}
