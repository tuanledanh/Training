using Application.DTO.FixedAssett;
using Application.Interface;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Model;
using FastMember;
using Microsoft.AspNetCore.Mvc;
using MSIA.WebFresher052023.API.Controllers.Base;
using System.Data;
using static Dapper.SqlMapper;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FixedAssetController : BaseController<FixedAsset, FixedAssetModel, FixedAssetDto, FixedAssetCreateDto, FixedAssetUpdateDto>
    {
        private readonly IFixedAssetService _fixedAssetService;

        public FixedAssetController(IFixedAssetService fixedAssetService) : base(fixedAssetService)
        {
            _fixedAssetService = fixedAssetService;
        }

        /// <summary>
        /// Api lấy danh sách bản ghi, có phân trang và lọc
        /// </summary>
        /// <param name="pageNumber">Số trang</param>
        /// <param name="pageLimit">Số bản ghi tối đa</param>
        /// <param name="filterName">Tên của bản ghi để thực hiện lọc</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: ldtuan (18/07/2023)
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int? pageNumber, [FromQuery] int? pageLimit, [FromQuery] string? filterName, [FromQuery] string? departId, [FromQuery] string? aTypeId)
        {
            var assetList = await _fixedAssetService.GetAllCustomAsync(pageNumber, pageLimit, filterName, departId, aTypeId);
            return StatusCode(StatusCodes.Status200OK, assetList);
        }

        [HttpGet("export")]
        public ActionResult ExportExcel()
        {
            List<FixedAssetDto> fixedAssetDtos = new List<FixedAssetDto>();
            fixedAssetDtos.Add(new FixedAssetDto
            {
                FixedAssetId = Guid.Parse("aab92299-30f0-11ee-b14c-f875a4da458a"),
                FixedAssetCode = "FA00052",
                FixedAssetName = "oijiohjpoij[ ouig iuhphouh oph 09 i90u 98 ",
                DepartmentId = Guid.Parse("4e272fc4-7875-78d6-7d32-6a1673ffca7c"),
                DepartmentCode = "DP0002",
                DepartmentName = "Phòng ban Nghiên cứu và phát triển",
                FixedAssetCategoryId = Guid.Parse("697be7ba-1738-6adf-298f-4d82f3a13455"),
                FixedAssetCategoryCode = "FAC0007",
                FixedAssetCategoryName = "Công cụ và dụng cụ thủ công",
                PurchaseDate = DateTime.Now,
                StartUsingDate = DateTime.Now,
                Cost = 9098,
                Quantity = 890809,
                TrackedYear = 2023,
                LifeTime = 13,
                ProductionYear = 0
            });

            if (fixedAssetDtos != null && fixedAssetDtos.Count > 0)
            {
                var assetData = GetFixedAssetData(fixedAssetDtos);
                using (XLWorkbook workBook = new XLWorkbook())
                {
                    var workSheet = workBook.AddWorksheet(assetData, "Tài sản");
                    workSheet.Columns().AdjustToContents();
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        workBook.SaveAs(memoryStream);
                        memoryStream.Position = 0;
                        var result = File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Asset.xlsx");
                        return result;
                    }
                }
            }
            else
            {
                throw new NotFoundException();
            }
        }

        [NonAction]
        private DataTable GetFixedAssetData(List<FixedAssetDto> assetList)
        {
            var data = new DataTable();
            data.TableName = "Báo cáo tài sản";
            var properties = typeof(FixedAssetDto).GetProperties();
            foreach (var property in properties)
            {
                data.Columns.Add(property.Name, property.PropertyType);
            }

            if (assetList != null && assetList.Count > 0)
            {
                var accessor = TypeAccessor.Create(typeof(FixedAssetDto));
                foreach (var item in assetList)
                {
                    var row = data.NewRow();
                    foreach (var property in properties)
                    {
                        var value = accessor[item, property.Name];
                        row[property.Name] = value;
                    }
                    data.Rows.Add(row);
                }
            }

            return data;
        }

    }
}