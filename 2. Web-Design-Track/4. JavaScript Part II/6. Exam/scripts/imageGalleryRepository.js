var imageGalleryRepository = (function () {

    function save(key, value) {
        var JSONstr = JSON.stringify(value);
        localStorage.setItem(key, JSONstr);
    }

    function load(key) {
        var JSONstr = localStorage.getItem(key);
        return JSON.parse(JSONstr);
    }

    return {
        save: save,
        load: load
    }
}());