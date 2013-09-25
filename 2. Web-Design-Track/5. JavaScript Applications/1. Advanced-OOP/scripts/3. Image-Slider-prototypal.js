var controls = (function () {
    var ImageSlider = {
        init: function (selector) {
            this.root = document.querySelector(selector);
            this.images = [];
            this._currentImageIndex = 0;
            this._thumbnailimg1;
            this._thumbnailimg2;
            this._thumbnailimg3;
            this._enlargedimg;
        },

        addImage: function (title, thumbnail, enlarged) {
            var newImage = Object.create(Image);
            newImage.init(title, thumbnail, enlarged);
            this.images.push(newImage);
            return newImage;
        },

        render: function () {
            var self = this;
            var thumbnailsGallery = document.createElement('div');
            thumbnailsGallery.className = "thumbnail-gallery";

            var leftArrow = document.createElement('img');
            leftArrow.src = 'images/left-arrow.png';
            leftArrow.className = "left-arrow";
            thumbnailsGallery.appendChild(leftArrow);

            var rightArrow = document.createElement('img');
            rightArrow.src = 'images/right-arrow.png';
            rightArrow.className = "right-arrow";
            thumbnailsGallery.appendChild(rightArrow);

            thumbnailsGallery.addEventListener('click', function (ev) {
                if (!ev) ev = window.event;
                var target = ev.target;

                if (target instanceof HTMLImageElement && target.className == 'thumbnail-img') {
                    var filename = target.src.replace(/^.*[\\\/]/, '');
                    for (var i = 0; i < self.images.length; i++) {
                        var currentImageFileName = self.images[i].thumbnail.replace(/^.*[\\\/]/, '');
                        if (filename == currentImageFileName) {
                            var enlargedimgSrc = self._enlargedimg.src.replace(/^.*[\\\/]/, '');
                            if (enlargedimgSrc == self.images[i].enlarged.replace(/^.*[\\\/]/, '')) {
                                self._enlargedimg.src = "";
                            }
                            else {
                                self._enlargedimg.src = self.images[i].enlarged;
                            }
                            break;
                        }
                    }
                }
                else if (target instanceof HTMLImageElement && target.className == "left-arrow") {

                    thumbnailsGallery.removeChild(self._thumbnailimg1);
                    thumbnailsGallery.removeChild(self._thumbnailimg2);
                    thumbnailsGallery.removeChild(self._thumbnailimg3);
                    self._currentImageIndex--;
                    if (self._currentImageIndex < 0) self._currentImageIndex = self.images.length - 1;
                    self._thumbnailimg1 = self.images[self._currentImageIndex].render();
                    self._thumbnailimg2 = self.images[(self._currentImageIndex + 1) % self.images.length].render();
                    self._thumbnailimg3 = self.images[(self._currentImageIndex + 2) % self.images.length].render();
                    thumbnailsGallery.appendChild(self._thumbnailimg1);
                    thumbnailsGallery.appendChild(self._thumbnailimg2);
                    thumbnailsGallery.appendChild(self._thumbnailimg3);
                }
                else if (target instanceof HTMLImageElement && target.className == "right-arrow") {
                    thumbnailsGallery.removeChild(self._thumbnailimg1);
                    thumbnailsGallery.removeChild(self._thumbnailimg2);
                    thumbnailsGallery.removeChild(self._thumbnailimg3);
                    self._currentImageIndex++;
                    if (self._currentImageIndex >= self.images.length) self._currentImageIndex = 0;
                    self._thumbnailimg1 = self.images[self._currentImageIndex].render();
                    self._thumbnailimg2 = self.images[(self._currentImageIndex + 1) % self.images.length].render();
                    self._thumbnailimg3 = self.images[(self._currentImageIndex + 2) % self.images.length].render();
                    thumbnailsGallery.appendChild(self._thumbnailimg1);
                    thumbnailsGallery.appendChild(self._thumbnailimg2);
                    thumbnailsGallery.appendChild(self._thumbnailimg3);
                }
                ev.stopPropagation();
                ev.preventDefault();
            }, true);

            if (this.images.length >= 3) {
                this._thumbnailimg1 = this.images[this._currentImageIndex % this.images.length].render();
                this._thumbnailimg2 = this.images[(this._currentImageIndex + 1) % this.images.length].render();
                this._thumbnailimg3 = this.images[(this._currentImageIndex + 2) % this.images.length].render();
                thumbnailsGallery.appendChild(this._thumbnailimg1);
                thumbnailsGallery.appendChild(this._thumbnailimg2);
                thumbnailsGallery.appendChild(this._thumbnailimg3);
            }

            enlargedImageGallery = document.createElement('div');
            enlargedImageGallery.className = "enlarged-image";
            this._enlargedimg = document.createElement('img');
            enlargedImageGallery.appendChild(this._enlargedimg);

            this.root.appendChild(thumbnailsGallery);
            this.root.appendChild(enlargedImageGallery);
        }
    }

    var Image = {
        init: function (title, thumbnail, enlarged) {
            this.title = title.htmlEscape();
            this.thumbnail = thumbnail.htmlEscape();
            this.enlarged = enlarged.htmlEscape();
        },

        render: function () {
            var div = document.createElement('div');
            div.innerHTML = '<h3>' + this.title + '</h3><img src="' + this.thumbnail + '" alt="slider-image" class="thumbnail-img" />';
            return div;
        }
    }

    return {
        ImageSlider: ImageSlider,
        Image: Image,
    }
}());