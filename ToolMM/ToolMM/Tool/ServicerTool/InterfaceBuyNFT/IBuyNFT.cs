using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;

namespace ToolMM.Tool.ServicerTool.InterfaceBuyNFT
{
    public interface IBuyNFT
    {
        Task<OutPut> GetDataHero(InputBuyModel inputBuyModel);
    }
}
