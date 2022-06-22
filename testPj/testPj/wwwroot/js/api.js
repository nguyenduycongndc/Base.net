function callApi_userservice(controller, action, method, data, callbackSuccess, callbackError) {
    debugger;
    $.ajax({
        type: method,
        url: apiConfig.api.host_user_service + controller + action,
        contentType: "application/json; charset=utf-8",
        data: (method == 'GET' ? data : JSON.stringify(data)),
        success: function (result) {
            if (window[callbackSuccess] != undefined)
                window[callbackSuccess](result);
        },
        error: function (request, status, error) {
            if (window[callbackError] != undefined)
                window[callbackError](request, status, error);
        }
    });
}function callApi_nft(controller, action, method, data, callbackSuccess, callbackError) {
            debugger;
    $.ajax({
        headers: {
            "x-api-key": "TJTpWG4Q9YdlE4Zh"},
        type: method,
        //url: apiNftConfig.apinft.host_nft + controller + action,
        url: apiConfig.apinft.host_nft + controller + action,
        contentType: "application/json; charset=utf-8",
        data: (method == 'GET' ? data : JSON.stringify(data)),
        success: function (result) {
            debugger;
            if (window[callbackSuccess] != undefined)
                window[callbackSuccess](result);
        },
        error: function (request, status, error) {
            debugger;
            if (window[callbackError] != undefined)
                window[callbackError](request, status, error);
        }
    });
}