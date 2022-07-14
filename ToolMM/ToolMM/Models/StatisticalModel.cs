using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToolMM.Models
{
    public class StatisticalModel
    {
        public class SearchStatisticalModel
        {
            public string Wallet { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            [JsonPropertyName("start_number")]
            public int StartNumber { get; set; }
            [JsonPropertyName("page_size")]
            public int PageSize { get; set; }
        }
        public class StatisticalInputSearchModel
        {
            public int Id { get; set; }
            public int IdNFT { get; set; }
            public string Wallet { get; set; }
            public string Rarity { get; set; }
            public string Class { get; set; }
            public string Date { get; set; }
            public double BuyPrice { get; set; }
            public double SellPrice { get; set; }
            public double Profit { get; set; }
        }
        public class StatisticalRsModel
        {
            public List<StatisticalInputSearchModel> Data { get; set; }
            public int Count { get; set; }
        }
    }
}
