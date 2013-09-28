/// <reference path="../lib/class.js" />
/// <reference path="../lib/jquery-2.0.3.js" />
/// <reference path="templates.js" />
/// <reference path="../lib/mustache.js" />

var Controllers = (function () {
    var ForumController = Class.create({
        init: function (selector, dataPersister) {
            this.root = $(selector);
            this.persister = dataPersister;
            this.attachEventHandlers();
        },
        renderLogin: function () {
            var self = this;
            Templates.getLoginTemplate().then(function (template) {
                var rootHtml = Mustache.render(template);
                self.root.html(rootHtml);
            }, function (errData) {
                self.handleError(errData);
            });
        },
        renderRegister: function () {
            var self = this;
            Templates.getRegisterTemplate().then(function (template) {
                var rootHtml = Mustache.render(template);
                self.root.html(rootHtml);
            }, function (errData) {
                self.handleError(errData);
            });
        },
        renderNewPost: function () {
            var self = this;

            Templates.getNewPostTemplate().then(function (template) {
                var rootHtml = Mustache.render(template);
                self.root.html(rootHtml);
            }, function (errData) {
                self.handleError(errData);
            })
        },
        renderSearchPosts: function () {
            var self = this;

            Templates.getSearchPostsTemplate().then(function (template) {
                var rootHtml = Mustache.render(template);
                self.root.html(rootHtml);
            }, function (errData) {
                self.handleError(errData);
            });
        },
        renderPosts: function () {
            var self = this;

            this.persister.getPosts().then(function (data) {
                Templates.getPostTemplate().then(function (template) {
                    var postsContainer = $('<div id="posts">Posts:</div>');
                    for (var i = 0; i < data.result.length; i++) {
                        var postHtml = Mustache.render(template, data.result[i]);
                        postsContainer.append(postHtml);
                    }

                    self.root.html(postsContainer);
                })
            }, function (errData) {
                self.handleError(errData);
            });
        },
        renderPost: function (postId) {
            var self = this;

            this.persister.getPost(postId).then(function (data) {
                Templates.getFullPostTemplate().then(function (template) {
                    var postHtml = Mustache.render(template, data.result);
                    self.root.html(postHtml);
                })
            }, function (errData) {
                self.handleError(errData);
            });
        },
        renderPostsByTags: function (tags) {
            var self = this;

            this.persister.getPostsByTags(tags).then(function (data) {
                Templates.getPostTemplate().then(function (template) {
                    var postsContainer = $('<div id="posts">Posts:</div>');
                    for (var i = 0; i < data.result.length; i++) {
                        var postHtml = Mustache.render(template, data.result[i]);
                        postsContainer.append(postHtml);
                    }

                    self.root.html(postsContainer);
                })
            }, function (errData) {
                self.handleError(errData);
            });
        },
        leaveComment: function (postId) {
            var self = this;

            var commentText = $('#new-comment-text-area').val();
            if (!commentText) {
                return;
            }

            this.persister.leaveComment(postId, commentText).then(function (data) {
                window.location.href = "#/post/" + postId;
            }, function (errData) {
                self.handleError(errData);
            })
        },
        attachEventHandlers: function () {
            var self = this;

            this.root.on('click', '#btn-login', function () {
                var username = $('#tb-login-username').val();
                var password = $('#tb-login-password').val();

                self.persister.login(username, password).then(function (data) {
                    self.root.html('<h1>Login successfull</h1>');
                    window.location.href = "#/";
                }, function (errData) {
                    self.handleError(errData);
                })

                return false;
            });

            this.root.on('click', '#btn-register', function () {
                var username = $('#tb-register-username').val();
                var password = $('#tb-register-password').val();
                var displayName = $('#tb-register-display-name').val();
                var email = $('#tb-register-email').val();

                self.persister.register(username, password, displayName, email).then(function (data) {
                    self.root.html('<h1>Register successfull</h1>');
                    window.location.href = "#/";
                }, function (errData) {
                    self.handleError(errData);
                });
            });

            this.root.on('click', '#btn-create-post', function () {
                var title = $('#tb-post-title').val();
                var content = $('#post-content-textarea').val();
                var tags = $('#tb-post-tags').val().split(',');
                if (!title || !content) {
                    return false;
                }

                self.persister.createPost(title, content, tags).then(function (data) {
                    window.location.href = "#/posts"
                }, function (errData) {
                    self.handleError(errData);
                })

                return false;
            });

            this.root.on('click', '#btn-search-post', function () {
                var tags = $('#tb-search-tags').val();
                if (tags) {
                    window.location.href = '#/posts/' + tags;
                }
            });

            $('#main-nav').on('click', '#link-logout', function () {
                self.persister.logout().then(function () {
                    self.root.html('<h1>Logout successfull</h1>');
                    window.location.href = "#/home";
                }, function (errData) {
                    self.handleError(errData);
                })

                return false;
            });

            this.root.on('click', '#btn-back', function () {
                window.history.back();
                return false;
            });
        },
        handleError: function (errData) {
            var self = this;
            Templates.getErrorTemplate().then(function (template) {
                $('#error-message').remove();
                var errHtml = Mustache.render(template, errData);
                self.root.append(errHtml);
            });
        },
    });

    var AccessController = Class.create({
        init: function (selector, dataPersister) {
            this.root = $(selector);
            this.persister = dataPersister;
        },
        renderNavigation: function () {
            if (this.persister.isUserLogged) {
                $("#link-home").parent().show();
                $("#link-login").parent().hide();
                $("#link-register").parent().hide();
                $("#link-logout").parent().show();
                $("#link-posts").parent().show();
                $("#link-new-post").parent().show();
                $("#link-search").parent().show();
                return true;
            }
            else {
                $("#link-home").parent().show();
                $("#link-login").parent().show();
                $("#link-register").parent().show();
                $("#link-logout").parent().hide();
                $("#link-posts").parent().hide();
                $("#link-new-post").parent().hide();
                $("#link-search").parent().hide();
                return false;
            }
        },
    });

    return {
        getForumController: function (selector, dataPersister) {
            return new ForumController(selector, dataPersister);
        },
        getAccessController: function (selector, dataPersister) {
            return new AccessController(selector, dataPersister);
        },
    }
})();