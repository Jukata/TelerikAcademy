/// <reference path="../libs/_references.js" />

window.viewsFactory = (function () {
    var templates = {},
        rootUrl = "Scripts/partials/";

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {

            if (templates[name]) {
                resolve(templates[name]);
            } else {
                $.ajax({
                    type: "GET",
                    url: rootUrl + name + ".html",
                    success: function (template) {
                        templates[name] = template;
                        resolve(template);
                    },
                    error: function (error) {
                        reject(error);
                    }
                });
            }
        });

        return promise;
    }

    function getLoginView() {
        return getTemplate('form-login');
    };

    function getRegisterView() {
        return getTemplate('form-register');
    };

    function getHomeView() {
        return getTemplate('view-home');
    }

    function getPostsView() {
        return getTemplate('view-posts');
    }

    function getCommentPostView() {
        return getTemplate('form-comment-post');
    }

    function getMyPostsView() {
        return getTemplate('view-my-posts');
    }

    function getSinglePostView() {
        return getTemplate('view-posts-full');
    }

    function getLoginNavBar() {
        return getTemplate('nav-bar-login');
    }

    function getRegisterNavBar() {
        return getTemplate('nav-bar-register');
    }

    function getHomeNavBar() {
        return getTemplate('nav-bar-home');
    }

    function getCreatePostView() {
        return getTemplate('form-create-post');
    }

    function getTagsView() {
        return getTemplate('view-tags');
    }

    function getTagPostsView() {
        return getTemplate('view-tag-posts');
    }

    function getCommentsView() {
        return getTemplate('view-comments');
    };

    function getMyCommentsView() {
        return getTemplate('view-my-comments');
    };

    function getSearchCommentsView() {
        return getTemplate('view-search-comments');
    };

    function getSearchPostsView() {
        return getTemplate('view-search-posts');
    };

    return {
        getLoginView: getLoginView,
        getLoginNavBar: getLoginNavBar,
        getRegisterView: getRegisterView,
        getRegisterNavBar: getRegisterNavBar,
        getHomeView: getHomeView,
        getHomeNavBar: getHomeNavBar,
        getCreatePostView: getCreatePostView,
        getPostsView: getPostsView,
        getMyPostsView: getMyPostsView,
        getSinglePostView: getSinglePostView,
        getCommentPostView: getCommentPostView,
        getTagsView: getTagsView,
        getTagPostsView: getTagPostsView,
        getMyCommentsView: getMyCommentsView,
        getCommentsView: getCommentsView,
        getSearchCommentsView: getSearchCommentsView,
        getCommentsView: getCommentsView,
        getSearchPostsView: getSearchPostsView,
    };
}());