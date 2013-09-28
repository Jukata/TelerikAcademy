/// <reference path="lib/sammy-0.7.4.js" />
/// <reference path="lib/jquery-2.0.3.js" />
/// <reference path="app/Controllers.js" />
/// <reference path="app/data.js" />

$(function () {

    var appKey = "p5l5qZSGY5E6OJam";
    var selector = "#main-container";
    var navSelector = "#main-nav";
    var dataPersister = Data.getDataPersister(appKey);

    var forumController = Controllers.getForumController(selector, dataPersister);
    var accessController = Controllers.getAccessController(navSelector, dataPersister);

    var app = new Sammy(selector, function () {
        this.get('#/', function () {
            accessController.renderNavigation();
            $(selector).hide(1500, function () {
                $(selector).html('<h1>Home</h1>').show(500);
            });
        });

        this.get('#/home', function () {
            window.location.replace('#/');
        });

        this.get('#/login', function () {
            accessController.renderNavigation();
            forumController.renderLogin();
        });

        this.get('#/register', function () {
            accessController.renderNavigation();
            forumController.renderRegister();
        });

        this.get('#/posts', function () {
            accessController.renderNavigation();
            forumController.renderPosts();
        });

        this.get('#/posts/search', function () {
            accessController.renderNavigation();
            forumController.renderSearchPosts();
        });

        this.get('#/posts/:tags', function () {
            accessController.renderNavigation();
            var tags = this.params["tags"].split(',');
            forumController.renderPostsByTags(tags);
        });

        this.get('#/post/:id', function () {
            accessController.renderNavigation();
            var postId = this.params["id"];
            forumController.renderPost(postId);
        });

        this.get("#/post/:id/comment", function () {
            accessController.renderNavigation();
            var postId = this.params["id"];
            forumController.leaveComment(postId);
        });

        this.get('#/new-post', function () {
            accessController.renderNavigation();
            forumController.renderNewPost();
        });

    });

    app.run("#/");
});