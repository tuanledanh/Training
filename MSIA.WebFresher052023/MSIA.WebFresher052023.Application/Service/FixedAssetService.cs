using Application.DTO.FixedAssett;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Model;
using MSIA.WebFresher052023.Application.Response.Base;
using MSIA.WebFresher052023.Application.Service.Base;
using MSIA.WebFresher052023.Domain.Interface;
using MSIA.WebFresher052023.Domain.Interface.Manager;
using MSIA.WebFresher052023.Domain.Interface.Repository;

namespace Application.Service
{
    public class FixedAssetService : BaseService<FixedAsset, FixedAssetModel, FixedAssetDto, FixedAssetCreateDto, FixedAssetUpdateDto>, IFixedAssetService
    {
        #region Fields
        private readonly IFixedAssetRepository _assetRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFixedAssetCategoryRepository _fixedAssetCategoryRepository;
        private readonly IFixedAssetManager _fixedAssetManager;
        #endregion

        #region Constructor
        public FixedAssetService(IFixedAssetRepository assetRepository, IMapper mapper, IDepartmentRepository departmentRepository, IFixedAssetCategoryRepository fixedAssetCategoryRepository, IFixedAssetManager fixedAssetManager, IUnitOfWork unitOfWork) : base(assetRepository, mapper, fixedAssetManager, unitOfWork)
        {
            _assetRepository = assetRepository;
            _departmentRepository = departmentRepository;
            _fixedAssetCategoryRepository = fixedAssetCategoryRepository;
            _fixedAssetManager = fixedAssetManager;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Lấy danh sách các bản ghi, có phân trang, tìm kiếm theo mã code, lọc theo phòng ban và loại tài sản
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageLimit">Số lượng tối đa bản ghi mỗi trang</param>
        /// <param name="filterName">Mã code để tìm kiếm</param>
        /// <param name="departId">Id của phòng ban dùng để lọc</param>
        /// <param name="aTypeId">Id của loại tài sản dùng để lọc</param>
        /// <returns>Danh sách tài sản đáp ứng đúng các điều kiện</returns>
        /// Created by: ldtuan (23/07/2023)
        public async Task<BaseFilterResponse<FixedAssetDto>> GetAllCustomAsync(int? pageNumber, int? pageLimit, string filterName, string? departId, string? aTypeId)
        {
            List<FixedAssetModel> entities;
            pageNumber = pageNumber.HasValue ? pageNumber : 1;
            pageLimit = pageLimit.HasValue ? pageLimit : 20;
            filterName = string.IsNullOrEmpty(filterName) ? "" : filterName;
            string departmentIdString = Guid.TryParse(departId, out Guid departmentId) ? departId : string.Empty;
            string assetTypeIdString = Guid.TryParse(aTypeId, out Guid assetTypeId) ? aTypeId : string.Empty;

            int totalRecords = await _assetRepository.GetCountFilterAsync(filterName, departmentIdString, assetTypeIdString);
            int totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double) pageLimit));

            entities = await _assetRepository.GetFilterSearchAsync(pageNumber, pageLimit, filterName, departmentIdString, assetTypeIdString);
            List<FixedAssetDto> entitiesDto = new List<FixedAssetDto>();
            foreach (var entity in entities)
            {
                entitiesDto.Add(_mapper.Map<FixedAssetDto>(entity));
            }

            var filterData = new BaseFilterResponse<FixedAssetDto>(totalPages, totalRecords, entitiesDto);
            return filterData;
        }

        /// <summary>
        /// Gọi đến hàm InsertAsync ở repository để xử lý thêm mới một bản ghi
        /// </summary>
        /// <param name="assetCreateDto">Thông tin của bản ghi</param>
        /// <returns>True nếu thêm mới thành công, false nếu thêm mới thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public override async Task<bool> InsertAsync(FixedAssetCreateDto fixedAssetCreateDto)
        {
            await _fixedAssetManager.CheckDuplicateCode(fixedAssetCreateDto.FixedAssetCode);
            var existDepartment = await _departmentRepository.GetAsync(fixedAssetCreateDto.DepartmentId);
            var existAssetType = await _fixedAssetCategoryRepository.GetAsync(fixedAssetCreateDto.FixedAssetCategoryId);
            if (existDepartment == null || existAssetType == null)
            {
                // Để hàm check exist sang 1 class khác để tái sử dụng
                throw new NotFoundException("Không tìm thấy phòng ban hoặc tài sản");
            }
            var entity = _mapper.Map<FixedAsset>(fixedAssetCreateDto);
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            bool result = await _baseRepository.InsertAsync(entity);
            if (!result)
            {
                throw new Exception("Service: Không thể thêm mới tài sản");
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Gọi đến hàm UpdateAsync ở repository để xử lý cập nhật một bản ghi
        /// </summary>
        /// <param name="entityCreateDto">Thông tin của bản ghi</param>
        /// <returns>True nếu cập nhật thành công, false nếu cập nhật thất bại</returns>
        /// Created by: ldtuan (17/07/2023)
        public override async Task<bool> UpdateAsync(Guid id, FixedAssetUpdateDto fixedAssetUpdateDto)
        {
            var oldAsset = await _baseRepository.GetAsync(id);
            await _fixedAssetManager.CheckDuplicateCode(fixedAssetUpdateDto.FixedAssetCode, oldAsset.FixedAssetCode);
            var existDepartment = await _departmentRepository.GetAsync(fixedAssetUpdateDto.DepartmentId);
            var existAssetType = await _fixedAssetCategoryRepository.GetAsync(fixedAssetUpdateDto.FixedAssetCategoryId);
            if (existDepartment == null || existAssetType == null)
            {
                // Để hàm check exist sang 1 class khác để tái sử dụng
                throw new NotFoundException("Không tìm thấy phòng ban hoặc tài sản");
            }
            var entity = _mapper.Map<FixedAsset>(fixedAssetUpdateDto);
            entity.FixedAssetId = id;
            entity.ModifiedDate = DateTime.Now;
            bool result = await _baseRepository.UpdateAsync(entity);
            if (!result)
            {
                throw new Exception("Service: Không thể cập nhật tài sản");
            }
            else
            {
                return result;
            }
        }
        #endregion
    }
}
