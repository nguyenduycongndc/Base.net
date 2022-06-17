/////// <reference path="customer.js" />
//<reference path="host.js" />
var apiConfig = {
    "api": {
        //"host_user_service": "https://localhost:5001",
        "host_user_service": hostApi.host_user_service,
        "user": {
            "controller": "/api/User",
            "action": {
                "getItem": {
                    "method": "GET",
                    "path": "/Detail"
                },
                "search": {
                    //function support get items by search condition
                    "method": "POST",
                    "path": "/Search"
                },
                "add": {
                    //function support to add item
                    "method": "POST",
                    "path": "/Create"
                },
                "delete": {
                    //function support to delete item
                    "method": "DELETE",
                    "path": "/Delete"
                },
                "update": {
                    //function support to update item
                    "method": "PUT",
                    "path": "/Update"
                },
                "changepassword": {
                    //function support to update item
                    "method": "PUT",
                    "path": "/ChangePassWord"
                }
            }
        },
        "roles": {
            "controller": "/Roles",
            "action": {
                "getItem": {
                    "method": "GET",
                    "path": ""
                },
                "search": {
                    //function support get items by search condition
                    "method": "GET",
                    "path": "/Search"
                },
                "add": {
                    //function support to add item
                    "method": "POST",
                    "path": ""
                },
                "delete": {
                    //function support to delete item
                    "method": "POST",
                    "path": ""
                },
                "update": {
                    //function support to update item
                    "method": "PUT",
                    "path": ""
                },
                "active": {
                    //function support to active/deactive item
                    "method": "POST",
                    "path": "/Active"
                },
                "select": {
                    //function support to changeWorkplace item
                    "method": "POST",
                    "path": "/Select"
                },
                "deleteall": {
                    //function support to changeWorkplace item
                    "method": "POST",
                    "path": "/DeleteAll"
                },
                "getpermission": {
                    //function support to changeWorkplace item
                    "method": "GET",
                    "path": "/TreePermission"
                },
                "updatepermission": {
                    //function support to changeWorkplace item
                    "method": "POST",
                    "path": "/UpdatePermission"
                },
                "rendermenu": {
                    //function support to changeWorkplace item
                    "method": "GET",
                    "path": "/Menu"
                }
            }
        }
    }
}
