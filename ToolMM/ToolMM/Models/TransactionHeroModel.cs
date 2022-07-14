using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToolMM.Models
{
    public class TransactionHeroSearchModel
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
        [JsonPropertyName("start_number")]
        public int StartNumber { get; set; }
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
    }
    public class TransactionHeroResultModel
    {
        public int Id { get; set; }
        public int IdHero { get; set; }
        public string Rarity { get; set; }
        public int Level { get; set; }
        public string Element { get; set; }
        public string Genders { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public string Time { get; set; }
    }
    public class TransactionHeroRsModel
    {
        public List<TransactionHeroResultModel> Data { get; set; }
        public int Count { get; set; }
    }
}
