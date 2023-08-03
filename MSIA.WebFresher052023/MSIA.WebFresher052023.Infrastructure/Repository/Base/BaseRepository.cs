using Dapper;
using Domain.Entity;
using Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using MSIA.WebFresher052023.Domain.Entity.Base;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace MSIA.WebFresher052023.Infrastructure.Repository.Base
{
    //where TEntity : IHasKey tức là đã check cái entity này có key rồi, nên không cần check xem có key không để ném ra exception ở param.Add("id", entity.GetKey());
    // Kiểu nếu entity không implement IHasKey thì không gọi được entity.GetKey(), mà k gọi được thì k cần ném ra exception
    public abstract class BaseRepository<TEntity, TModel> : BaseReadOnlyRepository<TEntity, TModel>, IBaseRepository<TEntity, TModel> where TEntity : IHasKey
    {
        #region Constructor
        public BaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Thông tin của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            var param = MapEntityToParams(entity);
            var sql = $"Proc_Insert{TableName}";
            var affectedRow = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return affectedRow > 0;
        }

        /// <summary>
        /// Cập nhật thông tin của bản ghi
        /// </summary>
        /// <param name="entity">Thông tin mới của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var param = MapEntityToParams(entity);
            var sql = $"Proc_Update{TableName}";
            var affectedRow = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return affectedRow > 0;
        }

        /// <summary>
        /// Xóa thông tin một bản ghi
        /// </summary>
        /// <param name="Entity">Bản ghi cần xóa</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            // Do việc xóa liên quan đến khóa ngoại nên để hàm này ở từng repo riêng
            // Nếu hàm này xài chung thì cách để lấy id của entity là xài IHasKey
            //var param = new DynamicParameters();
            //param.Add("id", entity.GetKey());
            string procedureName = $"Proc_Delete{TableName}ById";
            var paramName = "p_Id";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add(paramName, entity.GetKey());
            var affectedRow = await _unitOfWork.Connection.ExecuteAsync(procedureName, dynamicParams, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return affectedRow > 0;
        }

        /// <summary>
        /// Xóa thông tin nhiều bản ghi
        /// </summary>
        /// <param name="entities">Các bản ghi cần xóa</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public virtual async Task<bool> DeleteManyAsync(List<TEntity> entities)
        {
            var tableName = Regex.Replace(TableName, "([a-z0-9])([A-Z])", "$1_$2").ToLower();
            var tableId = tableName + "_id";
            var sql = $"delete from {tableName} where {tableId} in @listIds;";
            var param = new DynamicParameters();
            param.Add("listIds", entities.Select(x => x.GetKey()));
            var affectedRow = await _unitOfWork.Connection.ExecuteAsync(sql, param, transaction: _unitOfWork.Transaction);
            return affectedRow > 0;
        }

        /// <summary>
        /// Map các thuộc tính của đối tượng sang param để truyền vào procedure
        /// </summary>
        /// <param name="entity">Thông tin của đối tượng</param>
        /// <returns>Param chứa danh sách tham số truy vấn</returns>
        /// Created by: ldtuan (20/07/2023)
        private DynamicParameters MapEntityToParams(TEntity entity)
        {
            var param = new DynamicParameters();
            var properties = typeof(TEntity).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                param.Add($"p_{property.Name}", value);
            }
            return param;
        }
        #endregion
    }
}
