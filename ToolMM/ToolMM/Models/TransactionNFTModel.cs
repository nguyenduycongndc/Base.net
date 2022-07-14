using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToolMM.Models
{
    public class TransactionSearchModel
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
        [JsonPropertyName("start_number")]
        public int StartNumber { get; set; }
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
    }
    #region Hero
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
        public int Total_NFT { get; set; }
        public int Count_Hero { get; set; }
        public int Count_Ticket { get; set; }
        public int Count_Packet { get; set; }
        public int Count_Egg { get; set; }
        public int Count_Item { get; set; }
    }
    #endregion
    #region Item
    public class TransactionItemResultModel
    {
        public int Id { get; set; }
        public int IdItem { get; set; }
        public string Rarity { get; set; }
        public int Level { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public string Time { get; set; }
    }
    public class TransactionItemRsModel
    {
        public List<TransactionItemResultModel> Data { get; set; }
        public int Count { get; set; }
        public int Total_NFT { get; set; }
        public int Count_Hero { get; set; }
        public int Count_Ticket { get; set; }
        public int Count_Packet { get; set; }
        public int Count_Egg { get; set; }
        public int Count_Item { get; set; }
    }
    #endregion
    #region Ticket
    public class TransactionTicketResultModel
    {
        public int Id { get; set; }
        public int IdTicket { get; set; }
        public string Rarity { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public string Time { get; set; }
    }
    public class TransactionTicketRsModel
    {
        public List<TransactionTicketResultModel> Data { get; set; }
        public int Count { get; set; }
        public int Total_NFT { get; set; }
        public int Count_Hero { get; set; }
        public int Count_Ticket { get; set; }
        public int Count_Packet { get; set; }
        public int Count_Egg { get; set; }
        public int Count_Item { get; set; }
    }
    #endregion
    #region Pack
    public class TransactionPackResultModel
    {
        public int Id { get; set; }
        public int IdPack { get; set; }
        public string Rarity { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public string Time { get; set; }
    }
    public class TransactionPackRsModel
    {
        public List<TransactionPackResultModel> Data { get; set; }
        public int Count { get; set; }
        public int Total_NFT { get; set; }
        public int Count_Hero { get; set; }
        public int Count_Ticket { get; set; }
        public int Count_Packet { get; set; }
        public int Count_Egg { get; set; }
        public int Count_Item { get; set; }
    }
    #endregion
    #region Egg
    public class TransactionEggResultModel
    {
        public int Id { get; set; }
        public int IdEgg { get; set; }
        public string Rarity { get; set; }
        public double Price { get; set; }
        public double Fee { get; set; }
        public string Time { get; set; }
    }
    public class TransactionEggRsModel
    {
        public List<TransactionEggResultModel> Data { get; set; }
        public int Count { get; set; }
        public int Total_NFT { get; set; }
        public int Count_Hero { get; set; }
        public int Count_Ticket { get; set; }
        public int Count_Packet { get; set; }
        public int Count_Egg { get; set; }
        public int Count_Item { get; set; }
    }
    #endregion
}
