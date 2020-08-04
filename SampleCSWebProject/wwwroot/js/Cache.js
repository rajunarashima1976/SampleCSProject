"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/CacheHub").build();

connection.on("ReceiveDataUpdateNotification", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    alert("Notification Received : " + msg);
    
    if (typeof(fnRefreshDashboard) === "function") {
        fnRefreshDashboard();
    }
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});
