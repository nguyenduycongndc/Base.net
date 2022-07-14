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
        private readonly ITransactionNFTService _transactionNFTService;
        public readonly string _contentFolderHero;
        public const string CONTEN_FOLDER_NAME_HERO = "FileExcelHero.xlsx";
        public readonly string _contentFolderItem;
        public const string CONTEN_FOLDER_NAME_ITEM = "FileExcelItem.xlsx";
        public readonly string _contentFolderTicket;
        public const string CONTEN_FOLDER_NAME_TICKET = "FileExcelTicket.xlsx";
        public readonly string _contentFolderPack;
        public const string CONTEN_FOLDER_NAME_PACK = "FileExcelPack.xlsx";
        public readonly string _contentFolderEgg;
        public const string CONTEN_FOLDER_NAME_EGG = "FileExcelEgg.xlsx";

        public TransactionController(ILogger<TransactionController> logger, ITransactionNFTService transactionNFTService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _transactionNFTService = transactionNFTService;
            _contentFolderHero = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME_HERO);
            _contentFolderItem = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME_ITEM);
            _contentFolderTicket = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME_TICKET);
            _contentFolderPack = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME_PACK);
            _contentFolderEgg = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME_EGG);
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
        #region Hero
        [HttpPost]
        [Route("SearchHero")]
        public TransactionHeroRsModel SearchHero([FromBody] TransactionSearchModel transactionSearchModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _transactionNFTService.GetAllHeroService(transactionSearchModel);
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
        public IActionResult ExportHero(string jsonData)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel userInfo)
                {
                    return Unauthorized();
                }
                var obj = JsonSerializer.Deserialize<TransactionSearchModel>(jsonData);
                var data = _transactionNFTService.GetAllHeroService(obj);
                var count = data.Count;
                if (count == 0)
                {
                    var tem = new FileInfo($"{_contentFolderHero}");
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
                var template = new FileInfo($"{_contentFolderHero}");
             
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
                        ExcelRange dataRp0 = worksheet.Cells[startrow, startcol];
                        dataRp0.Value = string.Join(", ", a.IdHero);
                        //
                        ExcelRange dataRp1 = worksheet.Cells[startrow, startcol + 1];
                        dataRp1.Value = string.Join(", ", a.Rarity);
                        //
                        ExcelRange dataRp2 = worksheet.Cells[startrow, startcol + 2];
                        dataRp2.Value = string.Join(", ", a.Level);
                        //
                        ExcelRange dataRp3 = worksheet.Cells[startrow, startcol + 3];
                        dataRp3.Value = string.Join(", ", a.Element);
                        //
                        ExcelRange dataRp4 = worksheet.Cells[startrow, startcol + 4];
                        dataRp4.Value = string.Join(", ", a.Genders);
                        //
                        ExcelRange dataRp5 = worksheet.Cells[startrow, startcol + 5];
                        dataRp5.Value = string.Join(", ", a.Price);
                        //
                        ExcelRange dataRp6 = worksheet.Cells[startrow, startcol + 6];
                        dataRp6.Value = string.Join(", ", a.Fee);
                        //
                        ExcelRange dataRp7 = worksheet.Cells[startrow, startcol + 7];
                        dataRp7.Value = string.Join(", ", a.Time);
                       
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
        #endregion
        #region Item
        [HttpPost]
        [Route("SearchItem")]
        public TransactionItemRsModel SearchItem([FromBody] TransactionSearchModel transactionSearchModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _transactionNFTService.GetAllItemService(transactionSearchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        //xuất excel
        [HttpGet]
        [Route("ExportItem")]
        public IActionResult ExportItem(string jsonData)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel userInfo)
                {
                    return Unauthorized();
                }
                var obj = JsonSerializer.Deserialize<TransactionSearchModel>(jsonData);
                var data = _transactionNFTService.GetAllItemService(obj);
                var count = data.Count;
                if (count == 0)
                {
                    var tem = new FileInfo($"{_contentFolderItem}");
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
                var template = new FileInfo($"{_contentFolderItem}");

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
                        ExcelRange dataRp0 = worksheet.Cells[startrow, startcol];
                        dataRp0.Value = string.Join(", ", a.IdItem);
                        //
                        ExcelRange dataRp1 = worksheet.Cells[startrow, startcol + 1];
                        dataRp1.Value = string.Join(", ", a.Rarity);
                        //
                        ExcelRange dataRp2 = worksheet.Cells[startrow, startcol + 2];
                        dataRp2.Value = string.Join(", ", a.Level);
                        //
                        ExcelRange dataRp3 = worksheet.Cells[startrow, startcol + 3];
                        dataRp3.Value = string.Join(", ", a.Price);
                        //
                        ExcelRange dataRp4 = worksheet.Cells[startrow, startcol + 4];
                        dataRp4.Value = string.Join(", ", a.Fee);
                        //
                        ExcelRange dataRp5 = worksheet.Cells[startrow, startcol + 5];
                        dataRp5.Value = string.Join(", ", a.Time);

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
        #endregion
        #region Ticket
        [HttpPost]
        [Route("SearchTicket")]
        public TransactionTicketRsModel SearchTicket([FromBody] TransactionSearchModel transactionSearchModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _transactionNFTService.GetAllTicketService(transactionSearchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        //xuất excel
        [HttpGet]
        [Route("ExportTicket")]
        public IActionResult ExportTicket(string jsonData)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel userInfo)
                {
                    return Unauthorized();
                }
                var obj = JsonSerializer.Deserialize<TransactionSearchModel>(jsonData);
                var data = _transactionNFTService.GetAllTicketService(obj);
                var count = data.Count;
                if (count == 0)
                {
                    var tem = new FileInfo($"{_contentFolderTicket}");
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
                var template = new FileInfo($"{_contentFolderTicket}");

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
                        ExcelRange dataRp0 = worksheet.Cells[startrow, startcol];
                        dataRp0.Value = string.Join(", ", a.IdTicket);
                        //
                        ExcelRange dataRp1 = worksheet.Cells[startrow, startcol + 1];
                        dataRp1.Value = string.Join(", ", a.Rarity);
                        //
                        ExcelRange dataRp2 = worksheet.Cells[startrow, startcol + 2];
                        dataRp2.Value = string.Join(", ", a.Price);
                        //
                        ExcelRange dataRp3 = worksheet.Cells[startrow, startcol + 3];
                        dataRp3.Value = string.Join(", ", a.Fee);
                        //
                        ExcelRange dataRp4 = worksheet.Cells[startrow, startcol + 4];
                        dataRp4.Value = string.Join(", ", a.Time);

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
        #endregion
        #region Pack
        [HttpPost]
        [Route("SearchPack")]
        public TransactionPackRsModel SearchPack([FromBody] TransactionSearchModel transactionSearchModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _transactionNFTService.GetAllPackService(transactionSearchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        //xuất excel
        [HttpGet]
        [Route("ExportPack")]
        public IActionResult ExportPack(string jsonData)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel userInfo)
                {
                    return Unauthorized();
                }
                var obj = JsonSerializer.Deserialize<TransactionSearchModel>(jsonData);
                var data = _transactionNFTService.GetAllPackService(obj);
                var count = data.Count;
                if (count == 0)
                {
                    var tem = new FileInfo($"{_contentFolderPack}");
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
                var template = new FileInfo($"{_contentFolderPack}");

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
                        ExcelRange dataRp0 = worksheet.Cells[startrow, startcol];
                        dataRp0.Value = string.Join(", ", a.IdPack);
                        //
                        ExcelRange dataRp1 = worksheet.Cells[startrow, startcol + 1];
                        dataRp1.Value = string.Join(", ", a.Rarity);
                        //
                        ExcelRange dataRp2 = worksheet.Cells[startrow, startcol + 2];
                        dataRp2.Value = string.Join(", ", a.Price);
                        //
                        ExcelRange dataRp3 = worksheet.Cells[startrow, startcol + 3];
                        dataRp3.Value = string.Join(", ", a.Fee);
                        //
                        ExcelRange dataRp4 = worksheet.Cells[startrow, startcol + 4];
                        dataRp4.Value = string.Join(", ", a.Time);

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
        #endregion
        #region Egg
        [HttpPost]
        [Route("SearchEgg")]
        public TransactionEggRsModel SearchEgg([FromBody] TransactionSearchModel transactionSearchModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _transactionNFTService.GetAllEggService(transactionSearchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        //xuất excel
        [HttpGet]
        [Route("ExportEgg")]
        public IActionResult ExportEgg(string jsonData)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel userInfo)
                {
                    return Unauthorized();
                }
                var obj = JsonSerializer.Deserialize<TransactionSearchModel>(jsonData);
                var data = _transactionNFTService.GetAllEggService(obj);
                var count = data.Count;
                if (count == 0)
                {
                    var tem = new FileInfo($"{_contentFolderEgg}");
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
                var template = new FileInfo($"{_contentFolderEgg}");

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
                        ExcelRange dataRp0 = worksheet.Cells[startrow, startcol];
                        dataRp0.Value = string.Join(", ", a.IdEgg);
                        //
                        ExcelRange dataRp1 = worksheet.Cells[startrow, startcol + 1];
                        dataRp1.Value = string.Join(", ", a.Rarity);
                        //
                        ExcelRange dataRp2 = worksheet.Cells[startrow, startcol + 2];
                        dataRp2.Value = string.Join(", ", a.Price);
                        //
                        ExcelRange dataRp3 = worksheet.Cells[startrow, startcol + 3];
                        dataRp3.Value = string.Join(", ", a.Fee);
                        //
                        ExcelRange dataRp4 = worksheet.Cells[startrow, startcol + 4];
                        dataRp4.Value = string.Join(", ", a.Time);

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
        #endregion
    }

}
