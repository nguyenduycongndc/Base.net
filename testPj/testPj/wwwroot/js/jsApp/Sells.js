////$("#checkAll").click(function () {
////    debugger;
////    $('.checkitem').not(this).prop('checked', this.checked);
////});
function onSearch() {
    var obj = {
        'type': $('#type').val(),
        'rarity': $('#rarity').val(),
        'IsActive': $('#IsActive').val(),
        'Wallet': $('#Wallet option').text(),
        'page_size': parseInt($("#cbPageSize").val()),
        'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
    }
    callApi_userservice(
        apiConfig.api.sells.controller,
        apiConfig.api.sells.action.search.path,
        apiConfig.api.sells.action.search.method,
        obj, 'fnSuccess', 'msgError');
}
function fnSuccess(rspn) {
    //showLoading();
    if (rspn !== undefined && rspn !== null && rspn[0].length > 0) {
        var tbBody = $('#sellTable tbody');
        $("#sellTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn[0].length; i++) {
            var obj = rspn[0][i];
            var TT = obj.isActive == 1 ? "Túi" : "Chợ"
            var HD = obj.is_Selling == true ? "Bán" : "Ngừng bán"
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idNFT + '</td>' +
                '<td>' + obj.class + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.usd + '</td>' +//giá tau
                '<td>' + obj.tau + '</td>' +//giá tau chưa quy đổi dc
                '<td>' + obj.addressWallet + '</td>' +
                '<td>' + TT + '</td>' +
                '<td>' + HD + '</td>' +
                '<td>' + obj.sell_TAU + '</td>' +
                '<td class="text-center"><input type="checkbox" class="checkitem" name="checkitem" value="' + obj.id + '"></td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#sellTable").DataTable({
            "bPaginate": false,
            "bLengthChange": false,
            "bFilter": false,
            "bInfo": false,
            "columnDefs": [
                {
                    "targets": 0,
                    "className": "text-center",
                    "orderable": false,
                    "data": null,
                    "order": [],
                    render: function (data, type, row, meta) {

                        return meta.row + page_size + 1;
                    }
                },
                {
                    "targets": [0, 3, 10],
                    "searchable": false,
                    "orderable": false
                }],
            "order": [],
            "drawCallback": function (settings) {
                $('[data-toggle="tooltip"]').tooltip();
            },
        });
        t.on('order.dt search.dt', function () {
            t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + page_size + 1;
            });
        }).draw();
        reCalculatPagesCustom(rspn[1]);
        viewBtnActionPage();
        hideLoading();
    } else if (rspn[0] == "" || rspn[0] == null || rspn[0] == undefined) {
        var tbBody = $('#sellTable tbody');
        $("#sellTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#sellTable").DataTable({
            "bPaginate": false,
            "bLengthChange": false,
            "bFilter": false,
            "bInfo": false,
            "columnDefs": [
                {
                    "targets": 0,
                    "className": "text-center",
                    "orderable": false,
                    "data": null,
                    "order": [],
                    render: function (data, type, row, meta) {

                        return meta.row + page_size + 1;
                    }
                },
                {
                    "targets": [0, 3, 10],
                    "searchable": false,
                    "orderable": false
                }],
            "order": [],
            "drawCallback": function (settings) {
                $('[data-toggle="tooltip"]').tooltip();
            },
        });
        t.on('order.dt search.dt', function () {
            t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + page_size + 1;
            });
        }).draw();
        reCalculatPagesCustomNull();
        hideLoading();
    }
}
function onclickSubmit() {
    var obj = {};
    var _objList = $('input[class="checkitem"]:checked').map((_, el) => el.value).get();
    if (_objList.length > 1) {
        var pri = RandomPri(parseInt($('#priceNFTMin').val()), parseInt($('#priceNFTMax').val()));
         obj = {
            'listID': _objList.join(),
            'priceNFT': pri,
        }
    } else {
         obj = {
            'listID': _objList.join(),
            'priceNFT': $('#priceNFT').val(),
        }
    }
    callApi_userservice(
        apiConfig.api.sells.controller,
        apiConfig.api.sells.action.listNTFSell.path,
        apiConfig.api.sells.action.listNTFSell.method,
        obj, 'onSelectSuccess', 'msgError');
}
function SellNFT() {
    var _objList = $('input[class="checkitem"]:checked').map((_, el) => el.value).get();
    if (_objList.length > 1) {
        $('#muntill').show();
        $('#one').hide();
    } else {
        $('#one').show();
        $('#muntill').hide();
    }
}
function RandomPri(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
}


function onSelectSuccess(rs) {
    var xxxxx = rs;
}