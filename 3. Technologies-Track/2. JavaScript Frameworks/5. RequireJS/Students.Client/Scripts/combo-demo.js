/// <reference path="libs/require.js" />

require.config({
    paths: {
        "jquery": "libs/jquery-2.0.3",
        "class": "libs/class",
        "mustache": "libs/mustache",
        "controls": "app/controls"
    }
})

require(['jquery', 'controls', 'mustache'], function ($, controls, mustache) {
    var people = [
        { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.png" },
        { id: 2, name: "Svetlin Nakov", age: 17, avatarUrl: "images/nakov.jpg" },
        { id: 3, name: "Georgi Georgiev", age: 19, avatarUrl: "images/joreto.jpg" }];

    var comboBox = new controls.ComboBox(people);
    var template = mustache.compile($("#person-template").html());
    comboBox.render('#main-container', template);
})