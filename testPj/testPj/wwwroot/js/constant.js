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
        "wallet": {
            "controller": "/api/WalletManagement",
            "action": {
                "search": {
                    //function support get items by search condition
                    "method": "GET",
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
            }
        }
    }
}
