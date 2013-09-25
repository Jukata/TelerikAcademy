﻿var Class = (function () {
    function create(properties) {
        var theClass = function () {
            this.init.apply(this, arguments);
        }

        theClass.prototype = {};

        for (var prop in properties) {
            theClass.prototype[prop] = properties[prop];
        }

        if (!theClass.prototype.init) {
            theClass.prototype.init = function () { };
        }

        return theClass;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        var parentPrototype = new parent();
        this.prototype = Object.create(parentPrototype);
        this.prototype._super = parent;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return {
        create: create,
    }
}());


