define(['jquery', "httpRequester", "mustache"], function ($, httpRequester, mustache) {

    function getLoginTemplate() {
        return httpRequester.getHTML("Scripts/partials/login-form.html")
    }

    function getRegisterTemplate() {
        return httpRequester.getHTML("Scripts/partials/register-form.html");
    }

    function getErrorTemplate() {
        return httpRequester.getHTML("Scripts/partials/error.html")
            .then(function (data) {
                var templ = mustache.compile(data);
                return templ;
            });
    }

    function getGreetingsTemplate() {
        return httpRequester.getHTML('Scripts/partials/user-greetings.html')
             .then(function (data) {
                 var templ = mustache.compile(data);
                 return templ;
             });
    }

    function getOpenGamesTemplate() {
        return httpRequester.getHTML('Scripts/partials/open-game.html')
            .then(function (data) {
                var templ = mustache.compile(data);
                return templ;
            })
    }

    function getMyActiveGamesTemplate() {
        return httpRequester.getHTML('Scripts/partials/my-active-games.html')
            .then(function (data) {
                var templ = mustache.compile(data);
                return templ;
            })
    }

    function getCreateGameTemplate() {
        return httpRequester.getHTML("Scripts/partials/create-game.html");
    }

    function getScoresTemplate() {
        return httpRequester.getHTML("Scripts/partials/scores.html").then(
            function (data) {
                var templ = mustache.compile(data);
                return templ;
            })
    }

    return {
        getLoginTemplate: getLoginTemplate,
        getRegisterTemplate: getRegisterTemplate,
        getErrorTemplate: getErrorTemplate,
        getGreetingsTemplate: getGreetingsTemplate,
        getOpenGamesTemplate: getOpenGamesTemplate,
        getMyActiveGamesTemplate: getMyActiveGamesTemplate,
        getCreateGameTemplate: getCreateGameTemplate,
        getScoresTemplate: getScoresTemplate,
    }
})