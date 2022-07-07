using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Tool.ServicerTool.InterfaceSellNFT
{
    public interface ISellNFT 
    { 
        Task<bool> CallGetMethodSell(List<SellModel> InputSell);
    }
}
