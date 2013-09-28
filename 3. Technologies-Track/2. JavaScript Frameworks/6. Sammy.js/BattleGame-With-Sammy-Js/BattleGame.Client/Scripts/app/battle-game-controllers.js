/// <reference path="data-persister.js" />
/// <reference path="../libs/class.js" />

define(['jquery', 'class', 'data', 'templates', 'underscore'], function ($, Class, data, templates, underscore) {

    var BattleGameController = Class.create({
        init: function (selector, persister) {
            //this.rootServiceUrl = rootServicesUrl;
            this.rootContainer = $(selector);
            this.persister = persister;
            this.attachEventHandlers();
            this.warriorMaxHitPoints = 15;
            this.rangerMaxHitPoints = 10;
        },
        clearRootContainer: function () {
            var self = this;
            this.rootContainer.hide(500, function () {
                self.rootContainer.html('').show();
            });
        },
        displayGreetings: function () {
            var self = this;
            this.rootContainer.hide(500, function () {
                templates.getGreetingsTemplate().then(
                    function (template) {
                        var nickname = self.persister.getNickname();
                        var rootHtml = template(nickname);
                        self.rootContainer.html(rootHtml).show(500);
                    });
            });
        },
        renderLoginForm: function () {
            var self = this;
            templates.getLoginTemplate().then(function (data) {
                self.rootContainer.hide(500, function () {
                    self.rootContainer.html(data).show(500)
                });
            }, function (errData) {
                self.handleErrorData(errData);
            }).done();
        },
        renderRegisterForm: function () {
            var self = this;
            templates.getRegisterTemplate().then(function (data) {
                self.rootContainer.hide(500, function () {
                    self.rootContainer.html(data).show(500)
                });
            }, function (errData) {
                self.handleErrorData(errData);
            }).done();
        },
        renderCreateGame: function () {
            var self = this;
            templates.getCreateGameTemplate().then(function (data) {
                self.rootContainer.hide(500, function () {
                    self.rootContainer.html(data).show(500)
                });
            }, function (errData) {
                self.handleErrorData(errData);
            }).done();
        },
        logout: function () {
            var self = this;
            if (this.persister.isUserLoggedIn()) {
                this.persister.user.logout().then(function (data) {
                    window.location.href = "#/home";
                }, function (errData) {
                    if (errData.status === 200 && errData.statusText === "OK") {
                        window.location.href = "#/home";
                    }
                    self.handleErrorData(errData);
                });
            }
            else {
                window.location.href = "#/home";
            }
        },
        renderOpenGames: function () {
            self = this;
            this.persister.games.open().then(function (data) {
                templates.getOpenGamesTemplate().then(function (template) {
                    var openGamesContainer = $('<div id="open-games"></div>');
                    for (var i = 0; i < data.length; i++) {
                        openGamesContainer.append(template(data[i]));
                    };
                    self.rootContainer.hide(500, function () {
                        self.rootContainer.html(openGamesContainer).show(500);
                    })
                });
            }, function (errData) {
                self.handleErrorData(errData);
            }).done();
        },
        renderMyActiveGames: function () {
            var self = this;
            this.persister.games.active().then(function (data) {
                templates.getMyActiveGamesTemplate().then(function (template) {
                    var myGamesContainer = $('<div id="my-games"></div<');
                    for (var i = 0; i < data.length; i++) {
                        var compiledTemplate = $(template(data[i]));

                        if (data[i].creator !== self.persister.getNickname() ||
                            data[i].status !== "full") {
                            compiledTemplate.children('.btn-start-game').remove();
                        }

                        myGamesContainer.append(compiledTemplate);
                    }
                    self.rootContainer.hide(500, function () {
                        self.rootContainer.html(myGamesContainer).show(500);
                    })
                });
            }, function (errData) {
                self.handleErrorData(errData);
            }).done();
        },
        renderScores: function () {
            var self = this;
            this.persister.user.scores().then(function (data) {
                templates.getScoresTemplate().then(function (template) {
                    var scoreboardContainer = $('<div id="scoreboard"></div>');
                    var arr = _.first(
                        _.sortBy(data, function (a, b) {
                            return a.score < b.score
                        }), 5);
                    for (var i = 0; i < arr.length; i++) {
                        var userScore = template({
                            position: i + 1,
                            nickname: arr[i].nickname,
                            score: arr[i].score,
                        });
                        scoreboardContainer.append(userScore);
                    }

                    self.rootContainer.hide(500, function () {
                        self.rootContainer.html(scoreboardContainer).show(500);
                    });
                });
            }, function (errData) {
                self.handleErrorData(errData);
            });
        },
        renderGameField: function (gameId) {
            var self = this;
            this.persister.games.field(gameId).then(function (receivedData) {

                var gameField = $('<div #game-field></div>');
                self.rootContainer.hide(500);
                self.rootContainer.html('').append(gameField);

                //building field
                var i = 0;
                var j = 0;

                var fieldRowsAndCols = $('<div id="field"></div>');
                for (i = 0; i < 9; i++) {
                    var currentRow = $('<ul class="game-field-row"></ul>')
                    for (j = 0; j < 9; j++) {
                        currentRow.append('<li class="cell" data-x-coord="' + j + '" data-y-coord="' + i + '"></li>');
                    }
                    fieldRowsAndCols.append(currentRow);
                }
                gameField.append(fieldRowsAndCols);

                var redUnits = receivedData.red.units;
                self.placeUnits(redUnits, 'red-unit');
                var blueUnits = receivedData.blue.units;
                self.placeUnits(blueUnits, 'blue-unit');

                self.rootContainer.show(500);

            }, function (errData) {
                self.handleErrorData(errData);
            }).done();
        },
        placeUnits: function (units, unitClass) {
            for (i = 0; i < units.length; i++) {
                var x = units[i].position.x;
                var y = units[i].position.y;
                var cellToPlace = $('li.cell[data-x-coord=' + x + '][data-y-coord=' + y + ']');
                cellToPlace.addClass('battle-mode-' + units[i].mode);
                cellToPlace.addClass('unit');
                cellToPlace.addClass(unitClass);
                cellToPlace.addClass(units[i].type + "-unit");
                cellToPlace.attr('data-unit-id', units[i].id);

                var hitPoints = this.renderHitPoints(units[i].hitPoints, units[i].type);
                cellToPlace.prepend(hitPoints);
            }
        },
        renderHitPoints: function (currentHitPoint, unitType) {
            var maxHp = 1;

            if (unitType === 'warrior') {
                maxHp = this.warriorMaxHitPoints;
            }
            else if (unitType === 'ranger') {
                maxHp = this.rangerMaxHitPoints;
            }

            var hitPointsContainer = $('<div class="hit-points"></div>');

            var currentHPContainer = $('<div class="current-hp"></div>');
            var currentHpPercents = (currentHitPoint / maxHp) * 100;
            currentHPContainer.css('width', currentHpPercents + '%');

            hitPointsContainer.append(currentHPContainer);

            return hitPointsContainer;
        },
        attachEventHandlers: function () {
            var self = this;

            this.rootContainer.on('click', '#btn-login', function () {
                var username = $('#tb-login-username').val();
                var password = $('#tb-login-password').val();
                self.persister.user.login(username, password).then(function (data) {
                    window.location.href = "#/home";
                }, function (errData) {
                    self.handleErrorData(errData);
                }).done();

                return false;
            });

            this.rootContainer.on('click', '#btn-register', function () {
                var username = $('#tb-register-username').val();
                var nickname = $('#tb-register-nickname').val();
                var password = $('#tb-register-password').val();

                self.persister.user.register(username, nickname, password).then(function (data) {
                    window.location.href = "#/home";
                }, function (errData) {
                    self.handleErrorData(errData);
                }).done();

                return false;
            });

            this.rootContainer.on('click', '#btn-create-game', function () {
                var title = $('#tb-new-game-title').val();
                var password = $('#tb-new-game-password').val();

                self.persister.games.create(title, password).then(function (data) {
                    window.location.href = "#/my-games";
                }, function (errData) {
                    if (errData.status === 200 && errData.statusText === "OK") {
                        window.location.href = "#/my-games";
                    }
                    self.handleErrorData(errData);
                }).done();
            });

            this.rootContainer.on('click', '#btn-back', function () {
                window.history.back();
                return false;
            });

            this.rootContainer.on('click', '#btn-close-error', function () {
                var errContainer = $(this).parent();
                errContainer.fadeOut(1500, function () { errContainer.remove(); });
                return false;
            })

            this.rootContainer.on('click', '.btn-join-game', function () {
                var target = $(this);
                var gameId = target.siblings('.open-games-title').attr('data-game-id') | 0;
                var password = target.siblings('.tb-join-game-password').val();

                self.persister.games.join(gameId, password).then(function () {
                    window.location.href = "#/my-games";
                }, function (errData) {
                    if (errData.status === 200 && errData.statusText === "OK") {
                        window.location.href = "#/my-games";
                    }
                    self.handleErrorData(errData);
                });

                return false;
            });

            this.rootContainer.on('click', '.btn-start-game', function () {
                var target = $(this);
                var gameId = target.siblings('.my-games-title').attr('data-game-id') | 0;
                self.persister.games.start(gameId).then(function () {
                    window.location.href = "#/game/" + gameId + "/field";
                }, function (errData) {
                    if (errData.status === 200 && errData.statusText === "OK") {
                        window.location.href = "#/game/" + gameId + "/field";
                    }
                    self.handleErrorData(errData);
                });
                return false;
            });
        },
        clearUserData: function () {
            this.persister.clearUserData();
        },
        handleErrorData: function (errData) {
            var self = this;

            if (errData.responseJSON.errCode === 'INV_USR_AUTH') {
                this.clearUserData();
                window.location.href = "#/home";
                return false;
            }

            templates.getErrorTemplate().then(function (template) {
                var errContainer = $('#error-container');
                if (errContainer && errContainer.length > 0) {
                    errContainer.hide(500, function () {
                        errContainer.remove();
                        var newErrContainer = $(template(errData));
                        self.rootContainer.append(newErrContainer);
                        newErrContainer.hide().show(500);
                    });
                }
                else {
                    var newErrContainer = $(template(errData));
                    self.rootContainer.append(newErrContainer);
                    newErrContainer.hide().show(500);
                }
            }).done();
        },
    });

    var AccessController = Class.create({
        init: function (persister) {
            this.persister = persister;
            this.attachEventHandlers();
        },
        isUserLoggedIn: function () {
            return this.persister.isUserLoggedIn();
        },

        showLoggedNavigation: function () {
            if (!this.isUserLoggedIn()) {
                return false;
                window.location.href = "#/home";
            }

            $('#login-link').parent().hide();
            $('#register-link').parent().hide();
            $('#logout-link').parent().show();
            $('#create-game-link').parent().show();
            $('#open-games-link').parent().show();
            $('#active-games-link').parent().show();
            $('#my-games-link').parent().show();
            $('#scores-link').parent().show();
        },
        showNotLoggedNavigation: function () {
            if (this.isUserLoggedIn()) {
                return false;
                window.location.href = "#/home";
            }

            $('#login-link').parent().show();
            $('#register-link').parent().show();
            $('#logout-link').parent().hide();
            $('#create-game-link').parent().hide();
            $('#open-games-link').parent().hide();
            $('#active-games-link').parent().hide();
            $('#my-games-link').parent().hide();
            $('#scores-link').parent().hide();
        },
        attachEventHandlers: function () {
            $('#main-nav ul').on('click', 'li', function () {
                var link = $(this).children('a').attr('href');
                window.location.href = link;
                return false;
            });
        },
    });

    return {
        getGameController: function (selector, persister) {
            return new BattleGameController(selector, persister);
        },
        getAccessController: function (persister) {
            return new AccessController(persister);
        }
    }
})