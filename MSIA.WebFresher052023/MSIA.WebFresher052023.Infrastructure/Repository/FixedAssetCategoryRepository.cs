using Dapper;
using Domain.Entity;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Repository;
using MSIA.WebFresher052023.Infrastructure.Repository.Base;
using MSIA.WebFresher052023.Infrastructure.UnitOfWorks;
using System.Data;

namespace Infrastructure.Repository
{
    public class FixedAssetCategoryRepository : BaseRepository<FixedAssetCategory, FixedAssetCategoryModel>, IFixedAssetCategoryRepository
    {
        #region Constructor
        public FixedAssetCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
    }
}
