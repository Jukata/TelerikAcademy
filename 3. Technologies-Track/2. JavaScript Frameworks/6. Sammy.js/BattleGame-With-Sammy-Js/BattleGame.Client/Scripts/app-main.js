/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/require.js" />

require.config({
    paths: {
        "jquery": "libs/jquery-2.0.3.min",
        "sammy": "libs/sammy-0.7.4",
        "mustache": "libs/mustache",
        "q": "libs/q",
        "underscore": "libs/underscore",
        "class": "libs/class",
        "crypto": "libs/crypto",
        "httpRequester": "libs/http-requester",
        "data": "app/data-persister",
        "controllers": "app/battle-game-controllers",
        "templates": "app/templates",
    }
})

require(['jquery', "sammy", "controllers", "data"], function ($, Sammy, Controllers, data) {

    var selector = '#game-container'
    var url = "http://localhost:22954/api";
    var persister = data.getPersister(url);
    var gameController = Controllers.getGameController(selector, persister);
    var accessController = Controllers.getAccessController(persister);

    var app = new Sammy(selector, function () {
        this.get("#/home", function () {
            if (accessController.isUserLoggedIn()) {
                accessController.showLoggedNavigation();
                gameController.displayGreetings();
            }
            else {
                accessController.showNotLoggedNavigation();
                gameController.clearRootContainer();
            }
        });

        this.get("#/login", function () {
            accessController.showNotLoggedNavigation();
            gameController.renderLoginForm();
        });

        this.get("#/register", function () {
            accessController.showNotLoggedNavigation();
            gameController.renderRegisterForm();
        });

        this.get("#/logout", function () {
            accessController.showLoggedNavigation();
            gameController.logout();
        });

        this.get("#/create-game", function () {
            accessController.showNotLoggedNavigation();
            gameController.renderCreateGame();
        });

        this.get("#/open-games", function () {
            accessController.showLoggedNavigation();
            gameController.renderOpenGames();
        });

        this.get("#/my-games", function () {
            accessController.showLoggedNavigation();
            gameController.renderMyActiveGames();
        });

        this.get("#/scores", function () {
            accessController.showLoggedNavigation();
            gameController.renderScores();
        });

        this.get("#/game/:id/field", function () {
            accessController.showLoggedNavigation();
            var id = this.params["id"];
            gameController.renderGameField(id);
        });
    });

    app.run("#/home");
});