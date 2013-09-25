(function () {
    if (!Object.create) {
        Object.create = function (obj) {
            function createObj() { };
            createObj.prototype = obj;
            return new createObj();
        }
    }

    if (!Object.prototype.extend) {
        Object.prototype.extend = function (properties) {
            function createdObj() { };
            createdObj.prototype = Object.create(this);
            for (var prop in properties) {
                createdObj.prototype[prop] = properties[prop];
            }
            createdObj.prototype._super = this; // doesn't work properly
            return new createObj();
        }
    }
})();