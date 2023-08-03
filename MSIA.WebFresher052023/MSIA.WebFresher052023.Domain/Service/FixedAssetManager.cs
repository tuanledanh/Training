using Domain.Entity;
using Domain.Model;
using MSIA.WebFresher052023.Domain.Interface.Manager;
using MSIA.WebFresher052023.Domain.Interface.Repository;
using MSIA.WebFresher052023.Domain.Interface.Repository.Base;

namespace MSIA.WebFresher052023.Domain.Service
{
    public class FixedAssetManager : BaseManager<FixedAsset, FixedAssetModel>, IFixedAssetManager
    {
        public FixedAssetManager(IFixedAssetRepository fixedAssetRepository) : base(fixedAssetRepository)
        {
        }
    }
}
