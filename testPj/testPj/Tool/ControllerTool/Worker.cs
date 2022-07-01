using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using testPj.Models;
using testPj.Services.Interface;
using testPj.Tool.ServicerTool.InterfaceBuyNFT;

namespace testPj.Tool.ControllerTool
{
    public class Worker : IWorker
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        
        public async Task DoWork(CancellationToken cancellationToken)
        {
            var test = new List<BuyItemModel>();
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var buyItemsService = scope.ServiceProvider.GetService<IBuyItemsService>();
                var buyNFT = scope.ServiceProvider.GetService<IBuyNFT>();
                if (buyItemsService != null)
                {
                    test = buyItemsService.GetAllListBuy();
                }
                if (buyNFT != null)
                {
                    var result = JsonConvert.DeserializeObject<InputBuyModel>(test[0].RequestBody);
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        //Interlocked.Increment(ref number);
                        var tetNFT = buyNFT.GetDataHero(result);
                        _logger.LogInformation($"aaaa:{test[0].RequestBody}");
                        await Task.Delay(1000 * 5);
                    }
                }
            }
            //while (!cancellationToken.IsCancellationRequested)
            //{
            //    //Interlocked.Increment(ref number);
                
            //    _logger.LogInformation($"aaaa:{test[0].RequestBody}");
            //    await Task.Delay(1000 * 5);
            //}
        }
    }
}
