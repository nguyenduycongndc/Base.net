using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace testPj.Data
{
    [Table("TRANSACTION_HISTORY")]
    public class TransactionHistory
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("id_nft")]
        [JsonPropertyName("id_nft")]
        public int IdNFT { get; set; }

        [Column("class")]
        [JsonPropertyName("class")]
        public string Class { get; set; }

        [Column("rarity")]
        [JsonPropertyName("rarity")]
        public string rarity { get; set; }

        [Column("address_wallet")]
        [JsonPropertyName("address_wallet")]
        public string AddressWallet { get; set; }

        [Column("TAU")]
        [JsonPropertyName("TAU")]
        public double TAU { get; set; }

        [Column("BNB")]
        [JsonPropertyName("BNB")]
        public double BNB { get; set; }

        [Column("USD")]
        [JsonPropertyName("USD")]
        public double USD { get; set; }

        [Column("Sell_TAU")]
        [JsonPropertyName("Sell_TAU")]
        public double Sell_TAU { get; set; }

        [Column("Buy_TAU")]
        [JsonPropertyName("Buy_TAU")]
        public double Buy_TAU { get; set; }

        [Column("Date_Sell")]
        [JsonPropertyName("Date_Sell")]
        public DateTime? Date_Sell { get; set; }

        [Column("Date_Buy")]
        [JsonPropertyName("Date_Buy")]
        public DateTime? Date_Buy { get; set; }

        [Column("Is_Selling")]
        [JsonPropertyName("Is_Selling")]
        public bool Is_Selling { get; set; }//Bán hoặc ngừng bán

        [Column("is_check")]
        [JsonPropertyName("is_check")]
        public int IsCheck { get; set; }

        [Column("token_id")]
        [JsonPropertyName("token_id")]
        public int Token_Id { get; set; }

        [Column("is_active")]
        [JsonPropertyName("is_active")]
        public int IsActive { get; set; }//0-chợ, 1-túi
    }
}
