using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToolMM.Tool.ServicerTool.ModelCheckSell
{
    public class ResultCheckSellModel
    {
        public int code { get; set; }
        public string text { get; set; }
        public string msg { get; set; }
        public string desc { get; set; }
        public ResultDataCheckSellModel data { get; set; }
    }
    public class ResultDataCheckSellModel
    {
        public int id { get; set; }
        public int ticketId { get; set; }
        public int tokenId { get; set; }
        public string elemental { get; set; }
        public string elemental2 { get; set; }
        public string elemental3 { get; set; }
        [JsonPropertyName("class")]
        public string Class { get; set; }
        public string rarity { get; set; }
        public int skillActiveId { get; set; }
        public int skillPassiveId { get; set; }
        public string ownerId { get; set; }
        public string ownerIdOffer { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string view { get; set; }
        public int level { get; set; }
        public double percentLevelUp { get; set; }
        public string eyes { get; set; }
        public string hair { get; set; }
        public string tattoo { get; set; }
        public double attack { get; set; }
        public double armor { get; set; }
        public double hp { get; set; }
        public double speed { get; set; }
        public int wings { get; set; }
        [JsonPropertyName("base")]
        public int Base { get; set; }
        public int horn { get; set; }
        public int pet { get; set; }
        public int armorItem { get; set; }
        public double pricesBNB { get; set; }
        public double pricesUSD { get; set; }
        public bool isSelling { get; set; }
        public int star { get; set; }
        public int breedCount { get; set; }
        public int spiritId { get; set; }
        public DateTime? lastBreedingTime { get; set; }
        public int momId { get; set; }
        public int dadId { get; set; }
        public int exp { get; set; }
        public double critDame { get; set; }
        public double critRate { get; set; }
        public double evasion { get; set; }
        public double energy { get; set; }
        public double energyMax { get; set; }
        public int? levelCapCurentStar { get; set; }
        public int? levelCapNextStar { get; set; }
        public int? upgradeStarUSDFee { get; set; }
        public double? upgradeStarGoldFee { get; set; }
        public List<ListSkillPassiveDto> listSkillPassiveDto { get; set; }
        public List<ListSkillActiveDto> listSkillActiveDto { get; set; }
        public double baseHp { get; set; }
        public double baseAttack { get; set; }
        public double baseArmor { get; set; }
        public double baseSpeed { get; set; }
        public string ownerRent { get; set; }
        public double feeRent { get; set; }
        public double hourEndRent { get; set; }
        public string status { get; set; }
        public DateTime? timeEndRent { get; set; }
        public DateTime? timeStartRent { get; set; }
        public DateTime? lockTime { get; set; }
    }
    public class ListSkillPassiveDto
    {
        public int id { get; set; }
        public string elemental { get; set; }
        public string rarity { get; set; }
        public string type { get; set; }
        public double percent { get; set; }
        public int effectivePeriod { get; set; }
        public string detailSkill { get; set; }
        public string attachedEffect { get; set; }
        public double percentEffect { get; set; }
        public string optionExtra { get; set; }
        public string description { get; set; }

    }
    public class ListSkillActiveDto
    {
        public int id { get; set; }
        public string roleId { get; set; }
        public string rarity { get; set; }
        public string type { get; set; }
        public double percent { get; set; }
        public int effectivePeriod { get; set; }
        public string detailSkill { get; set; }
        public string attachedEffect { get; set; }
        public double percentEffect { get; set; }
        public string optionExtra { get; set; }
        public string description { get; set; }
        public string skillId { get; set; }

    }
}
