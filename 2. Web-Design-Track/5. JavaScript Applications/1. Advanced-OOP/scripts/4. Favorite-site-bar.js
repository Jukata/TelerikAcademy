var siteBar = (function () {
    var FavoriteSiteBar = Class.create({
        init: function (selector) {
            this.root = document.querySelector(selector);
            this.root.addEventListener("click", openFolder, true);
            this.urls = [];
            this.folders = [];
        },

        addFolder: function (title) {
            var newFolder = new Folder(title.htmlEscape());
            this.folders.push(newFolder);
            return newFolder;
        },

        addUrl: function (title, url) {
            var newUrl = new Url(title.htmlEscape(), url.htmlEscape());
            this.urls.push(newUrl);
            return newUrl;
        },

        render: function () {
            var i = 0;
            while (this.root.firstChild) {
                this.root.removeChild(this.root.firstChild);
            }

            var rootUL = document.createElement('ul');
            for (i = 0; i < this.folders.length; i++) {
                rootUL.appendChild(this.folders[i].render());
            }
            for (i = 0; i < this.urls.length; i++) {
                rootUL.appendChild(this.urls[i].render());
            }

            this.root.appendChild(rootUL);
        }
    });

    var Url = Class.create({
        init: function (title, url) {
            this.title = title.htmlEscape();
            this.url = url.htmlEscape();
        },

        render: function () {
            var li = document.createElement('li');
            li.innerHTML = '<a href="' + this.url + '" target="_blank" title="' + this.url + '" >' + this.title + "</a>";
            return li;
        }
    });

    var Folder = Class.create({
        init: function (title) {
            this.title = title.htmlEscape();
            this.urls = [];
        },

        addUrl: function (title, url) {
            var newUrl = new Url(title.htmlEscape(), url.htmlEscape());
            this.urls.push(newUrl);
        },

        render: function () {
            var li = document.createElement('li');
            li.className = "folder";
            li.innerHTML = this.title;
            if (this.urls.length > 0) {
                var innerUL = document.createElement('ul');
                innerUL.style.display = "none";
                for (var i = 0; i < this.urls.length; i++) {
                    var currentUrl = this.urls[i].render();
                    innerUL.appendChild(currentUrl);
                }
                li.appendChild(innerUL);
            }
            return li;
        }
    });

    function openFolder(ev) {
        if (!ev) ev = window.event;

        var target = ev.target;
        if (target instanceof HTMLLIElement && target.className == "folder") {
            var folder = target.querySelector("ul");
            if (folder) {
                var currentDisplayStyle = folder.style.display;
                var innerUls = document.querySelectorAll("li.folder ul");
                for (var i = 0, len = innerUls.length; i < len; i++) {
                    innerUls[i].style.display = "none";
                }

                if (currentDisplayStyle == "none") {
                    folder.style.display = "";
                }
                else {
                    currentDisplayStyle = "none";
                }
            }

            ev.stopPropagation();
            ev.preventDefault();
        }
    }

    return {
        FavoriteSiteBar: FavoriteSiteBar,
        Folder: Folder,
        Url: Url,
    }
}());