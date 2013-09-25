/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />

var services = (function () {

    var nickname = localStorage.getItem("bulls-cows-game-nickname");
    var sessionKey = localStorage.getItem("bulls-cows-game-sessionKey");

    function setUserData(nicknameParam, sessionKeyParam) {
        nickname = nicknameParam;
        sessionKey = sessionKeyParam;
        localStorage.setItem("bulls-cows-game-nickname", nickname);
        localStorage.setItem("bulls-cows-game-sessionKey", sessionKey);
    }

    function clearUserData() {
        nickname = "";
        sessionKey = "";
        localStorage.removeItem("bulls-cows-game-nickname");
        localStorage.removeItem("bulls-cows-game-sessionKey");
    }

    var MainService = Class.create({
        init: function (url) {
            //http://localhost:22954/api/
            this.rootUrl = url;
            this.user = new UserService(url);
            this.game = new GameService(url);
            this.battle = new BattleService(url);
            this.messages = new MessageService(url);
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

    var UserService = Class.create({
        init: function (url) {
            this.rootUrl = url + "user/";
        },
        register: function (userData, successHandler, errorHandler) {
            var url = this.rootUrl + "register/"
            var user = {
                username: userData.username,
                nickname: userData.nickname,
                authCode: CryptoJS.SHA1(userData.username + userData.password).toString(),
            }
            httpRequester.postJSON(url, user, function (receivedData) {
                setUserData(receivedData.nickname, receivedData.sessionKey);
                successHandler(receivedData);
            }, errorHandler);
        },
        login: function (userData, successHandler, errorHandler) {
            var url = this.rootUrl + "login/"
            var user = {
                username: userData.username,
                authCode: CryptoJS.SHA1(userData.username + userData.password).toString(),
            }

            httpRequester.postJSON(url, user, function (receivedData) {
                setUserData(receivedData.nickname, receivedData.sessionKey);
                successHandler(receivedData);
            }, errorHandler);
        },
        logout: function (successHandler, errorHandler) {
            var url = this.rootUrl + "logout/" + sessionKey;
            httpRequester.getJSON(url, function (receivedData) {
                clearUserData();
                successHandler(receivedData);
            }, function (receivedData) {
                clearUserData();
                errorHandler(receivedData);
            });
        },
        scores: function (successHandler, errorHandler) {
            var url = this.rootUrl + "scores/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
    });

    var GameService = Class.create({
        init: function (url) {
            this.rootUrl = url + "game/";
        },
        create: function (gameData, successHandler, errorHandler) {
            var url = this.rootUrl + "create/" + sessionKey;
            var game = {
                title: gameData.title,
            }
            if (gameData.password) {
                game.password = CryptoJS.SHA1(gameData.password).toString();
            }
            httpRequester.postJSON(url, game, successHandler, errorHandler);
        },
        join: function (gameData, successHandler, errorHandler) {
            var url = this.rootUrl + "join/" + sessionKey;
            var game = {
                id: gameData.id,
            }
            if (gameData.password) {
                game.password = CryptoJS.SHA1(gameData.password).toString();
            }
            httpRequester.postJSON(url, game, successHandler, errorHandler);
        },
        start: function (gameData, successHandler, errorHandler) {
            var url = this.rootUrl + gameData.id + "/start/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
        field: function (gameData, successHandler, errorHandler) {
            var url = this.rootUrl + gameData.gameId + "/field/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
        open: function (successHandler, errorHandler) {
            var url = this.rootUrl + "open/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
        active: function (successHandler, errorHandler) {
            var url = this.rootUrl + "my-active/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
    });

    var BattleService = Class.create({
        init: function (url) {
            this.rootUrl = url + "battle/";
        },
        move: function (gameData, successHandler, errorHandler) {
            var url = this.rootUrl + gameData.gameId + "/move/" + sessionKey;
            var game = {
                unitId: gameData.unitId,
                position: {
                    x: gameData.positionX,
                    y: gameData.positionY,
                },
            }
            httpRequester.postJSON(url, game, successHandler, errorHandler);
        },
        attack: function (gameData, succesHandler, errorHandler) {
            var url = this.rootUrl + gameData.gameId + "/attack/" + sessionKey;
            var game = {
                unitId: gameData.unitId,
                position: {
                    x: gameData.positionX,
                    y: gameData.positionY,
                },
            }
            httpRequester.postJSON(url, game, succesHandler, errorHandler);
        },
        defend: function (gameData, succesHandler, errorHandler) {
            var url = this.rootUrl + gameData.gameId + "/defend/" + sessionKey;
            var unitId = gameData.unitId;
            httpRequester.postJSON(url, unitId, succesHandler, errorHandler);
        },
    });

    var MessageService = Class.create({
        init: function (url) {
            this.rootUrl = url + "messages";
        },
        all: function (successHandler, errorHandler) {
            var url = this.rootUrl + "all/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
        unread: function (successHandler, errorHandler) {
            var url = this.rootUrl = "unread/" + sessionKey;
            httpRequester.getJSON(url, successHandler, errorHandler);
        },
    });

    return {
        getMainService: function (url) {
            return new MainService(url);
        }
    }
})();