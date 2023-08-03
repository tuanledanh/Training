using Application.Interface;
using Application.Service;
using AutoMapper;
using Domain.Entity;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Manager;
using MSIA.WebFresher052023.Domain.Interface.Repository;

namespace MSIA.WebFresher052023.Application.Tests.Service
{
    [TestFixture]
    public class AssetServiceTests
    {
        #region Fields
        public IFixedAssetRepository assetRepository { get; set; }
        public IDepartmentRepository departmentRepository { get; set; }
        public IAssetTypeRepository assetTypeRepository { get; set; }
        public IUnitOfWork unitOfWork { get; set; }
        public IFixedAssetManager assetManager { get; set; }
        public FixedAssetService assetService { get; set; }
        public IMapper mapper { get; set; }
        #endregion

        #region Constructor
        [SetUp]
        public void SetUp()
        {
            assetRepository = Substitute.For<IFixedAssetRepository>();
            departmentRepository = Substitute.For<IDepartmentRepository>();
            assetTypeRepository = Substitute.For<IAssetTypeRepository>();
            mapper = Substitute.For<IMapper>();
            assetManager = Substitute.For<IFixedAssetManager>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            assetService = new AssetService(assetRepository, mapper, departmentRepository, assetTypeRepository, assetManager, unitOfWork);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Test case cho việc xóa nhiều bản ghi trong danh sách id truyền về
        /// Trường hợp này danh sách rỗng, nó sẽ ném ra một ngoại lệ với thông báo "Không được truyền danh sách rỗng"
        /// </summary>
        /// Created by: ldtuan (24/07/2023)
        [Test]
        public async Task DeleteManyAsync_EmptyList_ThrowException()
        {
            // Arrage
            var ids = new List<Guid>();
            var expectedMessage = "Không được truyền danh sách rỗng";

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await assetService.DeleteManyAsync(ids));
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
            await unitOfWork.Received(1).BeginTransactionAsync();
            await unitOfWork.Received(1).RollbackAsync();
        }

        /// <summary>
        /// Test case cho việc xóa nhiều bản ghi trong danh sách truyền về
        /// Trường hợp này có 10 id nhưng chỉ 9 asset, dẫn đến số lượng không đều và sẽ ném ra thông báo "Không thể xóa"
        /// </summary>
        /// Created by: ldtuan (24/07/2023)
        [Test]
        public async Task DeleteManyAsync_List10Items_ThrowException()
        {
            // Arrage
            var ids = new List<Guid>();
            for (int i = 0; i < 10; i++)
            {
                var newGuid = Guid.NewGuid();
                ids.Add(newGuid);
            }

            var assets = new List<FixedAsset>();
            for (int i = 0; i < 9; i++)
            {
                var asset = new FixedAsset();
                assets.Add(asset);
            }

            assetRepository.GetListByIdsAsync(ids).Returns(assets);

            var expectedMessage = "Không thể xóa";

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await assetService.DeleteManyAsync(ids));
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));

            await assetRepository.Received(1).GetListByIdsAsync(ids);
            await unitOfWork.Received(1).BeginTransactionAsync();
            await unitOfWork.Received(1).RollbackAsync();
        }

        /// <summary>
        /// Test case cho việc xóa nhiều bản ghi khi danh sách chứa 10 bản ghi
        /// Trường hợp này sẽ xóa thành công các bản ghi trong danh sách
        /// </summary>
        /// Created by: ldtuan (24/07/2023)
        [Test]
        public async Task DeleteManyAsync_List10Items_Success()
        {
            // Arrage
            var ids = new List<Guid>();
            for (int i = 0; i < 10; i++)
            {
                var newGuid = Guid.NewGuid();
                ids.Add(newGuid);
            }

            var assets = new List<FixedAsset>();
            for (int i = 0; i < 10; i++)
            {
                var asset = new FixedAsset();
                assets.Add(asset);
            }

            assetRepository.GetListByIdsAsync(ids).Returns(assets);

            // Act
            await assetService.DeleteManyAsync(ids);

            // Assert
            await assetRepository.Received(1).GetListByIdsAsync(ids);
            await assetRepository.Received(1).DeleteManyAsync(assets);
            await unitOfWork.Received(1).BeginTransactionAsync();
            await unitOfWork.Received(1).CommitAsync();
        } 
        #endregion
    }
}
