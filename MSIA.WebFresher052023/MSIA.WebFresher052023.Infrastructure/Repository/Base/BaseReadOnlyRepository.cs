using Dapper;
using Domain.Exceptions;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;
using MSIA.WebFresher052023.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Infrastructure.Repository.Base
{
    public class BaseReadOnlyRepository<TEntity, TModel> : IBaseReadOnlyRepository<TEntity, TModel>
    {
        #region Fields
        protected readonly IUnitOfWork _unitOfWork;
        public virtual string TableName { get; } = typeof(TEntity).Name;
        public virtual string TableId { get; } = typeof(TEntity).Name + "Id";
        #endregion

        #region Constructor
        public BaseReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public virtual async Task<string> GetNewCode()
        {
            var tableName = TableName;
            string procedureName = "Proc_GetNewCode" + tableName;
            var code = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(procedureName, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return code;
        }

        /// <summary>
        /// Lấy thông tin của bản ghi dựa vào id
        /// </summary>
        /// <param name="Id">Id của bản ghi</param>
        /// <returns>Một bản ghi</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Repository: Can not found " + typeof(TEntity).Name + " by this id");
            }
            return entity;
        }

        /// <summary>
        /// Lấy thông tin của bản ghi dựa vào id
        /// </summary>
        /// <param name="Id">Id của bản ghi</param>
        /// <returns>Một bản ghi, có thể null</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<TEntity?> FindAsync(Guid id)
        {
            var tableName = TableName;
            string procedureName = "Proc_Get" + tableName + "ById";
            var paramName = "p_Id";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add(paramName, id);
            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(procedureName, dynamicParams, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return entity;
        }

        /// <summary>
        /// Lấy thông tin của bản ghi dựa vào mã, dùng để hiển thị
        /// </summary>
        /// <param name="code">Mã của bản ghi</param>
        /// <returns>Một bản ghi, có thể null</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<TModel?> FindByCodeAsync(string code)
        {
            var entity = await GetByCodeAsync<TModel>(code);
            return entity;
        }

        /// <summary>
        /// Lấy thông tin của bản ghi dựa vào mã, dùng để check trùng
        /// </summary>
        /// <param name="code">Mã của bản ghi</param>
        /// <returns>Một bản ghi</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<TEntity?> GetByCodeAsync(string code)
        {
            var entity = await GetByCodeAsync<TEntity>(code);
            return entity;
        }

        /// <summary>
        /// Lấy danh sách toàn bộ bản ghi
        /// </summary>
        /// <returns>Toàn bộ bản ghi</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<List<TModel>> GetAllAsync()
        {
            var tableName = TableName;
            string procedureName = "Proc_GetList" + tableName;
            var entities = await _unitOfWork.Connection.QueryAsync<TModel>(procedureName, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return entities.ToList();
        }

        /// <summary>
        /// Lấy danh cách bản ghi có phân trang và tìm kiếm
        /// </summary>
        /// <param name="pageNumber">Sô trang</param>
        /// <param name="pageLimit">Giới hạn bản ghi ở mỗi trang</param>
        /// <param name="filterName">Từ khóa để tìm kiếm</param>
        /// <returns>Danh sách bản ghi sau khi phân trang và tìm kiếm</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<List<TModel>> GetFilterAsync(int? pageNumber, int? pageLimit, string? filterName)
        {
            var tableName = TableName;
            string procedureName = "Proc_Filter" + tableName;
            var parameters = new
            {
                p_PageNumber = pageNumber,
                p_PageLimit = pageLimit,
                p_FilterName = filterName
            };
            var entities = await _unitOfWork.Connection.QueryAsync<TModel>(procedureName, parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return entities.ToList();
        }


        /// <summary>
        /// Hàm chung cho việc lấy object theo mã code
        /// </summary>
        /// <typeparam name="T">Loại đối tượng muốn trả về</typeparam>
        /// <param name="code">Mã code cần kiểm tra</param>
        /// <returns>Một đối tượng</returns>
        /// Created by: ldtuan (20/07/2023)
        public virtual async Task<T?> GetByCodeAsync<T>(string code)
        {
            var tableName = TableName;
            string procedureName = "Proc_Get" + tableName + "ByCode";
            var paramName = "p_Code";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add(paramName, code);
            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<T>(procedureName, dynamicParams, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return entity;
        }

        /// <summary>
        /// Lấy danh sách các bản ghi trong danh sách id
        /// </summary>
        /// <param name="ids">Danh sách id của các bản ghi cần lấy dữ liệu</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ldtuan (24/07/2023)
        public virtual async Task<List<TEntity>> GetListByIdsAsync(List<Guid> ids)
        {
            var tableName = Regex.Replace(TableName, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
            var sql = $"select * from view_{tableName} where {TableId} in @listIds;";
            var param = new DynamicParameters();
            param.Add("listIds", ids);
            var listEntities = await _unitOfWork.Connection.QueryAsync<TEntity>(sql, param, transaction: _unitOfWork.Transaction);
            return listEntities.ToList();
        }

        /// <summary>
        /// Lấy tổng số bản ghi
        /// </summary>
        /// <returns>tổng số bản ghi dạng int</returns>
        /// Created by: ldtuan (28/07/2023)
        public virtual async Task<int> GetCountAsync()
        {
            var tableName = Regex.Replace(TableName, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
            var sql = $"select count(*) from view_{tableName}";
            var count = await _unitOfWork.Connection.ExecuteScalarAsync<int>(sql, transaction: _unitOfWork.Transaction);
            return count;
        }
        #endregion
    }
}
