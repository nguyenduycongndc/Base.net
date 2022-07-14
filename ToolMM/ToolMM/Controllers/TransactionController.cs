using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Attributes;
using ToolMM.Models;
using ToolMM.Services.Interface;
using OfficeOpenXml;
using System.Text.Json;

namespace ToolMM.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionHeroService _transactionHeroService;
        public readonly string _contentFolder;
        public const string CONTEN_FOLDER_NAME = "FileExcel.xlsx";

        public TransactionController(ILogger<TransactionController> logger, ITransactionHeroService transactionHeroService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _transactionHeroService = transactionHeroService;
            _contentFolder = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME);
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
            {
                return null;
            }
            return View();
        }
        [HttpPost]
        [Route("SearchHero")]
        public TransactionHeroRsModel Search([FromBody] TransactionHeroSearchModel transactionHeroSearchModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _transactionHeroService.GetAllHeroService(transactionHeroSearchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        //xuất excel
        [HttpGet]
        [Route("ExportHero")]
        public IActionResult Export(string jsonData)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel userInfo)
                {
                    return Unauthorized();
                }
                var obj = JsonSerializer.Deserialize<TransactionHeroSearchModel>(jsonData);
                var data = _transactionHeroService.GetAllHeroService(obj);
                var count = data.Count;
                if (count == 0)
                {
                    var tem = new FileInfo($"{_contentFolder}");
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelPackage excelPk;
                    byte[] Bt = null;
                    var mrStream = new MemoryStream();
                    using (excelPk = new ExcelPackage(tem, false))
                    {
                        var worksheet = excelPk.Workbook.Worksheets["Sheet1"];
                        Bt = excelPk.GetAsByteArray();
                    }
                    return File(Bt, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportFile.xlsx");
                }
                var template = new FileInfo($"{_contentFolder}");
             
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage excelPackage;
                byte[] Bytes = null;
                var memoryStream = new MemoryStream();
                using (excelPackage = new ExcelPackage(template, false))
                {
                    var worksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                    var startrow = 2;
                    var startcol = 1;
                    var index = 0;

                    foreach (var a in data.Data)
                    {


                        //
                        ExcelRange dataRp1 = worksheet.Cells[startrow, startcol];
                        dataRp1.Value = string.Join(", ", a.IdHero);
                        //
                        //ExcelRange dataRp2 = worksheet.Cells[startrow, startcol + 1];
                        //dataRp1.Value = string.Join(", ", a.);
                        ////
                        //ExcelRange dataRp3 = worksheet.Cells[startrow, startcol + 2];
                        //dataRp3.Value = string.Join(", ", a.);
                        ////
                        //ExcelRange dataRp4 = worksheet.Cells[startrow, startcol + 3];
                        //dataRp4.Value = string.Join(", ", a.);
                        ////
                        //ExcelRange dataRp5 = worksheet.Cells[startrow, startcol + 4];
                        //dataRp5.Value = string.Join(", ", a.);
                        ////
                        //ExcelRange dataRp6 = worksheet.Cells[startrow, startcol + 5];
                        //dataRp6.Value = string.Join(", ", a.);
                        ////
                        //ExcelRange dataRp7 = worksheet.Cells[startrow, startcol + 6];
                        //dataRp7.Value = string.Join(", ", a.);
                        ////
                        //ExcelRange dataRp8 = worksheet.Cells[startrow, startcol + 7];
                        //dataRp8.Value = string.Join(", ", a.time);
                        ////
                        //ExcelRange dataRp9 = worksheet.Cells[startrow, startcol + 8];
                        //dataRp9.Value = string.Join(", ", a.timefirstlogin);
                        ////
                        //ExcelRange dataRp10 = worksheet.Cells[startrow, startcol + 9];
                        //dataRp10.Value = string.Join(", ", a.timelastlogout);
                        ////
                        //ExcelRange dataRp11 = worksheet.Cells[startrow, startcol + 10];//tong tg
                        //dataRp11.Value = string.Join(", ", SumTime);
                        ////
                        //ExcelRange dataRp12 = worksheet.Cells[startrow, startcol + 11];//vang
                        //dataRp12.Value = string.Join(", ", Absent);
                        ////
                        //ExcelRange dataRp13 = worksheet.Cells[startrow, startcol + 12];//thieu gio
                        //dataRp13.Value = string.Join(", ", TimeInOut);
                        ////
                        //ExcelRange dataRp14 = worksheet.Cells[startrow, startcol + 13];//dia diem
                        //dataRp14.Value = string.Join(", ", a.camera_position);
                        startrow++;
                    }

                    Bytes = excelPackage.GetAsByteArray();
                }
                return File(Bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportFile.xlsx");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }

}
