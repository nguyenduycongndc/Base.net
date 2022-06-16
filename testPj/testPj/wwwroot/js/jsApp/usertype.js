function callApi_multipleselect(selector, placeholder) {
    $("#" + selector).select2({
        placeholder: placeholder,
        minimumInputLength: 0,
        multiple: true,
        closeOnSelect: true,
        ajax: {
            headers: { "Authorization": "Bearer " + sessionStorage['SessionToken'] },
            url: apiConfig.api.host_user_service + apiConfig.api.systemusergroup.controller + apiConfig.api.systemusergroup.action.select.path,
            dataType: 'json',
            data: function (params) {
                var query = {
                    q: params.term,
                    type: 'public'
                }
                return query;
            },
            processResults: function (data) {
                return {
                    results: $.map(data.data, function (item) {
                        return {
                            text: item.full_name,
                            id: item.id
                        }
                    })
                };
            },
            cache: true
        }
    });
}


function fnDeleteSuccess(rspn) {
    swal({
        title: "Thông báo",
        text: 'Bạn có chắc chắn muốn xoá bản ghi' + ' ' + '"' + rspn.fullName + '"',
        type: 'warning',
        showCancelButton: !0,
    //}, function (isConfirm) {
    //    if (isConfirm) {
    //        fnDeleteUser(rspn.id);
    //    }
    }).then((isConfirm) => {
        if (isConfirm) {
            fnDeleteUser(rspn.id);
        }
        return false;
    });;
}
function Delete(id) {
    fnGetDetail(null, id);
}
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function UnitTypeActive(id, input) {
    var status = 1;
    //if ($(input).hasClass("active")) {
    if ($(input).prop("checked") == false) {
        status = 0;
    }
    fnActive(id, status);
}
function updateUnitTypeSuccess(data) {
    if (data != false) {
        toastr.success("Thêm mới thành công");
        //createdLog("Loại đơn vị", "Chỉnh sửa loại đơn vị");
        //toastr.success(localizationResources.Successfully, { progressBar: true })
        //localStorage.removeItem("id");
        //localStorage.removeItem("type");
        //setTimeout(function () {
        //    window.location.href = "/UnitType"
        //}, 2000);
        setTimeout(function () {
            openView(0, 0)
        }, 2000);
    }
    else {
        toastr.error("Thêm mới thất bại");
        //setTimeout(function () { toastr.error(getStatusCode(data.code), 'Error', { progressBar: true }) }, 70);
    }
}
function createUserSuccess(data) {
    if (data !== false) {
        /*createdLog("Loại đơn vị", "Thêm mới loại đơn vị");*/
        toastr.success("Thêm mới thành công");
        //localStorage.removeItem("id");
        //localStorage.removeItem("type");
        setTimeout(function () {
            openView(0, 0)
        }, 2000);
    }
    else {
        toastr.error("Thêm mới thất bại")
        //setTimeout(function () { toastr.error(getStatusCode(data.code), 'Error', { progressBar: true }) }, 50);
    }
}
function updateFail(request, status, error) {
    toastr.error("Lưu dữ liệu thất bại!")
}

function validateObj(obj) {
    if (obj.name.isBlank()) {
        swal("Lỗi dữ liệu!", "Tên hoạt động không được để trống!", "error");
        return false;
    }

    return true;
}
function fnDeleteUserSuccess(rspn) {
    if (rspn === true) {
        toastr.success("Xóa dữ liệu thành công");
        onSearch();
    }
    else {
        toastr.error("Xóa dữ liệu thất bại");
    }

}
//function fnActiveSuccess(rspn) {
//    if (rspn.code === '1' && rspn.data.status == true) {
//        toastr.success(localizationResources.Active, null, { progressBar: true });
//        onSearch();
//    } else if (rspn.code === '1' && rspn.data.status == false) {
//        toastr.success(localizationResources.InActive, null, { progressBar: true });
//        onSearch();
//    }
//    else {
//        setTimeout(function () { toastr.error(getStatusCode(rspn.code), 'Error', { progressBar: true }) }, 100);
//    }
//}

function clickMenu() {
    openView(0, 0);
    localStorage.removeItem("id");
    localStorage.removeItem("type");
}

function openView(type, value) {
    var index = $("#view");
    var create = $("#create");
    var edit = $("#edit");
    var detail = $("#detail");
    if (type === 0) {
        //localStorage.removeItem("id");
        //localStorage.removeItem("type");
        index.show();
        create.hide();
        edit.hide();
        detail.hide();
        setTimeout(function () {
            onSearch();
        }, 100);
    }
    else if (type === 1) {
        clearMsgInvalid();
        localStorage.setItem("type", "1");
        index.hide();
        create.show();
        document.getElementById("userNameCreate").focus();
        edit.hide();
        detail.hide();
        document.getElementById("formCreate").reset();
        $("#frmHeaderCreate").val(frmHeaderCreate);
    }
    else if (type === 2) {
        index.hide();
        create.hide();
        edit.hide();
        detail.show();

        fnGetDetail(type, value);
    }
    else if (type === 3) {
        clearMsgInvalid();
        index.hide();
        create.hide();
        edit.show();
        document.getElementById("userNameEdit").focus();
        detail.hide();
        fnGetDetail(type, value);
    }
}

function fnSearchSuccess(rspn) {
    //showLoading();
    if (rspn !== undefined && rspn !== null && rspn[0].length > 0) {
        var tbBody = $('#userTypeTable tbody');
        $("#userTypeTable").dataTable().fnDestroy();
        tbBody.html('');
        for (var i = 0; i < rspn[0].length; i++) {
            var obj = rspn[0][i];
            var TT = obj.isActive == 1 ? "Hoạt động" : "Dừng hoạt động"
            var html = '<tr>' +
                '<td class="text-center"></td>' +
                '<td>' + obj.fullName + '</td>' +
                '<td>' + obj.userName + '</td>' +
                '<td>' + TT + '</td>' +
                '<td class="text-center">' +
                //mở lại comment khi có quyền
                //(IsCheckPemission('M_UT', 'PER_STATUS') === true && obj.roleId !== 1 ? '<div class="custom-control custom-switch"><input type="checkbox" class="custom-control-input" id="customSwitch' + obj.id + '" ' + (obj.status === true ? 'checked' : '') + ' onclick="UnitTypeActive(' + obj.id + ',this)"> <label class="custom-control-label" for="customSwitch' + obj.id + '"> <a hidden>' + obj.status + '<a></label> </div>' : '<div class="custom-control custom-switch"> <input type="checkbox" class="custom-control-input" id="customSwitch' + obj.id + '" ' + (obj.status === true ? 'checked' : '') + ' disabled ><label class="custom-control-label" for="customSwitch' + obj.id + '"></label> </div>')
                //+
                //'</td>' +

                //'<td>' + obj.description + '</td>' +
                //'<td class="text-center col-action">' +
                //(IsCheckPemission('M_UT', 'PER_DETAIL') === true ?
                //    '<a type="button" class="btn icon-default btn-action-custom" onclick="openView(2,' + obj.id + ')"><i data-toggle="tooltip" title="Chi tiết" class="fa fa-eye" aria-hidden="true"></i></a>' :
                //    '<a type="button" class="btn icon-disabled btn-action-custom"><i data-toggle="tooltip" title="Xem chi tiết" class="fa fa-eye" aria-hidden="true" ></i></a>')
                //+
                //(IsCheckPemission('M_UT', 'PER_EDIT') === true && obj.roleId !== 1 ?
                //    '<a type="button" class="btn icon-default btn-action-custom" onclick="openView(3,' + obj.id + ')"><i data-toggle="tooltip" title="Cập nhật" class="fas fa-pencil-alt" aria-hidden="true"></i></a>' :
                //    '<a type="button" class="btn icon-disabled btn-action-custom"><i data-toggle="tooltip" title="Cập nhật dữ liệu" class="fas fa-pencil-alt" aria-hidden="true"></i></a>')
                //+
                //(IsCheckPemission('M_UT', 'PER_DEL') === true && obj.roleId !== 1 ?
                //    '<a type="button" class="btn icon-delete btn-action-custom" onclick="Delete(' + obj.id + ')"><i data-toggle="tooltip" title="Xóa" class="fa fa-trash" aria-hidden="true" ></i></a>' :
                //    '<a type="button" class="btn icon-disabled btn-action-custom" ><i data-toggle="tooltip" title="Xóa" class="fa fa-trash" aria-hidden="true" ></i></a>')
                //+
                ////mở lại comment khi có quyền

                '<a type="button" class="btn icon-default btn-action-custom" onclick="openView(2,' + obj.id + ')"><i data-toggle="tooltip" title="Chi tiết" class="fa fa-eye" aria-hidden="true"></i></a>' +
                '<a type="button" class="btn icon-default btn-action-custom" onclick="openView(3,' + obj.id + ')"><i data-toggle="tooltip" title="Cập nhật" class="micon dw dw-edit2" aria-hidden="true"></i></a>' +
                '<a type="button" class="btn icon-delete btn-action-custom" onclick="Delete(' + obj.id + ')"><i data-toggle="tooltip" title="Xóa" class="fa fa-trash" aria-hidden="true"></i></a>' +
                '</td>' +
                '</tr>';
            tbBody.append(html);
        }
        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#userTypeTable").DataTable({
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

        //$("#userTypeTable").dataTable({
        //    "bPaginate": false,
        //    "bLengthChange": false,
        //    "bFilter": false,
        //    "bInfo": false,
        //    "columnDefs": [
        //        //{
        //        //    "targets": 0,
        //        //    "className": "text-center",
        //        //    "sortable": false,
        //        //    "orderable": false,
        //        //    "data": rspn.total,
        //        //    render: function (data, type, row, meta) {
        //        //        return meta.row + meta.settings._iDisplayStart + 1;
        //        //    }
        //        //},
        //        {
        //            "targets": [0, 3, 4],
        //            "searchable": false,
        //            "orderable": false
        //        }],
        //    "order": [],
        //    "drawCallback": function (settings) {
        //        $('[data-toggle="tooltip"]').tooltip();
        //    },
        //});
        reCalculatPagesCustom(rspn[1]);
        viewBtnActionPage();
        hideLoading();
    } else if (rspn[0] == "" || rspn[0] == null || rspn[0] == undefined) {
        var tbBody = $('#userTypeTable tbody');
        $("#userTypeTable").dataTable().fnDestroy();
        tbBody.html('');

        var page_size = (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
        var t = $("#userTypeTable").DataTable({
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
        //$("#userTypeTable").dataTable({
        //    "bPaginate": false,
        //    "bLengthChange": false,
        //    "bFilter": false,
        //    "bInfo": false,
        //    "columnDefs": [
        //        //{
        //        //    "targets": 0,
        //        //    "className": "text-center",
        //        //    "sortable": false,
        //        //    "orderable": false,
        //        //    "data": null,
        //        //    render: function (data, type, row, meta) {
        //        //        return meta.row + meta.settings._iDisplayStart + 1;
        //        //    }
        //        //},
        //        {
        //            "targets": [0, 3, 4],
        //            "searchable": false,
        //            "orderable": false
        //        }],
        //    "order": [[0, 'asc']],
        //    "drawCallback": function (settings) {
        //        $('[data-toggle="tooltip"]').tooltip();
        //    },
        //});
        reCalculatPagesCustomNull();
        hideLoading();
    }
}
function onSearch() {
    var obj = {
        'UserName': $('#UserName').val().trim(),
        'IsActive': $('#IsActive').val(),
        'page_size': parseInt($("#cbPageSize").val()),
        'start_number': (parseInt($("#txtCurrentPage").val()) - 1) * parseInt($("#cbPageSize").val())
    }
    callApi_userservice(
        apiConfig.api.user.controller,
        apiConfig.api.user.action.search.path,
        apiConfig.api.user.action.search.method,
        obj, 'fnSearchSuccess', 'msgError');
}


function fnDeleteUser(id) {
    callApi_userservice(
        apiConfig.api.user.controller,
        apiConfig.api.user.action.delete.path + "?id=" + id,
        apiConfig.api.user.action.delete.method,
        null, 'fnDeleteUserSuccess', 'msgError');
}
function fnActive(id, status) {
    var obj = {
        'id': id,
        'status': status,
    }
    callApi_userservice(
        apiConfig.api.user.controller,
        apiConfig.api.user.action.active.path,
        apiConfig.api.user.action.active.method,
        obj, 'fnActiveSuccess', 'msgError');
}
function submitCreate() {
    var obj = {
        'UserName': $('#userNameCreate').val().trim(),
        'RoleId': $('#roleCreate').val(),
        'Password': $('#passwordCreate').val() != '' ? $('#passwordCreate').val().trim() : '',
    }
    if (validateRequired('#formCreate')) {
        callApi_userservice(
            apiConfig.api.user.controller,
            apiConfig.api.user.action.add.path,
            apiConfig.api.user.action.add.method,
            obj, 'createUserSuccess', 'msgError');
    }
}

function submitEdit() {
    var obj = {
        'id': parseInt($('#IdEdit').val()),
        'UserName': $('#userNameEdit').val().trim(),
        'Name': $('#NameEdit').val().trim(),
        //'Role': parseInt($('#roleEdit').val()),
        'Email': $('#emailEdit').val() != "" ? $('#emailEdit').val().trim() : "",
    }
    if (validateRequired('#formEdit')) {
        callApi_userservice(
            apiConfig.api.user.controller,
            apiConfig.api.user.action.update.path,
            apiConfig.api.user.action.update.method,
            obj, 'updateUnitTypeSuccess', 'msgError');
    }
}
function fnGetDetail(type, param) {
    var call_back = '';
    if (type === 3) {
        call_back = 'fnEditSuccess';
    }
    else if (type === 2) {
        call_back = 'fnGetDetailSuccess';
    }
    else {
        call_back = 'fnDeleteSuccess';
    }
    localStorage.removeItem("id");
    localStorage.removeItem("type");
    callApi_userservice(
        apiConfig.api.user.controller,
        apiConfig.api.user.action.getItem.path + "?id=" + param,
        apiConfig.api.user.action.getItem.method,
        null, call_back, 'msgError');
}

function fnGetDetailSuccess(rspn) {
    debugger
    var frmModify = $("#formDetail");
    if (rspn !== undefined && rspn !== null) {

        frmModify.find("#IdDetail").val(rspn.id);
        frmModify.find("#userNameDetail").val(rspn.userName);

        frmModify.find("#NameDetail").val(rspn.fullName);
        frmModify.find("#isActiveDetail").val(rspn.isActive);

        frmModify.find("#roleDetail").val(rspn.roleId);
        frmModify.find("#emailDetail").val(rspn.email);

        //frmModify.find("#StatusDetail").val(data.status == true ? 1 : 0);

    }
}
function fnEditSuccess(rspn) {
    localStorage.removeItem("id");
    localStorage.removeItem("type");
    var frmModify = $("#formEdit");

    if (rspn !== undefined && rspn !== null) {

        frmModify.find("#IdEdit").val(rspn.id);
        frmModify.find("#userNameEdit").val(rspn.userName);
        frmModify.find("#isActiveEdit").val(rspn.isActive);
        frmModify.find("#NameEdit").val(rspn.fullName);
        frmModify.find("#roleEdit").val(rspn.roleId);
        frmModify.find("#emailEdit").val(rspn.email);

        //localStorage.setItem("id", $('#IdEdit').val());
        //localStorage.setItem("type", "3");
    }
}

//function createdLog(_module, _perform_tasks) {

//    var obj = {
//        'module': _module,
//        'perform_tasks': _perform_tasks,
//    }
//    callApi_userservice(
//        apiConfig.api.systemlog.controller,
//        apiConfig.api.systemlog.action.add.path,
//        apiConfig.api.systemlog.action.add.method,
//        obj, '', '');
//}

window.onload = function () {
    //let checkLocalStatus = localStorage.getItem('status');
    //if (checkLocalStatus == null) {
    //    localStorage.setItem('status', "-1");
    //}
    let checkLocalType = localStorage.getItem('type');
    let type = parseInt(checkLocalType);
    let checkLocalId = localStorage.getItem('id');
    let id = parseInt(checkLocalId);
    if (checkLocalType === null && checkLocalId === null) {
        type = 0;
        id = 0;
    }
    setTimeout(function () {
        openView(type, id);
    }, 100);

}