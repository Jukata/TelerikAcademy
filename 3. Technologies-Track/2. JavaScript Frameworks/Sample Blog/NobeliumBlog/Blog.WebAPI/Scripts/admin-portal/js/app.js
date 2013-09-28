/// <reference path="../../libs/jquery-2.0.3.js" />
'use strict';

/* App Module */

angular.module('admin', ['adminFilters']).
  config(['$routeProvider', function($routeProvider) {
  $routeProvider.
      when('/posts', { templateUrl: 'Scripts/admin-portal/partials/post-list.html', controller: PostsListCtrl }).
      when('/posts/:postId', { templateUrl: 'Scripts/admin-portal/partials/post-detail.html', controller: PostsDetailCtrl }).
      otherwise({redirectTo: '/posts'});
}]);
