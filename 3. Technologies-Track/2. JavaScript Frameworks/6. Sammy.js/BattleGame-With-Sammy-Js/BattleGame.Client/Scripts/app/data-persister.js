/// <reference path="../libs/class.js" />
/// <reference path="../libs/crypto.js" />
/// <reference path="../libs/http-requester.js" />

define(["httpRequester", "crypto", "class"], function (httpRequester, CryptoJS, Class) {

    var nickname = localStorage.getItem("battle-game-nickname");
    var sessionKey = localStorage.getItem("battle-game-sessionKey");

    function saveUserData(nicknameToSave, sessionKeyToSave) {
        nickname = nicknameToSave;
        sessionKey = sessionKeyToSave;
        localStorage.setItem("battle-game-nickname", nickname);
        localStorage.setItem("battle-game-sessionKey", sessionKey);
    }

    function clearUserData() {
        nickname = "";
        sessionKey = "";
        localStorage.removeItem("battle-game-nickname");
        localStorage.removeItem("battle-game-sessionKey");
    }

    var MainPersister = Class.create({
        init: function (url) {
            //http://localhost../api
            this.rootUrl = url;
            this.user = new UserPersister(url);
            this.games = new GamePersister(url);
            this.battle = new BattlePersister(url);
        },
        isUserLoggedIn: function () {
            if (nickname && sessionKey) {
                return true;
            }
            else {
                return false;
            }
        },
        getNickname: function () {
            return nickname;
        },
        clearUserData: function () {
            clearUserData();
        },
    });

    var UserPersister = Class.create({
        init: function (url) {
            this.rootUrl = url + "/user";
        },
        register: function (username, nickname, password) {
            var url = this.rootUrl + "/register";

            var data = {
                username: username.toLowerCase(),
                nickname: nickname,
                authCode: CryptoJS.SHA1(password).toString(),
            };

            var promise = httpRequester.postJSON(url, data).then(
                function (data) {
                    saveUserData(data.nickname, data.sessionKey)
                    return data;
                });

            return promise;
        },
        login: function (username, password) {
            var url = this.rootUrl + "/login"

            var data = {
                username: username.toLowerCase(),
                authCode: CryptoJS.SHA1(password).toString(),
            }

            var promise = httpRequester.postJSON(url, data).then(
                function (data) {
                    saveUserData(data.nickname, data.sessionKey);
                    return data;
                }
            );

            return promise;
        },
        logout: function () {
            var url = this.rootUrl + "/logout/" + sessionKey;
            if (sessionKey && nickname) {
                clearUserData();
                return httpRequester.putJSON(url, "");
            }
        },
        scores: function () {
            var url = this.rootUrl + "/scores/" + sessionKey;
            return httpRequester.getJSON(url);
        }
    });

    var GamePersister = Class.create({
        init: function (url) {
            this.rootUrl = url + "/game";
        },
        create: function (title, password) {
            var url = this.rootUrl + "/create/" + sessionKey;

            var data = {
                title: title,
            };

            if (password) {
                data.password = CryptoJS.SHA1(password).toString();;
            }

            return httpRequester.postJSON(url, data);
        },
        join: function (id, password) {
            var url = this.rootUrl + "/join/" + sessionKey;

            var data = {
                id: id,
            };

            if (password) {
                data.password = CryptoJS.SHA1(password).toString();;
            }

            return httpRequester.postJSON(url, data);
        },
        start: function (gameId) {
            var url = this.rootUrl + "/" + gameId + "/start/" + sessionKey;
            return httpRequester.putJSON(url);
        },
        open: function () {
            var url = this.rootUrl + "/open/" + sessionKey;
            return httpRequester.getJSON(url);
        },
        active: function () {
            var url = this.rootUrl + "/my-active/" + sessionKey;
            return httpRequester.getJSON(url);
        },
        field: function (gameId) {
            var url = this.rootUrl + "/" + gameId + "/field/" + sessionKey;
            return httpRequester.getJSON(url);
        },
    });

    var BattlePersister = Class.create({
        init: function (url) {
            this.rootUrl = url + "/battle";
        },
        move: function (gameId, unitId, position) {
            var url = this.rootUrl + "/" + gameId + "/move/" + sessionKey;

            var data = {
                unitId: unitId,
                position: position
            };

            return httpRequester.postJSON(url, data);
        },
        attack: function (gameId, unitId, position) {
            var url = this.rootUrl + "/" + gameId + "/attack/" + sessionKey;

            var data = {
                unitId: unitId,
                position: position,
            };

            return httpRequester.postJSON(url, data);
        },
        defend: function (gameId, unitId) {
            var url = this.rootUrl + "/" + gameId + "/defend/" + sessionKey;
            return httpRequester.postJSON(url, unitId);
        },
    });

    return {
        getPersister: function (url) {
            return new MainPersister(url);
        }
    }
})