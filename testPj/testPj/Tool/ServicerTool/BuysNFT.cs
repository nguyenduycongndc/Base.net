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
using testPj.Models;
using testPj.Services.Interface;
using testPj.Tool.ServicerTool.InterfaceBuyNFT;

namespace testPj.Tool.ServicerTool
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
