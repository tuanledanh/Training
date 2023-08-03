using Application.DTO.FixedAssett;
using MSIA.WebFresher052023.Application.Response.Base;

namespace MSIA.WebFresher052023.Application.Response
{
    internal class AssetFilterResponse : BaseFilterResponse<FixedAssetDto>
    {
        public AssetFilterResponse(int? totalPages, int? totalRecords, List<FixedAssetDto>? data) : base(totalPages, totalRecords, data)
        {
        }
    }
}
