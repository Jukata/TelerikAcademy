/// <reference path="../libs/jquery-2.0.3.js" />

define(["jquery", "class"], function ($, Class) {
    var controls = controls || {}

    var TableView = Class.create({
        init: function (sourceItems) {
            if (!(sourceItems instanceof Array)) {
                throw "Source items must be an array";
            }

            this.items = sourceItems;
        },
        render: function (selector, template, cols) {
            var container = $(selector);
            if (this.items && this.items.length > 0) {

                var table = $('<table class="table-view"></table>');
                var currentRow = $('<tr></tr>');
                table.append(currentRow);

                for (var i = 0; i < this.items.length; i++) {
                    if (i % cols == 0) {
                        currentRow = $('<tr></tr>');
                        table.append(currentRow);
                    }

                    currentRow.append(template(this.items[i]));
                }
            }

            container.append(table);
        }
    });

    controls.TableView = TableView;

    var ComboBox = Class.create({
        init: function (sourceItems) {
            if (!(sourceItems instanceof Array)) {
                throw "Source items must be an array";
            }

            this.items = sourceItems;
        },
        render: function (selector, template) {
            var container = $(selector);
            var comboBox = $('<div class="combo-box collapsed"></div>');

            for (var i = 0; i < this.items.length; i++) {
                var comboItem = $('<div class="combo-item hidden-combo-item"></div>');
                comboItem.html(template(this.items[i]));
                comboBox.append(comboItem);
            }

            comboBox.children().first().removeClass('hidden-combo-item');
            comboBox.children().first().addClass('selected-combo-item');

            this.attachEventHandlers(selector);

            container.append(comboBox);
        },
        attachEventHandlers: function (containerSelector) {
            $(containerSelector).on('click', '.combo-box.collapsed', function () {
                var target = $(this);
                target.removeClass('collapsed');
                target.addClass('expanded');

                $('.combo-item', target).removeClass('hidden-combo-item');
            })

            $(containerSelector).on('click', '.combo-box.expanded .combo-item', function () {
                var target = $(this);
                var targetComboBox = target.parent();
                targetComboBox.addClass('collapsed').removeClass('expanded');
                targetComboBox.children('.combo-item')
                    .removeClass('selected-combo-item').addClass('hidden-combo-item');
                target.addClass('selected-combo-item');
            })
        },
    });

    controls.ComboBox = ComboBox;

    return controls;
})