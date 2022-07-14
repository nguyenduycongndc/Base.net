
function onSearch() {
    var Hero_Tab = $('#Hero-tab').on('show')[0].ariaSelected;
    var Item_Tab = $('#Item-tab').on('show')[0].ariaSelected;
    var Ticket_Tab = $('#Ticket-tab').on('show')[0].ariaSelected;
    var Pack_Tab = $('#Pack-tab').on('show')[0].ariaSelected;
    var Egg_Tab = $('#Egg-tab').on('show')[0].ariaSelected;
    if (Hero_Tab == "true")//hero
    {
        var obj = {
            'FromDate': $('#fromD').val(),
            'ToDate': $('#toD').val(),
            'page_size': parseInt($("#cbPageSize").val()),
            'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        }
        callApi_userservice(
            apiConfig.api.transaction.controller,
            apiConfig.api.transaction.action.searchhero.path,
            apiConfig.api.transaction.action.searchhero.method,
            obj, 'fnSearchHeroSuccess', 'msgError');
    } else if (Item_Tab == "true")//item
    {
        var obj = {
            'FromDate': $('#fromD').val(),
            'ToDate': $('#toD').val(),
            'page_size': parseInt($("#cbPageSize").val()),
            'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        }
        callApi_userservice(
            apiConfig.api.transaction.controller,
            apiConfig.api.transaction.action.searchitem.path,
            apiConfig.api.transaction.action.searchitem.method,
            obj, 'fnSearchItemSuccess', 'msgError');
    } else if (Ticket_Tab == "true")//ticket
    {
        var obj = {
            'FromDate': $('#fromD').val(),
            'ToDate': $('#toD').val(),
            'page_size': parseInt($("#cbPageSize").val()),
            'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        }
        callApi_userservice(
            apiConfig.api.transaction.controller,
            apiConfig.api.transaction.action.searchticket.path,
            apiConfig.api.transaction.action.searchticket.method,
            obj, 'fnSearchTicketSuccess', 'msgError');
    } else if (Pack_Tab == "true")//pack
    {
        var obj = {
            'FromDate': $('#fromD').val(),
            'ToDate': $('#toD').val(),
            'page_size': parseInt($("#cbPageSize").val()),
            'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        }
        callApi_userservice(
            apiConfig.api.transaction.controller,
            apiConfig.api.transaction.action.searchpack.path,
            apiConfig.api.transaction.action.searchpack.method,
            obj, 'fnSearchPackSuccess', 'msgError');
    } else if (Egg_Tab == "true")//egg
    {
        var obj = {
            'FromDate': $('#fromD').val(),
            'ToDate': $('#toD').val(),
            'page_size': parseInt($("#cbPageSize").val()),
            'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        }
        callApi_userservice(
            apiConfig.api.transaction.controller,
            apiConfig.api.transaction.action.searchegg.path,
            apiConfig.api.transaction.action.searchegg.method,
            obj, 'fnSearchEggSuccess', 'msgError');
    }

}
function fnSearchHeroSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var tbBody = $('#showListHeroTable tbody');
        $("#showListHeroTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.id_nft + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.level + '</td>' +
                '<td>' + obj.elemental + '</td>' +
                '<td>' + obj.sex + '</td>' +
                '<td>' + obj.Sell_TAU + '</td>' +
                '<td>' + obj.fee + '</td>' +
                '<td>' + obj.Time + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListHeroTable").DataTable({
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
                    "targets": [0],
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
    } else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var tbBody = $('#showListHeroTable tbody');
        $("#showListHeroTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListHeroTable").DataTable({
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
                    "targets": [0],
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
function fnSearchItemSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var tbBody = $('#showListItemTable tbody');
        $("#showListItemTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.id_nft + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.level + '</td>' +
                '<td>' + obj.Sell_TAU + '</td>' +
                '<td>' + obj.fee + '</td>' +
                '<td>' + obj.Time + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListItemTable").DataTable({
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
                    "targets": [0],
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
    } else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var tbBody = $('#showListItemTable tbody');
        $("#showListItemTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListItemTable").DataTable({
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
                    "targets": [0],
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
function fnSearchTicketSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var tbBody = $('#showListTicketTable tbody');
        $("#showListTicketTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.id_nft + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.Sell_TAU + '</td>' +
                '<td>' + obj.fee + '</td>' +
                '<td>' + obj.Time + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListTicketTable").DataTable({
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
                    "targets": [0],
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
    } else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var tbBody = $('#showListTicketTable tbody');
        $("#showListTicketTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListTicketTable").DataTable({
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
                    "targets": [0],
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
function fnSearchPackSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var tbBody = $('#showListPackTable tbody');
        $("#showListPackTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.id_nft + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.Sell_TAU + '</td>' +
                '<td>' + obj.fee + '</td>' +
                '<td>' + obj.Time + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListPackTable").DataTable({
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
                    "targets": [0],
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
    } else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var tbBody = $('#showListPackTable tbody');
        $("#showListPackTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListPackTable").DataTable({
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
                    "targets": [0],
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
function fnSearchEggSuccess(rspn) {
    if (rspn !== undefined && rspn !== null && rspn.data.length > 0) {
        var tbBody = $('#showListEggTable tbody');
        $("#showListEggTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn.data.length; i++) {
            var obj = rspn.data[i];
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.id_nft + '</td>' +
                '<td>' + obj.rarity + '</td>' +
                '<td>' + obj.Sell_TAU + '</td>' +
                '<td>' + obj.fee + '</td>' +
                '<td>' + obj.Time + '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListEggTable").DataTable({
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
                    "targets": [0],
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
    } else if (rspn == "" || rspn == null || rspn == undefined || rspn.data.length == 0) {
        var tbBody = $('#showListEggTable tbody');
        $("#showListEggTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#showListEggTable").DataTable({
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
                    "targets": [0],
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
//Export
function ExportTransaction() {
    var Hero_Tab = $('#Hero-tab').on('show')[0].ariaSelected;
    var Item_Tab = $('#Item-tab').on('show')[0].ariaSelected;
    var Ticket_Tab = $('#Ticket-tab').on('show')[0].ariaSelected;
    var Pack_Tab = $('#Pack-tab').on('show')[0].ariaSelected;
    var Egg_Tab = $('#Egg-tab').on('show')[0].ariaSelected;
    var obj = {
        'FromDate': $('#fromD').val(),
        'ToDate': $('#toD').val(),
        'page_size': parseInt($("#cbPageSize").val()),
        'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
    }
    if (Hero_Tab == "true")//hero
    {
        var jsonData = JSON.stringify(obj);
        var request = new XMLHttpRequest();
        request.responseType = "blob";
        request.open("GET", apiConfig.api.host_user_service + apiConfig.api.transaction.controller +
            apiConfig.api.transaction.action.exportexcelhero.path + "?jsonData=" + jsonData);
        request.setRequestHeader('Authorization', getSessionToken());
        request.setRequestHeader('Accept-Language', 'vi-VN');
        request.onload = function () {
            if (this.status == 200) {
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(this.response);
                link.download = "ExportFile.xlsx";
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }
            if (this.status == 404) {
                toastr.error("Không tìm thấy dữ liệu!", "Lỗi!", { progressBar: true });
            }
            if (this.status == 400) {
                toastr.error("Có lỗi xảy ra!", "Lỗi!", { progressBar: true });
            }
        }
        request.send();
    } else if (Item_Tab == "true")//item
    {
        var jsonData = JSON.stringify(obj);
        var request = new XMLHttpRequest();
        request.responseType = "blob";
        request.open("GET", apiConfig.api.host_user_service + apiConfig.api.transaction.controller +
            apiConfig.api.transaction.action.exportexcelitem.path + "?jsonData=" + jsonData);
        request.setRequestHeader('Authorization', getSessionToken());
        request.setRequestHeader('Accept-Language', 'vi-VN');
        request.onload = function () {
            if (this.status == 200) {
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(this.response);
                link.download = "ExportFile.xlsx";
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }
            if (this.status == 404) {
                toastr.error("Không tìm thấy dữ liệu!", "Lỗi!", { progressBar: true });
            }
            if (this.status == 400) {
                toastr.error("Có lỗi xảy ra!", "Lỗi!", { progressBar: true });
            }
        }
        request.send();
    } else if (Ticket_Tab == "true")//ticket
    {
       
        var jsonData = JSON.stringify(obj);
        var request = new XMLHttpRequest();
        request.responseType = "blob";
        request.open("GET", apiConfig.api.host_user_service + apiConfig.api.transaction.controller +
            apiConfig.api.transaction.action.exportexcelticket.path + "?jsonData=" + jsonData);
        request.setRequestHeader('Authorization', getSessionToken());
        request.setRequestHeader('Accept-Language', 'vi-VN');
        request.onload = function () {
            if (this.status == 200) {
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(this.response);
                link.download = "ExportFile.xlsx";
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }
            if (this.status == 404) {
                toastr.error("Không tìm thấy dữ liệu!", "Lỗi!", { progressBar: true });
            }
            if (this.status == 400) {
                toastr.error("Có lỗi xảy ra!", "Lỗi!", { progressBar: true });
            }
        }
        request.send();
    } else if (Pack_Tab == "true")//pack
    {
        
        var jsonData = JSON.stringify(obj);
        var request = new XMLHttpRequest();
        request.responseType = "blob";
        request.open("GET", apiConfig.api.host_user_service + apiConfig.api.transaction.controller +
            apiConfig.api.transaction.action.exportexcelpack.path + "?jsonData=" + jsonData);
        request.setRequestHeader('Authorization', getSessionToken());
        request.setRequestHeader('Accept-Language', 'vi-VN');
        request.onload = function () {
            if (this.status == 200) {
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(this.response);
                link.download = "ExportFile.xlsx";
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }
            if (this.status == 404) {
                toastr.error("Không tìm thấy dữ liệu!", "Lỗi!", { progressBar: true });
            }
            if (this.status == 400) {
                toastr.error("Có lỗi xảy ra!", "Lỗi!", { progressBar: true });
            }
        }
        request.send();
    } else if (Egg_Tab == "true")//egg
    {
        
        var jsonData = JSON.stringify(obj);
        var request = new XMLHttpRequest();
        request.responseType = "blob";
        request.open("GET", apiConfig.api.host_user_service + apiConfig.api.transaction.controller +
            apiConfig.api.transaction.action.exportexcelegg.path + "?jsonData=" + jsonData);
        request.setRequestHeader('Authorization', getSessionToken());
        request.setRequestHeader('Accept-Language', 'vi-VN');
        request.onload = function () {
            if (this.status == 200) {
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(this.response);
                link.download = "ExportFile.xlsx";
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }
            if (this.status == 404) {
                toastr.error("Không tìm thấy dữ liệu!", "Lỗi!", { progressBar: true });
            }
            if (this.status == 400) {
                toastr.error("Có lỗi xảy ra!", "Lỗi!", { progressBar: true });
            }
        }
        request.send();
    }
}
