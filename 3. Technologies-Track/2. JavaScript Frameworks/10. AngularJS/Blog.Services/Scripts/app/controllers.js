/// <reference path="../libs/_references.js" />

var Controllers = (function () {

    function PostsController($scope, $http) {
        $http.get("api/posts").success(function (posts) {
            $scope.posts = posts;
        }).error(function (errData) {
            console.log(errData);
        });
    }

    function PostsByCategoryController($scope, $http, $routeParams) {
        var categoryId = $routeParams.categoryId;

        $http.get("api/categories/" + categoryId + "/posts").success(function (posts) {
            $scope.posts = posts;
        });
    }

    function CategoriesController($scope, $http) {
        $http.get("api/categories").success(function (categories) {
            $scope.categories = categories;
        }).error(function (errData) {
            console.log(errData);
        })
    }

    function CreatePostController($scope, $http) {
        $scope.newPost = {
            title: "",
            content: "",
            categories: "",
        }

        $scope.message = "";

        $scope.clear = function () {
            $scope.newPost.title = "";
            $scope.newPost.content = "";
            $scope.newPost.categories = "";
        }

        $scope.create = function () {
            var data = {
                title: $scope.newPost.title,
                content: $scope.newPost.content,
                categories: $scope.newPost.categories.split(","),
            }

            $http.post("api/posts", data).success(function () {
                handleCreatePostResponse("Post created successfully");
            }).error(function (errData) {
                handleCreatePostResponse("Error while creating new post\n" + errData.responseJSON.message);
            });
        }

        function handleCreatePostResponse(msg) {
            $('#create-post-message').show();
            $scope.newPost.title = "";
            $scope.newPost.content = "";
            $scope.newPost.categories = "";
            $scope.message = msg;
            setTimeout(function () {
                $('#create-post-message').hide();
                $scope.message = ""
            }, 3500);
        }
    };

    return {
        PostsController: PostsController,
        PostsByCategory: PostsByCategoryController,
        CreatePost: CreatePostController,
        Categories: CategoriesController
    }
}())