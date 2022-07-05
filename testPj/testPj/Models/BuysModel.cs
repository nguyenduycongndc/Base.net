using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testPj.Models
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

        public string rarity { get; set; }

        public string AddressWallet { get; set; }
        public double BNB { get; set; }

        public double USD { get; set; }

        public bool Is_Selling { get; set; }
    }
}
