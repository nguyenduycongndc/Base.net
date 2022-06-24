
function Start() {
    //egg
    CommonEgg = $('#checkbox1:checked').val() != undefined ? true : false;
    UnCommonEgg = $('#checkbox2:checked').val() != undefined ? true : false;
    RareEgg = $('#checkbox3:checked').val() != undefined ? true : false;
    EpicEgg = $('#checkbox4:checked').val() != undefined ? true : false;
    LengendEgg = $('#checkbox5:checked').val() != undefined ? true : false;
    MythicEgg = $('#checkbox6:checked').val() != undefined ? true : false;
    //hero
    CommonHero = $('#checkbox000:checked').val() != undefined ? true : false;
    MaleCommonHero = $('#checkboxsex001:checked').val() != undefined ? true : false;
    FemaleCommonHero = $('#checkboxsex008:checked').val() != undefined ? true : false;

    UnCommonHero = $('#checkbox100:checked').val() != undefined ? true : false;
    MaleUnCommonHero = $('#checkboxsex101:checked').val() != undefined ? true : false;
    FemaleUnCommonHero = $('#checkbox108:checked').val() != undefined ? true : false;


    RareHero = $('#checkbox200:checked').val() != undefined ? true : false;
    MaleRareHero = $('#checkbox201:checked').val() != undefined ? true : false;
    FemaleRareHero = $('#checkbox208:checked').val() != undefined ? true : false;

    EpicHero = $('#checkbox300:checked').val() != undefined ? true : false;
    MaleEpicHero = $('#checkbox301:checked').val() != undefined ? true : false;
    FemaleEpicHero = $('#checkbox308:checked').val() != undefined ? true : false;

    LengendHero = $('#checkbox400:checked').val() != undefined ? true : false;
    MaleLengendHero = $('#checkbox401:checked').val() != undefined ? true : false;
    FemaleLengendHero = $('#checkbox408:checked').val() != undefined ? true : false;

    MythicHero = $('#checkbox500:checked').val() != undefined ? true : false;
    MaleMythicHero = $('#checkbox501:checked').val() != undefined ? true : false;
    FemaleMythicHero = $('#checkbox508:checked').val() != undefined ? true : false;

    if (CommonEgg == true && $('#Zen1').val() == "") {
        toastr.error("Vui lòng nhập giá trứng đã chọn");
        return;
    } else if (CommonEgg != true && $('#Zen1').val() != "") {
        toastr.error("Vui lòng chọn trứng đã nhập giá mua");
        return;
    }
    if (UnCommonEgg == true && $('#Zen2').val() == "") {
        toastr.error("Vui lòng nhập giá trứng đã chọn");
        return;
    } else if (UnCommonEgg != true && $('#Zen2').val() != "") {
        toastr.error("Vui lòng chọn trứng đã nhập giá mua");
        return;
    }
    if (RareEgg == true && $('#Zen3').val() == "") {
        toastr.error("Vui lòng nhập giá trứng đã chọn");
        return;
    } else if (RareEgg != true && $('#Zen3').val() != "") {
        toastr.error("Vui lòng chọn trứng đã nhập giá mua");
        return;
    }
    if (EpicEgg == true && $('#Zen4').val() == "") {
        toastr.error("Vui lòng nhập giá trứng đã chọn");
        return;
    } else if (EpicEgg != true && $('#Zen4').val() != "") {
        toastr.error("Vui lòng chọn trứng đã nhập giá mua");
        return;
    }
    if (LengendEgg == true && $('#Zen5').val() == "") {
        toastr.error("Vui lòng nhập giá trứng đã chọn");
        return;
    } else if (LengendEgg != true && $('#Zen5').val() != "") {
        toastr.error("Vui lòng chọn trứng đã nhập giá mua");
        return;
    }
    if (MythicEgg == true && $('#Zen6').val() == "") {
        toastr.error("Vui lòng nhập giá trứng đã chọn");
        return;
    } else if (MythicEgg != true && $('#Zen6').val() != "") {
        toastr.error("Vui lòng chọn trứng đã nhập giá mua");
        return;
    }
    var Egg = {
        'RarityEggCommon': CommonEgg == true ? "Common" : "",
        'MonneyEggCommon': $('#Zen1').val(),
        'RarityEggUnCommon': UnCommonEgg == true ? "UnCommon" : "",
        'MonneyEggUnCommon': $('#Zen2').val(),
        'RarityEggRare': RareEgg == true ? "Rare" : "",
        'MonneyEggRare': $('#Zen3').val(),
        'RarityEggEpic': EpicEgg == true ? "Epic" : "",
        'MonneyEggEpic': $('#Zen4').val(),
        'RarityEggLengend': LengendEgg == true ? "Lengend" : "",
        'MonneyEggLengend': $('#Zen5').val(),
        'RarityEggMythic': MythicEgg == true ? "Mythic" : "",
        'MonneyEggMythic': $('#Zen6').val(),
    }

    //MaleCommonHero
    MaleCommon05 = $('#checkboxsex002:checked').val() != undefined ? true : false;
    MaleCommon15 = $('#checkboxsex003:checked').val() != undefined ? true : false;
    MaleCommon25 = $('#checkboxsex004:checked').val() != undefined ? true : false;
    MaleCommon35 = $('#checkboxsex005:checked').val() != undefined ? true : false;
    MaleCommon45 = $('#checkboxsex006:checked').val() != undefined ? true : false;
    MaleCommon55 = $('#checkboxsex007:checked').val() != undefined ? true : false;
    //FemaleCommonHero
    FemaleCommon05 = $('#checkboxsex009:checked').val() != undefined ? true : false;
    FemaleCommon25 = $('#checkboxsex010:checked').val() != undefined ? true : false;
    FemaleCommon35 = $('#checkboxsex011:checked').val() != undefined ? true : false;
    FemaleCommon45 = $('#checkboxsex012:checked').val() != undefined ? true : false;
    FemaleCommon55 = $('#checkboxsex013:checked').val() != undefined ? true : false;
    if (CommonHero == true) {
        if (MaleCommonHero == true) {
            if (MaleCommon05 == true && $('#Zen000').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon05 != true && $('#Zen000').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (MaleCommon15 == true && $('#Zen001').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon15 != true && $('#Zen001').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (MaleCommon25 == true && $('#Zen002').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon25 != true && $('#Zen002').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (MaleCommon35 == true && $('#Zen003').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon35 != true && $('#Zen003').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (MaleCommon45 == true && $('#Zen004').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon45 != true && $('#Zen004').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (MaleCommon55 == true && $('#Zen005').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon55 != true && $('#Zen005').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (MaleCommon55 == true && $('#Zen005').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (MaleCommon55 != true && $('#Zen005').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
        }
        else if (FemaleCommonHero == true) {
            if (FemaleCommon05 == true && $('#Zen000').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon05 != true && $('#Zen000').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (FemaleCommon15 == true && $('#Zen001').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon15 != true && $('#Zen001').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (FemaleCommon25 == true && $('#Zen002').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon25 != true && $('#Zen002').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (FemaleCommon35 == true && $('#Zen003').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon35 != true && $('#Zen003').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (FemaleCommon45 == true && $('#Zen004').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon45 != true && $('#Zen004').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (FemaleCommon55 == true && $('#Zen005').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon55 != true && $('#Zen005').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
            if (FemaleCommon55 == true && $('#Zen005').val() == "") {
                toastr.error("Vui lòng nhập giá trứng đã chọn");
                return;
            } else if (FemaleCommon55 != true && $('#Zen005').val() != "") {
                toastr.error("Vui lòng chọn trứng đã nhập giá mua");
                return;
            }
        }
    }
   
    var MoneyMaleCommonHero = {
        'MonneyMaleHeroCommon05': $('#Zen000').val(),
        'MonneyMaleHeroCommon15': $('#Zen001').val(),
        'MonneyMaleHeroCommon25': $('#Zen002').val(),
        'MonneyMaleHeroCommon35': $('#Zen003').val(),
        'MonneyMaleHeroCommon45': $('#Zen004').val(),
        'MonneyMaleHeroCommon55': $('#Zen005').val(),
    }
    var MoneyFemaleCommonHero = {
        'MonneyFemaleHeroCommon05': $('#Zen006').val(),
        'MonneyFemaleHeroCommon15': $('#Zen007').val(),
        'MonneyFemaleHeroCommon25': $('#Zen008').val(),
        'MonneyFemaleHeroCommon35': $('#Zen009').val(),
        'MonneyFemaleHeroCommon45': $('#Zen010').val(),
        'MonneyFemaleHeroCommon55': $('#Zen011').val(),
    }
    var Hero = {
        'RarityHeroCommon': CommonHero == true ? "Common" : "",
        'MaleHeroCommon': MaleCommonHero,
        'FemaleCommonHero': FemaleCommonHero,
        'MoneyMaleCommonHero': MoneyMaleCommonHero,
        'MonneyFemaleCommonHero': MoneyFemaleCommonHero,
    }
    var input = {
        Egg,
        Hero,
    }
    callApi_userservice(
        apiConfig.api.buyitem.controller,
        apiConfig.api.buyitem.action.listegghero.path,
        apiConfig.api.buyitem.action.listegghero.method,
        input, 'fnSuccess', 'msgError');
}
function fnSuccess(res) {
    var xxxx = res;
    var x = "";
}