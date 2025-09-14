using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using generateqrcode.Data;
using generateqrcode.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace generateqrcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportExcelController : ControllerBase
    {
        private readonly DataContext _context;
        public ImportExcelController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcelFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");


            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheets.First();
            var rows = worksheet.RowsUsed().Skip(1);
            var donvihanhchinhs = new List<DonViHanhChinh>();
            foreach (var row in rows)
            {
                var donvihanhchinh = new DonViHanhChinh
                {
                    TinhThanhPho = row.Cell(1).GetString(),
                    MaTP = row.Cell(2).GetString(),
                    QuanHuyen = row.Cell(3).GetString(),
                    MaQH = row.Cell(4).GetString(),
                    PhuongXaThiTran = row.Cell(5).GetString(),
                    MaPX = row.Cell(6).GetString(),
                    Cap = row.Cell(7).GetString(),
                    TenTiengAnh = row.Cell(8).GetString()
                };
                donvihanhchinhs.Add(donvihanhchinh);
            }
            await _context.DonViHanhChinhs.AddRangeAsync(donvihanhchinhs);
            await _context.SaveChangesAsync();
            return Ok(new { Message = $"{donvihanhchinhs.Count} don vi imported successfully!" });

        }

    }
}