/// <reference path="../libs/rsvp.min.js" />

var fakePersister = (function () {
    var sessionKey = "";
    var bashDisplayName = "";
    var fakeSessionKey = "00001XZSUfaSkOyavgvqtVamYePLxFUtuDXAiVNoMFQVuxMyGY";
    var fakeDisplayName = "baistan1";

    function saveUserData(userData) {        
        bashDisplayName = userData.displayName;
        sessionKey = userData.sessionKey;
    };

    function clearUserData() {        
        bashDisplayName = undefined;
        sessionKey = undefined;
    };

    var MainPersister = Class.create({
        init: function (serviceUrl) {
            this.users = new UserPersister(serviceUrl + 'users/');
            this.posts = new PostsPersister(serviceUrl + 'posts/');
        }
    })
    
    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            var userData = {
                displayName: fakeDisplayName,
                sessionKey: fakeSessionKey
            }
            saveUserData(userData);

            var promise = new RSVP.Promise(function (resolve, reject) {
                // succeed
                resolve(value);
                // or reject
                reject(error);
            });
            return promise;
        },
        register: function (username, displayName, password) {
            var user = {
                username: username,
                displayName: displayName,
                authCode: CryptoJS.SHA1(password).toString()
            };
            
            var userData = {
                displayName: fakeDisplayName,
                sessionKey: fakeSessionKey
            }
            saveUserData(userData);

            var promise = new RSVP.Promise(function (resolve, reject) {
                // succeed
                resolve(value);
                // or reject
                reject(error);
            });
            return promise;
        },
        logout: function () {
            if (!sessionKey) {
                //gyrmi
            }
            var headers = {
                "X-sessionKey": sessionKey
            };
            //clear sessionKey
            sessionKey = "";
            return putJSON(this.apiUrl + "logout", headers);
        },
        currentUser: function () {
            return bashUsername;
        }
    });

    var PostsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            var promise = new RSVP.Promise(function (resolve, reject) {
                var value = [
                    { "title": "sample post 1" },
                    { "title": "sample post 2" },
                ]
                resolve(value);
                // or reject
                reject(error);
            });
            return promise;
        }
    });


    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
}());