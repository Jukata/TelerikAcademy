/// <reference path="../lib/rsvp.js" />
/// <reference path="../lib/mustache.js" />
/// <reference path="../lib/jquery-2.0.3.js" />

var Templates = (function () {

    var templates = {};

    function getLoginTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.loginTemplate) {
                resolve(templates.loginTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/login.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.loginTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    function getRegisterTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.registerTemplate) {
                resolve(templates.registerTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/register.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.registerTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    function getErrorTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.errorTemplate) {
                resolve(templates.errorTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/error.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.registerTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    function getPostTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.postTemplate) {
                resolve(templates.postTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/post.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.postTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    function getFullPostTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.fullPostTemplate) {
                resolve(templates.fullPostTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/full-post.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.fullPostTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    function getNewPostTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.newPostTemplate) {
                resolve(templates.newPostTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/new-post.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.newPostTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    function getSearchPostsTemplate() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates.searchPostsTemplate) {
                resolve(templates.searchPostsTemplate);
            }
            else {
                $.ajax({
                    url: "/Scripts/partials/search-posts.html", type: "GET", dataType: "html",
                    success: function (data) {
                        templates.searchPostsTemplate = data;
                        resolve(data);
                    },
                    error: function (errData) {
                        reject(errData);
                    }
                });
            }
        });

        return promise;
    }

    return {
        getLoginTemplate: getLoginTemplate,
        getRegisterTemplate: getRegisterTemplate,
        getErrorTemplate: getErrorTemplate,
        getPostTemplate: getPostTemplate,
        getFullPostTemplate: getFullPostTemplate,
        getNewPostTemplate: getNewPostTemplate,
        getSearchPostsTemplate: getSearchPostsTemplate,
    }
}());