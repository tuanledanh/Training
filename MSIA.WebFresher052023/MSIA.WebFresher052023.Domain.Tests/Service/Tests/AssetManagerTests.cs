using Domain.Exceptions;
using Domain.Model;
using MSIA.WebFresher052023.Domain.Interface.Repository;
using MSIA.WebFresher052023.Domain.Service;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace MSIA.WebFresher052023.Domain.Tests.Service.Tests
{
    [TestFixture]
    public class AssetManagerTests
    {
        #region Methods
        /// <summary>
        /// Kiểm tra xem có trùng mã code không (Trường hợp mã code bị trùng, và trả lại exception)
        /// </summary>
        /// Created by: ldtuan (24/07/2023)
        [Test]
        public void CheckDuplicateCode_ExistAsset_ConflictException()
        {
            // Arrange
            var code = "SC";
            var assetRepository = Substitute.For<IFixedAssetRepository>();
            assetRepository.FindByCodeAsync(code).Returns(new FixedAssetModel());
            var assetManager = new FixedAssetManager(assetRepository);


            // Act & Assert
            Assert.ThrowsAsync<ConflictException>(async () => await assetManager.CheckDuplicateCode(code));
            assetRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Kiểm tra xem có trùng mã code không (Trường hợp mã code không bị trùng)
        /// </summary>
        /// Created by: ldtuan (24/07/2023)
        [Test]
        public async Task CheckDuplicateCode_NotExistAsset_Success()
        {
            // Arrange
            var code = "SC";
            var assetRepository = Substitute.For<IFixedAssetRepository>();
            assetRepository.FindByCodeAsync(code).ReturnsNull();
            var assetManager = new FixedAssetManager(assetRepository);


            // Act & Assert
            await assetManager.CheckDuplicateCode(code);
            await assetRepository.Received(1).FindByCodeAsync(code);
        } 
        #endregion
    }
}
