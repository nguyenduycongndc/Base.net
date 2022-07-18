
function openView(type, value) {
    var index = $("#view");
    var detail = $("#detail");
    if (type === 0) {
        index.show();
        detail.hide();
        setTimeout(function () {
            onSearch();
        }, 100);
    }
    else if (type === 1) {
        index.hide();
        detail.show();
        callApi_userservice(
            apiConfig.api.user.controller,
            apiConfig.api.user.action.getItem.path + "?id=" + value,
            apiConfig.api.user.action.getItem.method,
            null, fnGetDetailSuccess, 'msgError');
    }
}
function fnGetDetailSuccess(rspn) {
    var frmDetail = $("#formDetail");
    if (rspn !== undefined && rspn !== null) {
        frmDetail.find("#IdDetail").val(rspn.id);
        //frmDetail.find("#userNameDetail").val(rspn.userName);
        //frmDetail.find("#NameDetail").val(rspn.fullName);
        //frmDetail.find("#isActiveDetail").val(rspn.isActive);
        //frmDetail.find("#roleDetail").val(rspn.roleId);
        //frmDetail.find("#emailDetail").val(rspn.email);
        //frmDetail.find("#StatusDetail").val(data.status == true ? 1 : 0);
    }
}
function onSearch() {
    var hero_Tab = $('#hero-tab').on('show')[0].ariaSelected;
    var item_Tab = $('#item-tab').on('show')[0].ariaSelected;
    var ticket_Tab = $('#ticket-tab').on('show')[0].ariaSelected;
    var pack_Tab = $('#pack-tab').on('show')[0].ariaSelected;
    var egg_Tab = $('#egg-tab').on('show')[0].ariaSelected;
    var shard_Tab = $('#shard-tab').on('show')[0].ariaSelected;
    var Ref_Tab = $('#Ref-tab').on('show')[0].ariaSelected;

    var id = $('#IdDetail').val();
    if (id != "0") {
        if (hero_Tab == "true")//hero
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccounthero.path,
                apiConfig.api.account.action.searchaccounthero.method,
                obj, 'fnSearchAccountHeroSuccess', 'msgError');
        }
        else if (item_Tab == "true")//item
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccountitem.path,
                apiConfig.api.account.action.searchaccountitem.method,
                obj, 'fnSearchAccountItemSuccess', 'msgError');
        }
        else if (ticket_Tab == "true")//ticket
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccountticket.path,
                apiConfig.api.account.action.searchaccountticket.method,
                obj, 'fnSearchAccountTicketSuccess', 'msgError');
        }
        else if (pack_Tab == "true")//pack
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccountpack.path,
                apiConfig.api.account.action.searchaccountpack.method,
                obj, 'fnSearchAccountPackSuccess', 'msgError');
        }
        else if (egg_Tab == "true")//egg
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccountegg.path,
                apiConfig.api.account.action.searchaccountegg.method,
                obj, 'fnSearchAccountEggSuccess', 'msgError');
        }
        else if (shard_Tab == "true")//shard
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccountshard.path,
                apiConfig.api.account.action.searchaccountshard.method,
                obj, 'fnSearchAccountShardSuccess', 'msgError');
        }
        else if (Ref_Tab == "true")//Ref
        {
            var obj = {
                'text_search': $('#txtSearchDetail').val(),
                'page_size': parseInt($("#cbPageSize").val()),
                'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
            }
            callApi_userservice(
                apiConfig.api.account.controller,
                apiConfig.api.account.action.searchaccountref.path,
                apiConfig.api.account.action.searchaccountref.method,
                obj, 'fnSearchAccountRefSuccess', 'msgError');
        }
    } else {
        var obj = {
            'text_search': $('#txtSearch').val(),
            'start_date': $('#fromD').val(),
            'end_date': $('#toD').val(),
            'page_size': parseInt($("#cbPageSize").val()),
            'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        }
        callApi_userservice(
            apiConfig.api.account.controller,
            apiConfig.api.account.action.searchaccount.path,
            apiConfig.api.account.action.searchaccount.method,
            obj, 'fnSearchAccountSuccess', 'msgError');
    }
}
function fnSearchAccountSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var tbBody = $('#accountTypeTable tbody');
        $("#accountTypeTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var TT = obj.isActive == 1 ? "Hoạt động" : "Dừng hoạt động"
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.fullName + '</td>' +
                '<td>' + obj.email + '</td>' +
                '<td>' + obj.address + '</td>' +
                '<td>' + obj.createDate + '</td>' +
                '<td class="text-center">' +
                '<a type="button" class="btn icon-default btn-action-custom" onclick="openView(1,' + obj.id + ')" style="color:green"><i data-toggle="tooltip" title="Chi tiết" class="fa fa-eye" aria-hidden="true"></i></a>' +
                '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#accountTypeTable").DataTable({
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
        reCalculatPagesCustom(rspn.count);
        viewBtnActionPage();
        hideLoading();
    }
    else if (rspn.data == "" || rspn.data == null || rspn.data == undefined) {
        var tbBody = $('#accountTypeTable tbody');
        $("#accountTypeTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#accountTypeTable").DataTable({
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
function fnSearchAccountHeroSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountHero');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Hero: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#heroTable tbody');
        $("#heroTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idHero + '</td>' +
                '<td>' + obj.level + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.star + '</td>' +
                '<td>' + obj.status + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#heroTable").DataTable({
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
                    "targets": [0, 1 , 2],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountHero');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Hero: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#heroTable tbody');
        $("#heroTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#heroTable").DataTable({
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
                    "targets": [0, 1, 2],
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
function fnSearchAccountItemSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountItem');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Item: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#itemTable tbody');
        $("#itemTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idItem + '</td>' +
                '<td>' + obj.level + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.star + '</td>' +
                '<td>' + obj.status + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#itemTable").DataTable({
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
                    "targets": [0, 1 , 2],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountItem');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Item: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#itemTable tbody');
        $("#itemTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#itemTable").DataTable({
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
                    "targets": [0, 1, 2],
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
function fnSearchAccountTicketSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountTicket');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Ticket: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#ticketTable tbody');
        $("#ticketTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idTicket + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.status + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#ticketTable").DataTable({
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
                    "targets": [0, 1],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountTicket');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Ticket: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#ticketTable tbody');
        $("#ticketTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#ticketTable").DataTable({
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
                    "targets": [0, 1],
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
function fnSearchAccountPackSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountPack');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Pack: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#packTable tbody');
        $("#packTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idPack + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.status + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#packTable").DataTable({
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
                    "targets": [0, 1],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountPack');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Pack: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#packTable tbody');
        $("#packTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#packTable").DataTable({
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
                    "targets": [0, 1],
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
function fnSearchAccountEggSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountEgg');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Egg: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#eggTable tbody');
        $("#eggTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idEgg + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.status + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#eggTable").DataTable({
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
                    "targets": [0, 1],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountEgg');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Egg: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#eggTable tbody');
        $("#eggTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#eggTable").DataTable({
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
                    "targets": [0, 1],
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
function fnSearchAccountShardSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountShard');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Shard: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#shardTable tbody');
        $("#shardTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.idShard + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.amount + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#shardTable").DataTable({
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
                    "targets": [0, 1],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountShard');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Shard: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#shardTable tbody');
        $("#shardTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#shardTable").DataTable({
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
                    "targets": [0, 1],
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
function fnSearchAccountRefSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {

        var viewcounthtml = $('#CountRef');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Ref: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);


        var tbBody = $('#refTable tbody');
        $("#refTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.accountName + '</td>' +
                '<td>' + obj.address + '</td>' +
                '<td>' + obj.created + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#refTable").DataTable({
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
                    "targets": [0, 1],
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
    }
    else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var viewcounthtml = $('#CountRef');
        viewcounthtml.html('');
        var htmlCout = '<div class="col-xl-2 col-lg-2 col-md-2 col-12">' +
            '<label for="lable1" class="col-sm-12 col-form-label">' + "Total Ref: " + rspn.total_NFT + '</label>' +
            '</div>';
        viewcounthtml.append(htmlCout);
        var tbBody = $('#refTable tbody');
        $("#refTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#refTable").DataTable({
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
                    "targets": [0, 1],
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