using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;

namespace MSIA.WebFresher052023.Domain.Interface.Repository
{
    public interface IDepartmentRepository : IBaseRepository<Department, DepartmentModel>
    {
    }
}
