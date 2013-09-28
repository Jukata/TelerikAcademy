/// <reference path="require.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="rsvp.min.js" />

define(['jquery', 'rsvp'], function ($) {
    function getJSON(serviceUrl) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: serviceUrl,
                type: "GET",
                dataType: "json",
                success: function (receivedData) {
                    resolve(receivedData);
                },
                error: function (receivedData) {
                    reject(receivedData);
                },
            });
        })

        return promise;
    }

    function postJSON(serviceUrl, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: serviceUrl,
                type: "POST",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (receivedData) {
                    resolve(receivedData);
                },
                error: function (receivedData) {
                    reject(receivedData);
                },
            });
        })
        return promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
    }
})