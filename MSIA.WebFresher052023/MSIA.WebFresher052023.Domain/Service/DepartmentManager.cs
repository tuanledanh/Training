using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Domain.Interface.Manager;
using MSIA.WebFresher052023.Domain.Interface.Repository;

namespace MSIA.WebFresher052023.Domain.Service
{
    public class DepartmentManager : BaseManager<Department, DepartmentModel>, IDepartmentManager
    {
        public DepartmentManager(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
    }
}
