/// <reference path="libs/_references.js" />

angular.module("blog", [])
    .config(["$routeProvider", function ($routeProvider) {
        $routeProvider
            .when("/", { templateUrl: "Scripts/partials/home.html" })
            .when("/home", { redirectTo: "/" })
            .when("/posts", {
                templateUrl: "Scripts/partials/posts.html", controller: Controllers.PostsController
            })
            .when("/category/:categoryId/posts", {
                templateUrl: "Scripts/partials/posts.html", controller: Controllers.PostsByCategory
            })
            .when("/posts/create", {
                templateUrl: "Scripts/partials/create-post.html", controller: Controllers.CreatePost
            })
            .when("/categories", {
                templateUrl: "Scripts/partials/categories.html", controller: Controllers.Categories
            })
            .otherwise({ templateUrl: "Scripts/partials/not-found.html" });
    }]);