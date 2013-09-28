/// <reference path="../libs/_references.js" />

window.ui = (function () {

    var Controls = Class.create({
        init: function (selector) {
            this.attachHandlers(selector);
        },
        alertError: function (selector, error) {
            $(selector + ' .alert-content')
                .text(error.responseJSON.Message);

            $(selector + ' .alert-box')
                .show(300);
        },
        setAvtiveSection: function (href) {
            $('.nav-item')
                .removeClass('active');

            $('.nav-item a[href="' + href + '"]')
                .closest('.nav-item')
                .addClass('active');
        },
        attachHandlers: function (selector) {
            var self = this,
                wrap = $(selector);

            wrap.on('click', '.btn-submit', function (e) {
                $('.alert-box').hide();
            });
        }
    })

    return {
        controls: function (selector) {
            return new Controls(selector);
        }
    }
}());