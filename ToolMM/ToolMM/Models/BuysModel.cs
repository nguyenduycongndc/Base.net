using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolMM.Models
{
    public class BuysModel
    {
        public int Id { get; set; }
        public string RequestBody { get; set; }
        public int IsActive { get; set; }
    }
    public class BuysActiveModel
    {
        public int IdNFT { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }

        public string Rarity { get; set; }
        public string Sex { get; set; }

        public string Elemental { get; set; }
        public int Level { get; set; }
        public string AddressWallet { get; set; }
        public double BNB { get; set; }

        public double TAU { get; set; }
        public double USD { get; set; }
        public double Fee { get; set; }

        public bool Is_Selling { get; set; }
        public int Token_Id { get; set; }
    }
}
