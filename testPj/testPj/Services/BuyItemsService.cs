using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;
using testPj.Services.Interface;

namespace testPj.Services
{
    public class BuyItemsService : IBuyItemsService
    {
        private readonly ILogger<BuyItemsService> _logger;
        private readonly IBuyItemRepo _buyItemRepo;

        public BuyItemsService(ILogger<BuyItemsService> logger, IBuyItemRepo buyItemRepo)
        {
            _logger = logger;
            _buyItemRepo = buyItemRepo;

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
                return await _buyItemRepo.CreateDataRepo(inputToolBuy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public List<BuyItemModel> GetAllListBuy()
        {
            var qr = _buyItemRepo.GetAll();
            List<BuyItemModel> lst = new List<BuyItemModel>();
            var list = qr.Where(x => x.IsActive == 1).Select(x => new BuyItemModel()
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
                var data = _buyItemRepo.GetDetailBuy(id);
                if (data == null) return false;
                data.IsActive = 0;
                return await _buyItemRepo.DeleteBuy(data);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
