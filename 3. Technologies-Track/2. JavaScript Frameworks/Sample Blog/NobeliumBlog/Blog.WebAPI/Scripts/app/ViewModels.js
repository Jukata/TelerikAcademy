/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    function formatDate(dateString) {
        var date = new Date(dateString),
            day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear(),
            separator = '/';

        return day + separator +
            month + separator +
            year;
    };

    function getLoginViewModel(successCallback, errorCallback) {
        var viewModel = {
            login: function () {
                var username = this.get("username"),
                    password = this.get("password");

                data.users.login(username, password)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					}, function (error) {
					    if (errorCallback) {
					        errorCallback(error);
					    }
					});
            }
        };

        return kendo.observable(viewModel);
    };

    function getRegisterViewModel(successCallback, errorCallback) {
        var viewModel = {
            register: function () {
                var username = this.get("username"),
                    displayName = this.get("displayName"),
                    password = this.get("password");

                data.users.register(username, displayName, password)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					}, function (error) {
					    if (errorCallback) {
					        errorCallback(error);
					    }
					});
            }
        };

        return kendo.observable(viewModel);
    };

    function getCreatePostViewMode(successCallback, errorCallback) {
        var viewModel = {
            tagList: [],
            create: function () {
                var title = this.get("title"),
                    text = this.get("text"),
                    tags = this.get("tagList");

                data.posts.create(title, text, tags)
                    .then(function (data) {
                        if (successCallback) {
                            successCallback(data.id);
                        }
                    }, function (error) {
                        if (errorCallback) {
                            errorCallback(error);
                        }
                    });
            },
            clear: function () {
                this.set("title", "");
                this.set("text", "");
                this.set("tag", "");
                this.set("tagList", []);
            },
            addTag: function () {
                var tag = this.get("tag");
                this.set("tag", "");
                this.tagList.push(tag);
            },
            clearTags: function () {
                this.set("tagList", []);
            }
        };

        return kendo.observable(viewModel);
    };

    function getPostsViewModel() {
        //data = fakePersister.get("someurl");
        return data.posts.getAll()
			.then(function (posts) {

			    $.each(posts, function (i, post) {
			        posts[i].postDate = formatDate(post.postDate);
			    });

			    var viewModel = {
			        posts: posts,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getMyPostsViewModel() {
        return data.posts.getMine()
			.then(function (posts) {

			    $.each(posts, function (i, post) {
			        posts[i].postDate = formatDate(post.postDate);
			    });

			    var viewModel = {
			        posts: posts,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getSinglePostViewModel(id) {
        return data.posts.getPostById(id)
			.then(function (post) {

			    $.each(post.comments, function (i, comment) {
			        post.comments[i].postDate = formatDate(comment.postDate);
			    });

			    var viewModel = {
			        post: post,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getCommentPostViewModel(id, successCallback, errorCallback) {
        var viewModel = {
            create: function () {
                var text = this.get("text");

                data.posts.comment(id, text)
                    .then(function (data) {
                        if (successCallback) {
                            successCallback(data);
                        }
                    }, function (error) {
                        if (errorCallback) {
                            errorCallback(error);
                        }
                    });
            },
            clear: function () {
                this.set("text", "");
            }
        };

        return kendo.observable(viewModel);
    };

    function getTagsViewModel() {
        return data.tags.getAll()
			.then(function (tags) {
			    var viewModel = {
			        tags: tags,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getTagPostsViewModel(id) {
        return data.tags.getPostsByTag(id)
			.then(function (posts) {
			    var viewModel = {
			        posts: posts,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getCommentsViewModel() {
        return data.posts.getAllComments()
			.then(function (comments) {
			    $.each(comments, function (i, comment) {
			        comments[i].postDate = formatDate(comment.postDate);
			    });

			    var viewModel = {
			        comments: comments,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getMyCommentsViewModel() {
        return data.posts.getMyComments()
			.then(function (comments) {
			    $.each(comments, function (i, comment) {
			        comments[i].postDate = formatDate(comment.postDate);
			    });

			    var viewModel = {
			        comments: comments,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    };

    function getHomeViewModel() {
        return RSVP.all([
            data.posts.getMine(),
            data.posts.getMyComments()
        ]).then(function (resultList) {
            var posts = resultList[0],
                comments = resultList[1];

            $.each(posts, function (i, post) {
                posts[i].postDate = formatDate(post.postDate);
            });
            $.each(comments, function (i, comment) {
                comments[i].postDate = formatDate(comment.postDate);
            });

            var viewModel = {
                posts: posts,
                comments: comments
            }

            return kendo.observable(viewModel);
        });
    };

    function getHomeNavBarViewModel() {
        var isAdmin = data.users.isAdmin();
        var viewModel = {
            isAdmin: isAdmin,
        }

        return kendo.observable(viewModel);
    };

    function getSearchCommentsViewModel() {
        var viewModel = {
            keyword: "",
            comments: [],
            search: function () {
                var self = this,
                    word = this.get("keyword");

                data.posts.searchComments(word)
                    .then(function (comments) {
                        $.each(comments, function (i, comment) {
                            comments[i].postDate = formatDate(comment.postDate);
                        });
                        self.set("comments", comments);
                        self.clear();
                    });
            },
            clear: function () {
                this.set("keyword", "");
    }
        };

        return kendo.observable(viewModel);
    };

    function getSearchPostsViewModel(errorCallback) {
        var viewModel = {
            keyword: "",
            posts: [],
            search: function () {
                var self = this,
                    keyword = this.get("keyword");
                this.clear();
                data.posts.getPostsByKeyword(keyword)
                    .then(function (posts) {
                        $.each(posts, function (i, post) {
                            posts[i].postDate = formatDate(post.postDate);
                        });
                        self.set("posts", posts);
                    }, function (error) {
                        if (errorCallback) {
                            errorCallback(error);
                        }
                    })
            },
            clear: function () {
                this.set("keyword", "");
                this.set("posts", []);
            }
        }

        return kendo.observable(viewModel);
    }

    return {
        getLoginVM: getLoginViewModel,
        getRegisterVM: getRegisterViewModel,
        getPostsVM: getPostsViewModel,
        getMyPostsVM: getMyPostsViewModel,
        getSinglePostVM: getSinglePostViewModel,
        getCreatePostVM: getCreatePostViewMode,
        getCommentPostVM: getCommentPostViewModel,
        getTagsVM: getTagsViewModel,
        getTagPostsVM: getTagPostsViewModel,
        getMyCommentsVM: getMyCommentsViewModel,
        getHomeVM: getHomeViewModel,
        getCommentsVM: getCommentsViewModel,
        getHomeNavVM: getHomeNavBarViewModel,
        getSearchCommentsVM: getSearchCommentsViewModel,
        getSearchPostsVM: getSearchPostsViewModel,
        setPersister: function (persister) {
            data = persister;
        }
    };
}());