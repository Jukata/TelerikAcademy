var controls = (function () {

    function Gallery(selector) {
        var self = this;
        var root = document.querySelector(selector);
        root.style.position = "relative";
        addEventHandler(root, "click", onclick);
        var enlargedImgHolder = document.createElement("div");
        enlargedImgHolder.className = "enlarged-image-holder";
        root.appendChild(enlargedImgHolder);

        self.images = [];
        self.albums = [];

        var sortButton = document.createElement("button");
        sortButton.className = "sort-button";
        sortButton.innerHTML = "Sort";
        addEventHandler(sortButton, "click", function (ev) {
            if (!ev) ev = window.event;
            if (ev.stopPropagation) ev.stopPropagation();
            if (ev.preventDefault) ev.preventDefault();

            self.albums.sort(function (a, b) {
                if (a.tittle < b.title) return -1;
                else if (a.title === b.title) return 0;
                else return 1;
            });
            self.render();
        });
        root.appendChild(sortButton);

        this.addImage = function (title, src) {
            var image = new Image(title, src);
            self.images.push(image);
            return image;
        }

        this.addAlbum = function (title) {
            var album = new Album(title);
            self.albums.push(album);
            return album;
        }

        this.render = function () {
            var i = 0;

            for (i = 0; i < self.images.length; i++) {
                root.appendChild(self.images[i].render());
            }

            for (i = 0; i < self.albums.length; i++) {
                root.appendChild(self.albums[i].render());
            }

            return this;
        }

        this.getImageGalleryData = function () {
            var i;
            var galleryData = {
                "images": [],
                "albums": []
            };

            for (i = 0; i < self.images.length; i++) {
                galleryData.images.push(self.images[i].save());
            }

            for (i = 0; i < self.albums.length; i++) {
                galleryData.albums.push(self.albums[i].save());
            }

            return galleryData;
        }

        setImageGalleryData = function (dataContainer, data) {
            var i;
            if (data.images) {
                for (i = 0; i < data.images.length; i++) {
                    //var newImage = new Image(data.images[i].title, data.images[i].src)
                    dataContainer.addImage(data.images[i].title, data.images[i].src);
                }
            }
            if (data.albums) {
                for (i = 0; i < data.albums.length; i++) {
                    //var newAlbum = new Album(data.albums[i].title);
                    var newAlbum = dataContainer.addAlbum(data.albums[i].title);
                    setImageGalleryData(newAlbum, data.albums[i]);
                }
            }
        }

        function onclick(ev) {
            if (!ev) ev = window.event;

            if (ev.stopPropagation) ev.stopPropagation();
            if (ev.preventDefault) ev.preventDefault();

            var clickedItem = ev.target;
            if (clickedItem instanceof HTMLSpanElement && clickedItem.className === "album-title") {
                var nextSibling = clickedItem.nextElementSibling;
                while (nextSibling) {
                    if (nextSibling.className === "gallery-image" || nextSibling.className === "gallery-album") {
                        if (nextSibling.style.display === "none") {
                            nextSibling.style.display = "";
                        }
                        else {
                            nextSibling.style.display = "none";
                        }
                    }
                    nextSibling = nextSibling.nextElementSibling;
                }
            }
            else if (clickedItem instanceof HTMLImageElement) {

                enlargedImgHolder.innerHTML = "";

                if (clickedItem.className && clickedItem.className == "enlarged-image") {
                    return;
                }

                var width = clickedItem.width * 2;
                var height = clickedItem.height * 2;

                var title = clickedItem.parentNode.getElementsByTagName("span")[0].innerHTML;
                enlargedImgHolder.innerHTML = "<span class='enlarged-title'>" + title + "</span><br />";
                var enlargedImg = document.createElement("img");
                enlargedImg.className = "enlarged-image";
                enlargedImg.width = width;
                enlargedImg.height = height;
                enlargedImg.src = clickedItem.src;
                enlargedImgHolder.appendChild(enlargedImg);
            }
        }

        this.clear = function () {
            self.images = [];
            self.albums = [];
            while (root.firstChild) root.removeChild(root.firstChild);
            this.render();
        }
    }

    function Image(title, src) {
        this.title = escapeTags(title);
        var img = document.createElement("img");
        img.src = src;
        var imgHolder = document.createElement("div");
        imgHolder.className = "gallery-image";
        imgHolder.innerHTML = "<span>" + this.title + "</span><br />";

        this.render = function () {
            imgHolder.appendChild(img);
            return imgHolder;
        }

        this.save = function () {
            return {
                "title": this.title,
                "src": src
            }
        }
    }

    function Album(title) {
        var self = this;
        this.title = escapeTags(title);
        var albumHolder = document.createElement("div");
        albumHolder.innerHTML = "<span class='album-title'>" + this.title + "</span><br />";
        albumHolder.className = "gallery-album";

        self.images = [];
        self.albums = [];

        var sortButton = document.createElement("button");
        sortButton.innerHTML = "Sort";
        sortButton.className = "sort-button"
        albumHolder.appendChild(sortButton);
        addEventHandler(sortButton, "click", function (ev) {
            if (!ev) ev = window.event;
            if (ev.stopPropagation) ev.stopPropagation();
            if (ev.preventDefault) ev.preventDefault();

            self.albums.sort(function (a, b) {
                if (a.tittle < b.title) return -1;
                else if (a.title === b.title) return 0;
                else return 1;
            });
            self.render();
        });

        this.render = function () {
            var i;

            for (i = 0; i < self.images.length; i++) {
                var image = self.images[i].render();
                albumHolder.appendChild(image);
            }

            for (i = 0; i < self.albums.length; i++) {
                var album = self.albums[i].render();
                albumHolder.appendChild(album);
            }

            return albumHolder;
        }

        this.addImage = function (title, src) {
            var image = new Image(title, src);
            self.images.push(image);
            return image;
        }

        this.addAlbum = function (title) {
            var album = new Album(title);
            self.albums.push(album);
            return album;
        }

        this.save = function () {
            var i;
            var savedAlbum = { "title": this.title };
            if (self.images.length > 0) {
                savedAlbum.images = [];
                for (i = 0; i < self.images.length; i++) {
                    savedAlbum.images.push(self.images[i].save());
                }
            }
            if (self.albums.length > 0) {
                savedAlbum.albums = [];
                for (i = 0; i < self.albums.length; i++) {
                    savedAlbum.albums.push(self.albums[i].save());
                }
            }
            return savedAlbum;
        }
    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        },
        buildImageGallery: function (selector, data) {
            newGallery = new Gallery(selector);
            setImageGalleryData(newGallery, data);
            return newGallery;
        }
    }
})();