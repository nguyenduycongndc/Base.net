using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace testPj.Models
{
    public class TransactionHistoryModel
    {
        public int id { get; set; }
        public int IdNFT { get; set; }
        public string Class { get; set; }
        public string rarity { get; set; }
        public string AddressWallet { get; set; }
        public double? TAU { get; set; }
        public double? BNB { get; set; }
        public double? USD { get; set; }
        public double? Sell_TAU { get; set; }
        public double? Buy_TAU { get; set; }
        public DateTime? Date_Sell { get; set; }
        public DateTime? Date_Buy { get; set; }
        public bool Is_Selling { get; set; }//1-Bán hoặc 0-ngừng bán hoặc null-chưa có hoạt động gì
        public int IsCheck { get; set; }
        public int IsActive { get; set; }//0-chợ, 1-túi
    }
    public class SearchSellModel
    {
        public string Type { get; set; }
        public string Rarity { get; set; }
        public int IsActive { get; set; }
        public string Wallet { get; set; }
        [JsonPropertyName("start_number")]
        public int StartNumber { get; set; }
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
    }
    public class SellModel
    {
        public int Id { get; set; }
        public int IdNFT { get; set; }
        public string Class { get; set; }
        public string rarity { get; set; }
        public double? TAU { get; set; }
        public double? USD { get; set; }
        public double? Sell_TAU { get; set; }
        public string privateKey { get; set; }
        public string AddressWallet { get; set; }
        public int Token_Id { get; set; }
        public int IsActive { get; set; }// 0-Túi, 1-chợ
        public bool Is_Selling { get; set; }//true-Bán hoặc false-ngừng bán
        public double priceNFT { get; set; }
    }
    public class SellRsModel
    {
        public int Id { get; set; }
        public int IdNFT { get; set; }
        public string Class { get; set; }
        public string rarity { get; set; }
        public double? TAU { get; set; }
        public double? USD { get; set; }
        public double? Sell_TAU { get; set; }
        public string AddressWallet { get; set; }
        public int Token_Id { get; set; }
        public int IsActive { get; set; }// 0-Túi, 1-chợ
        public bool Is_Selling { get; set; }//true-Bán hoặc false-ngừng bán
        public double priceNFT { get; set; }
    }
    public class ChooseAll
    {
        public string listID { get; set; }
        public int priceNFT { get; set; }
    }
    public class CheckSellModel
    {
        public int heroId { get; set; }
        public string transactionId { get; set; }
        public string ownerId { get; set; }
    }
    public class DtCheckSellModel
    {
        public string checksum { get; set; }
        public long unixTime { get; set; }
        public int heroId { get; set; }
        public string transactionId { get; set; }
        public string ownerId { get; set; }
    }

    public class SellActiveModel
    {
        public int IdNFT { get; set; }
        public string Class { get; set; }

        public string rarity { get; set; }

        public string AddressWallet { get; set; }
        public double BNB { get; set; }

        public double USD { get; set; }

        public bool Is_Selling { get; set; }
        public int Token_Id { get; set; }
        public int priceNFT { get; set; }
    }
}
