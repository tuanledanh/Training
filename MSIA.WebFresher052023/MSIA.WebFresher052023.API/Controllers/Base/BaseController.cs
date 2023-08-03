using Microsoft.AspNetCore.Mvc;
using MSIA.WebFresher052023.Application.Interface.Base;
using MSIA.WebFresher052023.Application.Service.Base;
using static Dapper.SqlMapper;

namespace MSIA.WebFresher052023.API.Controllers.Base
{
    public class BaseController<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyController<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        #region Constructor
        public BaseController(IBaseService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService) : base(baseService)
        {
        } 
        #endregion
    }
}
