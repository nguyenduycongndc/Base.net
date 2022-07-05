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
            var listData = new List<BuysModel>();

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var buysService = scope.ServiceProvider.GetService<IBuysService>();
                var buyNFT = scope.ServiceProvider.GetService<IBuyNFT>();
               
                if (buyNFT != null)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        if (buysService != null)
                        {
                            listData = buysService.GetAllListBuy();
                        }
                        var result = new InputBuyModel();
                        if (listData.Count() != 0)
                        {
                            result = JsonConvert.DeserializeObject<InputBuyModel>(listData[0].RequestBody);
                        }
                        else
                        {
                            result = null;
                        }
                        var tetNFT = buyNFT.GetDataHero(result);
                        await Task.Delay(1000 * 5);
                    }
                }
            }
        }
    }
}
