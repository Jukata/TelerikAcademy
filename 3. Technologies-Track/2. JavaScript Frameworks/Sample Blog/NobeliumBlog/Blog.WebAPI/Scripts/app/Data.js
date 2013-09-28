/// <reference path="../libs/_references.js" />

window.persisters = (function () {

    var displayName = $.cookie('displayName'),
        sessionKey = $.cookie('sessionKey'),
        isAdmin = $.cookie('isAdmin');

    function saveUserData(userData) {
        $.cookie('displayName', userData.displayName, { expires: 1 });
        $.cookie('sessionKey', userData.sessionKey, { expires: 1 });
        $.cookie('isAdmin', userData.isAdmin, { expires: 1 });
        displayName = userData.displayName;
        sessionKey = userData.sessionKey;
        isAdmin = userData.isAdmin;
    };

    function clearUserData() {
        $.removeCookie('displayName');
        $.removeCookie('sessionKey');
        $.removeCookie('isAdmin');
        displayName = undefined;
        sessionKey = undefined;
        isAdmin = undefined;
    };

    var MainPersister = Class.create({
        init: function (serviceUrl) {
            this.users = new UserPersister(serviceUrl + 'users/');
            this.posts = new PostPersister(serviceUrl + 'posts');
            this.tags = new TagPersister(serviceUrl + 'tags');
        }
    })

    var UserPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        register: function (username, displayName, password) {
            var url = this.serviceUrl + 'register',
                userData = {
                    username: username,
                    displayName: displayName,
                    authCode: CryptoJS.SHA1(password).toString()
                };

            return httpRequester.postJSON(url, userData)
                .then(function (data) {
                    saveUserData(data);
                    return data;
                });
        },
        login: function (username, password) {
            var url = this.serviceUrl + 'login',
                userData = {
                    username: username,
                    authCode: CryptoJS.SHA1(password).toString()
                };

            return httpRequester.postJSON(url, userData)
                .then(function (data) {
                    saveUserData(data);
                    return data;
                });
        },
        logout: function () {
            var url = this.serviceUrl + 'logout?sessionKey=' + sessionKey;
            clearUserData();

            return httpRequester.putJSON(url);
        },
        currentUser: function () {
            return displayName;
        },
        isAdmin: function () {
            return isAdmin;
        }
    })

    var PostPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        getAll: function () {
            var url = this.serviceUrl + '/all?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        },
        getMine: function () {
            var url = this.serviceUrl + '/mine?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        },
        getPostById: function (postId) {
            var url = this.serviceUrl + '/' + postId + '?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        },
        getPostsByKeyword: function (keyword) {
            var url = this.serviceUrl + '/searchposts?keyword=' + keyword + '&sessionKey=' + sessionKey;
            //var url = this.serviceUrl + '?sessionKey=' + sessionKey + '&keyword=' + keyword;
            return httpRequester.getJSON(url);
        },
        create: function (title, text, tags) {
            var url = this.serviceUrl + '?sessionKey=' + sessionKey,
                postData = {
                    title: title,
                    text: text
                };

            if (tags) {
                postData.tags = tags;//.split(',').clean('');
            }

            return httpRequester.postJSON(url, postData);
        },
        comment: function (id, text) {
            var url = this.serviceUrl + '/' + id + '/comment?sessionKey=' + sessionKey,
                commentData = {
                    text: text
                };

            return httpRequester.postJSON(url, commentData);
        },
        getAllComments: function () {
            var url = this.serviceUrl + '/allcomments?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        },
        getMyComments: function () {
            var url = this.serviceUrl + '/mycomments?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        },
        searchComments: function (keyword) {
            var url = this.serviceUrl + '/searchcomments?keyword=' + keyword + '&sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        }
    });

    var TagPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        getAll: function () {
            var url = this.serviceUrl + '?sessionKey=' + sessionKey;
            return httpRequester.getJSON(url);
        },
        getPostsByTag: function (tagId) {
            var url = this.serviceUrl + '/' + tagId + '/posts?sessionKey=' + sessionKey;
            var tags = httpRequester.getJSON(url);
            return tags;
        }
    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
}());