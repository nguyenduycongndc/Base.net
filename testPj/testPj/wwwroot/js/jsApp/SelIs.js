function onSearch() {
    var obj = {
        'type': $('#type').val(),
        'rarity': $('#rarity').val(),
        'IsActive': $('#IsActive').val(),
        'AddressWallet': $('#Wallet').val(),
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
            //var TT = obj.isActive == 1 ? "Hoạt động" : "Dừng hoạt động"
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idnft + '</td>' +
                '<td>' + obj.class + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.tau + '</td>' +
                '<td>' + obj.usd + '</td>' +
                '<td>' + obj.sell_tau + '</td>' +
                '<td>' + obj.addressWallet + '</td>' +
                '<td>' + obj.isActive + '</td>' +
                '<td>' + obj.is_Selling + '</td>' +
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
                    "targets": [0, 3, 4],
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
                    "targets": [0, 3, 4],
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
$("#checkAll").click(function () {
    $('.checkitem').not(this).prop('checked', this.checked);
});