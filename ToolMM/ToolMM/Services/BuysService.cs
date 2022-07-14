using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Models;
using ToolMM.Repo.Interface;
using ToolMM.Services.Interface;

namespace ToolMM.Services
{
    public class BuysService : IBuysService
    {
        private readonly ILogger<BuysService> _logger;
        private readonly IBuysRepo _buysRepo;

        public BuysService(ILogger<BuysService> logger, IBuysRepo buysRepo)
        {
            _logger = logger;
            _buysRepo = buysRepo;

        }
        public async Task<bool> CreateData(InputBuyModel inputBuyModel, CurrentUserModel _userInfo)
        {
            try
            {
                var list = GetAllListBuy();
                if (list != null)
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                        await DeleteListBuy(list[i].Id);
                    }
                }
                var json = new JavaScriptSerializer().Serialize(inputBuyModel);
                InputToolBuy inputToolBuy = new InputToolBuy()
                {
                    RequestBody = json,
                    IsActive = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = _userInfo.Id,
                };
                return await _buysRepo.CreateDataRepo(inputToolBuy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public List<BuysModel> GetAllListBuy()
        {
            var qr = _buysRepo.GetAll();
            List<BuysModel> lst = new List<BuysModel>();
            var list = qr.Where(x => x.IsActive == 1).Select(x => new BuysModel()
            {
                Id = x.Id,
                RequestBody = x.RequestBody,
                IsActive = x.IsActive
            }).ToList();

            return list;
        }
        public async Task<bool> DeleteListBuy(int id)
        {
            try
            {
                var data = _buysRepo.GetDetailBuy(id);
                if (data == null) return false;
                data.IsActive = 0;
                return await _buysRepo.DeleteBuy(data);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> PauseDataBuy()
        {
            try
            {
                var list = GetAllListBuy();
                if (list != null)
                {
                    await DeleteListBuy(list[0].Id);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
