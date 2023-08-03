using Microsoft.AspNetCore.Mvc;
using MSIA.WebFresher052023.Application.Interface.Base;
using MSIA.WebFresher052023.Application.Service.Base;
using static Dapper.SqlMapper;

namespace MSIA.WebFresher052023.API.Controllers.Base
{
    public class BaseSearchPagingController<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyController<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        public BaseSearchPagingController(IBaseService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService) : base(baseService)
        {
        }

        #region Methods
        /// <summary>
        /// Api lấy danh sách bản ghi, có phân trang và lọc
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageLimit">Số bản ghi tối đa</param>
        /// <param name="filterName">Tên của bản ghi để thực hiện lọc</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ldtuan (18/07/2023)
        [HttpGet]
        public virtual async Task<IActionResult> GetList([FromQuery] int? pageNumber, [FromQuery] int? pageLimit, [FromQuery] string? filterName)
        {
            var assetList = await _baseService.GetAllAsync(pageNumber, pageLimit, filterName);
            return StatusCode(StatusCodes.Status200OK, assetList);
        } 
        #endregion
    }
}
