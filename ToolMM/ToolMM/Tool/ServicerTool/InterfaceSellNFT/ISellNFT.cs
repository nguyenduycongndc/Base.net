using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;

namespace ToolMM.Tool.ServicerTool.InterfaceSellNFT
{
    public interface ISellNFT 
    { 
        Task<bool> CallGetMethodSell(List<SellModel> InputSell);
    }
}
