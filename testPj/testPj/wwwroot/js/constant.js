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
                    "method": "POST",
                    "path": "/Search"
                },
                "add": {
                    //function support to add item
                    "method": "POST",
                    "path": "/Create"
                },
                "update": {
                    //function support to add item
                    "method": "PUT",
                    "path": "/Update"
                },
                "delete": {
                    //function support to delete item
                    "method": "DELETE",
                    "path": "/Delete"
                },
                "checked": {
                    //function support to active/deactive item
                    "method": "POST",
                    "path": "/Checked"
                },
                "getItem": {
                    "method": "GET",
                    "path": "/Detail"
                }
            }
        },
        "buyitem": {
            "controller": "/api/BuyItems",
            "action": {
                "getItem": {
                    "method": "GET",
                    "path": "/Detail"
                }
            }
        },
        "sellitem": {
            "controller": "/api/SellItems",
            "action": {
                "search": {
                    //function support get items by search condition
                    "method": "POST",
                    "path": "/Search"
                },
                "getItem": {
                    "method": "GET",
                    "path": "/Detail"
                }
            }
        },
        "statistical": {
            "controller": "/api/Statistical",
            "action": {
                "search": {
                    //function support get items by search condition
                    "method": "POST",
                    "path": "/Search"
                },
                "getItem": {
                    "method": "GET",
                    "path": "/Detail"
                }
            }
        }
    },
    "apinft": {
        "host_nft": hostApi.host_amazonaws,
        "walletInfo": {
            "controller": "/api/Wallet",
            "action": {
                "getItem": {
                    "method": "GET",
                    "path": "/Info"
                },
            }
        },
    }
};
//var apiNftConfig = {
//    "apinft": {
//        "host_nft": hostApi.host_amazonaws,
//        "walletInfo": {
//            "controller": "/api/Wallet",
//            "action": {
//                "getItem": {
//                    "method": "GET",
//                    "path": "/Info"
//                },
//            }
//        },
//    }
//}
