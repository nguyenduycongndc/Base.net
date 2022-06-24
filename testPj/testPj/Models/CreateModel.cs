using System;
using System.Collections.Generic;

namespace testPj.Models
{
    public class CreateModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
    public class CreateWalletModel
    {
        public string PrivateKey { get; set; }
        public string AddressWallet { get; set; }
        public string TAU { get; set; }
        public string BNB { get; set; }
        public int IsCheck { get; set; }
    }
    public class CheckedWalletModel
    {
        public int Id { get; set; }
        public int Checked { get; set; }
    }

    public class InputWalletModel
    {
        public string PrivateKey { get; set; }
        public string AddressWallet { get; set; }
        public int IsCheck { get; set; }
    }

    public class InputBuyModel
    {
        public Egg Egg { get; set; }
        public Hero Hero { get; set; }
    }
    public class Egg
    {
        public string RarityEggCommon { get; set; }
        public string MonneyEggCommon { get; set; }
        public string RarityEggUnCommon { get; set; }
        public string MonneyEggUnCommon { get; set; }
        public string RarityEggRare { get; set; }
        public string MonneyEggRare { get; set; }
        public string RarityEggEpic { get; set; }
        public string MonneyEggEpic { get; set; }
        public string RarityEggLengend { get; set; }
        public string MonneyEggLengend { get; set; }
        public string RarityEggMythic { get; set; }
        public string MonneyEggMythic { get; set; }
    }
    public class Hero
    {
        public string RarityHeroCommon { get; set; }
        public bool MaleHeroCommon { get; set; }
        public MoneyMaleCommonHero MoneyMaleCommonHero { get; set; }
        public bool FemaleCommonHero { get; set; }
        public MonneyFemaleCommonHero MonneyFemaleCommonHero { get; set; }

        public string RarityHeroUnCommon { get; set; }
        public bool MaleUnCommonHero { get; set; }
        public MoneyMaleUnCommonHero MoneyMaleUnCommonHero { get; set; }
        public bool FemaleUnCommonHero { get; set; }
        public MonneyFemaleUnCommonHero MonneyFemaleUnCommonHero { get; set; }

        public string RarityHeroRare { get; set; }
        public bool MaleRareHero { get; set; }
        public MoneyMaleRareHero MoneyMaleRareHero { get; set; }
        public bool FemaleRareHero { get; set; }
        public MonneyFemaleRareHero MonneyFemaleRareHero { get; set; }

        public string RarityHeroEpic { get; set; }
        public bool MaleEpicHero { get; set; }
        public MoneyMaleEpicHero MoneyMaleEpicHero { get; set; }
        public bool FemaleEpicHero { get; set; }
        public MonneyFemaleEpicHero MonneyFemaleEpicHero { get; set; }

        public string RarityHeroLengend { get; set; }
        public bool MaleLengendHero { get; set; }
        public MoneyMaleLengendHero MoneyMaleLengendHero { get; set; }
        public bool FemaleLengendHero { get; set; }
        public MonneyFemaleLengendHero MonneyFemaleLengendHero { get; set; }

        public string RarityHeroMythic { get; set; }
        public bool MaleMythicHero { get; set; }
        public MoneyMaleMythicHero MoneyMaleMythicHero { get; set; }
        public bool FemaleMythicHero { get; set; }
        public MonneyFemaleMythicHero MonneyFemaleMythicHero { get; set; }
    }
    public class MoneyMaleCommonHero
    {
        public string MonneyMaleHeroCommon05 { get; set; }
        public string MonneyMaleHeroCommon15 { get; set; }
        public string MonneyMaleHeroCommon25 { get; set; }
        public string MonneyMaleHeroCommon35 { get; set; }
        public string MonneyMaleHeroCommon45 { get; set; }
        public string MonneyMaleHeroCommon55 { get; set; }
    }
    public class MonneyFemaleCommonHero
    {
        public string MonneyFemaleHeroCommon05 { get; set; }
        public string MonneyFemaleHeroCommon15 { get; set; }
        public string MonneyFemaleHeroCommon25 { get; set; }
        public string MonneyFemaleHeroCommon35 { get; set; }
        public string MonneyFemaleHeroCommon45 { get; set; }
        public string MonneyFemaleHeroCommon55 { get; set; }
    }
    public class MoneyMaleUnCommonHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MonneyFemaleUnCommonHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MoneyMaleRareHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MonneyFemaleRareHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MoneyMaleEpicHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MonneyFemaleEpicHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MoneyMaleLengendHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MonneyFemaleLengendHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MoneyMaleMythicHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }
    public class MonneyFemaleMythicHero
    {
        public string MonneyHero05 { get; set; }
        public string MonneyHero15 { get; set; }
        public string MonneyHero25 { get; set; }
        public string MonneyHero35 { get; set; }
        public string MonneyHero45 { get; set; }
        public string MonneyHero55 { get; set; }
    }

}
