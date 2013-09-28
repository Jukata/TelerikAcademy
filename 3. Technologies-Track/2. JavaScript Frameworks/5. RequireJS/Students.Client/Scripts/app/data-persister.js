/// <reference path="../libs/require.js" />

define(["http", "class"], function (http, Class) {

    var MainPersister = Class.create({
        init: function (url) {
            this.rootUrl = url;
            this.students = new StudentPersister(this.rootUrl);
        }
    });

    var StudentPersister = Class.create({
        init: function (url) {
            this.rootUrl = url + "students/"
        },
        getStudents: function () {
            return http.getJSON(this.rootUrl);
        },
        getStudentMarks: function (studentId) {
            var url = this.rootUrl + studentId + "/marks";
            return http.getJSON(url);
        }
    });

    return {
        getPersister: function (url) {
            return new MainPersister(url);
        }
    }
})