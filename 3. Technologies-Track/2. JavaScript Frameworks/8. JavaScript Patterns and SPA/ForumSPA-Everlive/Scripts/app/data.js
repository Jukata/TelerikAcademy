/// <reference path="../lib/class.js" />
/// <reference path="../lib/everlive.js" />
/// <reference path="../lib/rsvp.js" />

var Data = (function () {
    var DataPersister = Class.create({
        init: function (appKey) {
            this.appKey = "p5l5qZSGY5E6OJam" //appKey;
            this.everlive = new Everlive(this.appKey);
            this.isUserLogged = false;
        },
        register: function (username, password, email, displayName) {
            var self = this;

            var additionalInfo = {};
            if (email) {
                additionalInfo.Email = email;
            }
            if (displayName) {
                additionalInfo.DisplayName = displayName;
            }

            var promise = new RSVP.Promise(function (resolve, reject) {
                self.everlive.Users.register(username, password, additionalInfo,
                    function (data) {
                        resolve(data)
                    }, function (errData) {
                        reject(errData);
                    })
            });

            return promise;
        },
        login: function (username, password) {
            var self = this;

            var promise = new RSVP.Promise(function (resolve, reject) {
                self.everlive.Users.login(username, password,
                    function (data) {
                        self.isUserLogged = true;
                        resolve(data);
                    }, function (errData) {
                        reject(errData);
                    });
            });

            return promise;
        },
        logout: function () {
            var self = this;

            var promise = new RSVP.Promise(function (resolve, reject) {
                self.everlive.Users.logout(
                    function (data) {
                        self.isUserLogged = false;
                        resolve(data);
                    }, function (errData) {
                        reject(data);
                    });
            });

            return promise;
        },
        getCurrentUser: function () {
            return this.everlive.Users.currentUser();
        },
        getPosts: function () {
            return this.everlive.data('Post').get();
        },
        getPost: function (postId) {
            return this.everlive.data('Post').getById(postId);
        },
        getPostsByTags: function (tags) {
            var query = new Everlive.Query();
            query.where().all('Tags', tags)
            return this.everlive.data('Post').get(query);
        },
        createPost: function (title, content, tags) {
            var newPost = {
                Title: title,
                Content: content,
            };

            if (tags && tags instanceof Array) {
                newPost.Tags = tags;
            }

            return this.everlive.data('Post').create(newPost);
        },
        leaveComment: function (postId, commentText) {
            var self = this;

            return this.getPost(postId).then(function (data) {
                var currentComments = data.result.Comments;
                currentComments.push(commentText);
                self.everlive.data('Post').updateSingle({
                    Id: 'd12169c0-10c0-11e3-b9e4-2b81f9914073',
                    'Comments': currentComments
                })
            });

        },
    });

    return {
        getDataPersister: function (appKey) {
            return new DataPersister(appKey);
        }
    }
}());
