/// <reference path="jquery-2.0.3.js" />
/// <reference path="q.js" />

define(["jquery", "q"], function ($, Q) {

    function getJSON(serviceUrl) {
        var deffered = Q.defer();

        $.ajax({
            url: serviceUrl,
            type: "GET",
            timeout: 10000,
            dataType: "json",
            success: function (receivedData) {
                deffered.resolve(receivedData);
            },
            error: function (errorData) {
                deffered.reject(errorData);
            }
        });

        return deffered.promise;
    }

    function postJSON(serviceUrl, data) {
        var deffered = Q.defer();

        $.ajax({
            url: serviceUrl,
            type: "POST",
            timeout: 10000,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(data),
            success: function (receivedData) {
                deffered.resolve(receivedData);
            },
            error: function (errorData) {
                deffered.reject(errorData);
            }
        });

        return deffered.promise;
    }

    function putJSON(serviceUrl, data) {
        var deffered = Q.defer();

        $.ajax({
            url: serviceUrl,
            type: "PUT",
            timeout: 10000,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(data),
            success: function (receivedData) {
                deffered.resolve(receivedData);
            },
            error: function (errData) {
                deffered.reject(errData);
            }
        });

        return deffered.promise;
    }

    function getHTML(url) {
        var deffered = Q.defer();

        $.ajax({
            url: url,
            type: "GET",
            timeout: 10000,
            dataType: "html",
            success: function (receivedData) {
                deffered.resolve(receivedData);
            },
            error: function (errorData) {
                deffered.reject(errorData);
            }
        });

        return deffered.promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON,
        getHTML: getHTML,
    }
})