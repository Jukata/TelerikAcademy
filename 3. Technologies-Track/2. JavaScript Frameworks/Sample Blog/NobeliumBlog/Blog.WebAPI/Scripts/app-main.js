/// <reference path="libs/_references.js" />

(function () {

    var persister = persisters.get("api/"),
        controls = ui.controls('#main-container'),
        router = new kendo.Router(),
        appLayout = new kendo.Layout(
            '<div id="nav"></div>' +
            '<div id="main-layout" class="fill"></div>');

    vmFactory.setPersister(persister);

    router.route("/", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getHomeView(),
                vmFactory.getHomeVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var container = null,
                    navView = null,
                    postsView = null,
                    commentsView = null,
                    homeNavHtml = resultList[0],
                    homeViewHtml = resultList[1],
                    HomeViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(homeNavHtml, {
                    model: homeNavViewModel
                });
                appLayout.showIn("#nav", navView);

                homeView = new kendo.View(homeViewHtml, {
                    model: HomeViewModel
                });
                appLayout.showIn("#main-layout", homeView);

                controls.setAvtiveSection('#/');
            });
        }
    });

    router.route("/login", function () {
        var displayName = persister.users.currentUser();

        if (displayName) {
            router.navigate("/");
        } else {
            var logSuccess = null,
                logError = null;

            logSuccess = function () {
                router.navigate("/");
            };
            logError = function (error) {
                controls.alertError('.form-signin', error);
            };

            RSVP.all([
                viewsFactory.getLoginNavBar(),
                viewsFactory.getLoginView(),
                vmFactory.getLoginVM(logSuccess, logError)
            ])
            .then(function (resultList) {
                var navView = null,
                    loginView = null,
                    navHtml = resultList[0],
                    loginHtml = resultList[1],
                    loginViewModel = resultList[2];

                navView = new kendo.View(navHtml);
                loginView = new kendo.View(loginHtml, {
                    model: loginViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", loginView);
            });
        }
    });

    router.route("/register", function () {
        var displayName = persister.users.currentUser();

        if (displayName) {
            router.navigate("/");
        } else {
            var regSuccess = null,
                regError = null;

            regSuccess = function () {
                router.navigate("/");
            };
            regError = function (error) {
                controls.alertError('.form-signup', error);
            };

            RSVP.all([
                viewsFactory.getRegisterNavBar(),
                viewsFactory.getRegisterView(),
                vmFactory.getRegisterVM(regSuccess, regError)
            ]).then(function (resultList) {
                var navView = null,
                    registerView = null,
                    navHtml = resultList[0],
                    registerHtml = resultList[1],
                    registerViewModel = resultList[2];

                navView = new kendo.View(navHtml);
                registerView = new kendo.View(registerHtml, {
                    model: registerViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", registerView);
            });
        }
    });

    router.route("/logout", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            persister.users.logout()
                .then(function () {
                    router.navigate("/login");
                });
        }
    });

    router.route("/posts", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getPostsView(),
                vmFactory.getPostsVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    postsView = null,
                    navHtml = resultList[0],
                    postsHtml = resultList[1],
                    postsViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                postsView = new kendo.View(postsHtml, {
                    model: postsViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", postsView);

                controls.setAvtiveSection('#/posts');
            });
        }
    });

    router.route("/posts/mine", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getMyPostsView(),
                vmFactory.getMyPostsVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    postsView = null,
                    navHtml = resultList[0],
                    postsHtml = resultList[1],
                    postsViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                postsView = new kendo.View(postsHtml, {
                    model: postsViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", postsView);

                controls.setAvtiveSection('#/posts/mine');
            });
        }
    });

    router.route("/posts/create", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/");
        } else {
            var createPostSuccess = null,
                createPostError = null;

            createPostSuccess = function (id) {
                router.navigate("/posts/" + id);
            };
            createPostError = function (error) {
                controls.alertError('.form-create-post', error);
            };

            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getCreatePostView(),
                vmFactory.getCreatePostVM(createPostSuccess, createPostError),
                vmFactory.getHomeNavVM()
            ]).then(function (resultList) {
                var navView = null,
                    createPostView = null,
                    navHtml = resultList[0],
                    createPostHtml = resultList[1],
                    createPostViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                createPostView = new kendo.View(createPostHtml, {
                    model: createPostViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", createPostView);

                controls.setAvtiveSection('#/posts/create');
            });
        }
    });

    router.route("/posts/search", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/");
        } else {

            var searchPostError = function (error) {
                controls.alertError('.search-posts', error);
            };

            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getSearchPostsView(),
                vmFactory.getSearchPostsVM(searchPostError),
                vmFactory.getHomeNavVM()
            ]).then(function (resultList) {
                var navView = null,
                    searchPostView = null,
                    navHtml = resultList[0],
                    searchPostHtml = resultList[1],
                    searchPostViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                searchPostView = new kendo.View(searchPostHtml, {
                    model: searchPostViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", searchPostView);

                controls.setAvtiveSection('#/posts/search');
            });
        }
    });

    router.route('/posts/:id', function (id) {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getSinglePostView(),
                vmFactory.getSinglePostVM(id),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    postView = null,
                    navHtml = resultList[0],
                    postHtml = resultList[1],
                    postViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                postView = new kendo.View(postHtml, {
                    model: postViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", postView);
            });
        }
    });

    router.route('/posts/:id/comment', function (id) {
        var displayName = persister.users.currentUser();

        createCommentSuccess = function (data) {
            router.navigate("/posts/" + id);
        };
        createCommentError = function (error) {
            controls.alertError('.form-comment-post', error);
        };

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getCommentPostView(),
                vmFactory.getCommentPostVM(id, createCommentSuccess, createCommentError),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    commentPostView = null,
                    navHtml = resultList[0],
                    commentPostHtml = resultList[1],
                    commentPostViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                commentPostView = new kendo.View(commentPostHtml, {
                    model: commentPostViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", commentPostView);
            });
        }
    });

    router.route("/tags", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getTagsView(),
                vmFactory.getTagsVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    tagsView = null,
                    navHtml = resultList[0],
                    tagsHtml = resultList[1],
                    tagsViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                tagsView = new kendo.View(tagsHtml, {
                    model: tagsViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", tagsView);

                controls.setAvtiveSection('#/tags');
            });
        }
    });

    router.route("/tags/:id/posts", function (id) {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getTagPostsView(),
                vmFactory.getTagPostsVM(id),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    tagPostsView = null,
                    navHtml = resultList[0],
                    tagPostsHtml = resultList[1],
                    tagPostsViewModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                tagPostsView = new kendo.View(tagPostsHtml, {
                    model: tagPostsViewModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", tagPostsView);
            });
        }
    });

    router.route("/comments", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getCommentsView(),
                vmFactory.getCommentsVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    commentsView = null,
                    navHtml = resultList[0],
                    commentsHtml = resultList[1],
                    commentsModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                commentsView = new kendo.View(commentsHtml, {
                    model: commentsModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", commentsView);

                controls.setAvtiveSection('#/comments');
            });
        }
    });

    router.route("/comments/mine", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getMyCommentsView(),
                vmFactory.getMyCommentsVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    myCommentsView = null,
                    navHtml = resultList[0],
                    myCommentsHtml = resultList[1],
                    myCommentsModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                myCommentsView = new kendo.View(myCommentsHtml, {
                    model: myCommentsModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", myCommentsView);

                controls.setAvtiveSection('#/comments');
            });
        }
    });

    router.route("/comments/search", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        } else {
            RSVP.all([
                viewsFactory.getHomeNavBar(),
                viewsFactory.getSearchCommentsView(),
                vmFactory.getSearchCommentsVM(),
                vmFactory.getHomeNavVM()
            ])
            .then(function (resultList) {
                var navView = null,
                    searchCommentsView = null,
                    navHtml = resultList[0],
                    searchCommentsHtml = resultList[1],
                    searchCommentsModel = resultList[2],
                    homeNavViewModel = resultList[3];

                navView = new kendo.View(navHtml, {
                    model: homeNavViewModel
                });
                searchCommentsView = new kendo.View(searchCommentsHtml, {
                    model: searchCommentsModel
                });

                appLayout.showIn("#nav", navView);
                appLayout.showIn("#main-layout", searchCommentsView);

                controls.setAvtiveSection('#/comments');
            });
        }
    });

    router.route("/admin", function () {
        var displayName = persister.users.currentUser();

        if (!displayName) {
            router.navigate("/login");
        }
        else {
            //router.navigate();
            document.location.href = "/index-admin.html";
        }
    });

    $(function () {
        appLayout.render("#main-container");
        router.start();
    });
}());


