/// <reference path="../libs/angular/angular.js" />
/// <reference path="../../libs/jquery-2.0.3.js" />
'use strict';

/* Controllers */

var adminValidator = (function () {
    var hostUrl = "api/";    
    var displayName = $.cookie('displayName');
    var sessionKey = $.cookie('sessionKey');

    return {
        hostUrl: function () {
            return hostUrl;
        },
        displayName: function () {
            return displayName;
        },
        sessionKey: function () {
            return sessionKey;
        }
    }
})();

function PostsListCtrl($scope, $http) {
    var rootUrl = adminValidator.hostUrl();
    var sessionKey = adminValidator.sessionKey();
    
    $http.get(rootUrl + "users?sessionKey=" + sessionKey)
        .success(function () {
            $http.get(rootUrl + "posts/all?sessionKey=" + sessionKey).success(function (data) {
                $scope.posts = data;
            });

            $scope.orderProp = 'postDate';
        })
        .error(function () {
            alert("You are not an admin!Exiting..");
            document.location.href = "/index.html";
        });
}
        

function PostsDetailCtrl($scope, $routeParams, $http) {
    var rootUrl = adminValidator.hostUrl();
    var sessionKey = adminValidator.sessionKey();    

    $http.get(rootUrl + "users?sessionKey=" + sessionKey)
        .success(function () {
            $http.get(rootUrl + "posts/" + $routeParams.postId + "?sessionKey=" + sessionKey).success(function (data) {
                $scope.post = data;
                $scope.editedText = data.text;
                $scope.postedBy = data.postedBy;
            });

            $scope.setImage = function (imageUrl) {
                $scope.mainImageUrl = imageUrl;
            }
        })
        .error(function () {
            alert("You are not an admin!Exiting..");
            document.location.href = "/index.html";
        });   
        
    $scope.editPost = function (text) {
        var post = {
            "id": $routeParams.postId,
            "text": text
        }

        $http.put(rootUrl + "posts?sessionKey=" + sessionKey, post).success(function () {
            $scope.editResult = 'Changes saved';
        })
        .error(function () {
            $scope.editResult = 'Error, no changes were saved!';
        });
    }
}

