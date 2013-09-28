/// <reference path="libs/require.js" />
/// <reference path="app/data-persister.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/mustache.js" />

require.config({
    paths: {
        "jquery": "libs/jquery-2.0.3",
        "class": "libs/class",
        "http": "libs/http-requester",
        "mustache": "libs/mustache",
        "rsvp": "libs/rsvp.min",
        "data": "app/data-persister",
        "controls": "app/controls"
    }
})

require(["jquery", "mustache", "data", "controls"], function ($, mustache, data, controls) {
    var persister = data.getPersister("http://localhost:15372/api/");
    persister.students.getStudents()
        .then(function (data) {
            var tableView = new controls.TableView(data);
            var template = mustache.compile($('#students-template').html());
            tableView.render('#students-container', template, 5);
            attachEventHandlers();
        }, handleError);

    function attachEventHandlers() {
        $('#students-container').on('click', 'td', function () {
            var target = $(this);
            if (!target.is('td')) { return; }

            $('#students-container td.selected').removeClass('selected');
            target.addClass('selected');

            var studentId = target.attr('data-student-id');

            persister.students.getStudentMarks(studentId)
                .then(function (data) {
                    var template = mustache.compile($('#marks-template').html());
                    $('#marks-container').html(template(data));
                }, handleError);
        })
    }

    function handleError(errData) {
        $('#students-container').html(errData.status).css('color', 'red');
    }
})