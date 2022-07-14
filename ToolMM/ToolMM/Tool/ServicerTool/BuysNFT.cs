using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToolMM.Models;
using ToolMM.Services.Interface;
using ToolMM.Tool.ServicerTool.InterfaceBuyNFT;

namespace ToolMM.Tool.ServicerTool
{
    public class BuysNFT : IBuyNFT
    {
        private readonly IBuyNFT _buyNFT;
        private readonly ILogger<BuysNFT> _logger;
        //private readonly ISellService _sellService;
        public BuysNFT(ILogger<BuysNFT> logger,/* ISellService sellService,*/ IBuyNFT buyNFT)
        {
            //_sellService = sellService;
            _logger = logger;
            _buyNFT = buyNFT;
        }

        public Task<OutPut> GetDataHero(InputBuyModel inputBuyModel)
        {
            return _buyNFT.GetDataHero(inputBuyModel);
        }
    }
}
