function onSearch() {
    var obj = {
        'Wallet': $('#Wallet option').text(),
        'start_date': $('#FromDate').val(),
        'end_date': $('#ToDate').val(),
        'page_size': parseInt($("#cbPageSize").val()),
        'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
    }
    callApi_userservice(
        apiConfig.api.statistical.controller,
        apiConfig.api.statistical.action.search.path,
        apiConfig.api.statistical.action.search.method,
        obj, 'fnSearchSuccess', 'msgError');
}
function fnSearchSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var sumProfit = 0;
        
        var tbBody = $('#statisticalTable tbody');
        $("#statisticalTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            sumProfit += obj.profit
            var TT = obj.isCheck == 1 ? "Hoạt động" : "Dừng hoạt động"
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idNFT + '</td>' +
                '<td>' + obj.wallet + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.class + '</td>' +
                '<td>' + obj.date + '</td>' +
                '<td>' + obj.buyPrice + '</td>' +
                '<td>' + obj.sellPrice + '</td>' +
                '<td>' + obj.profit + '</td>' +
                '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var viewcounthtml = $('#SumProfit');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-3 col-lg-3 col-md-3 col-3">' +
            '<label for="walletlable1" class="col-sm-12 col-form-label" style="color: blue">' + "Tổng lợi nhuận: " + sumProfit + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#statisticalTable").DataTable({
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
                    "targets": 0,//
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
        reCalculatPagesCustom(rspn.count);
        viewBtnActionPage();
        hideLoading();
    } else if (rspn.data == "" || rspn.data == null || rspn.data == undefined) {
        var tbBody = $('#statisticalTable tbody');
        $("#statisticalTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#statisticalTable").DataTable({
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
                    "targets": 0,
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