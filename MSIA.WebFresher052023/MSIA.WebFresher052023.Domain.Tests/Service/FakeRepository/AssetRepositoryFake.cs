//using Domain.Entity;
//using Domain.Model;
//using MSIA.WebFresher052023.Domain.Interface.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MSIA.WebFresher052023.Domain.Tests
//{
//    public class AssetRepositoryFake : IAssetRepository
//    {
//        public int TotalCall { get; set; }

//        public Task<bool> DeleteAsync(Asset entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Asset?> FindAsync(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<AssetModel?> FindByCodeAsync(string code)
//        {
//            TotalCall++;
//            return Task.FromResult<AssetModel?>(default);
//        }

//        public Task<List<AssetModel>> GetAllAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Asset> GetAsync(Guid id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Asset?> GetByCodeAsync(string code)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<AssetModel>> GetFilterAsync(int? pageNumber, int? pageLimit, string? filterName)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<AssetModel>> GetFilterSearchAsync(int? pageNumber, int? pageLimit, string? filterName, string departmentId, string assetTypeId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> InsertAsync(Asset entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> UpdateAsync(Asset entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
