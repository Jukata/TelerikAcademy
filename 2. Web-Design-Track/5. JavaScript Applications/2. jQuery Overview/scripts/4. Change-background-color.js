var addColorPicker = function (selector) {
    var container = $(selector);
    var colorPicker = $('<input type="color" id="color-picker" value="#ffffff" />');
    colorPicker.addClass("color-picker");
    colorPicker.on('change', function () {
        var selectedColor = colorPicker.val();
        container.css("background-color", selectedColor);
    });
    container.prepend(colorPicker);
};