var Carousel = function (imageContainer, imagesPaths, buttonPrevious, buttonNext, w, h) {
    var self = this;
    self.imageContainer = document.getElementById(imageContainer);
    self.imagesPaths = imagesPaths || [];
    var img = document.createElement('img');
    var currentImageIndex = 0;

    var btnPrev = document.getElementById(buttonPrevious);
    var btnNext = document.getElementById(buttonNext);

    var width = w;
    var height = h;

    var interval;

    function init() {
        btnPrev.addEventListener('click', moveLeft, false);
        btnNext.addEventListener('click', moveRight, false);
        self.imageContainer.addEventListener('click', slideshow, false);

        img.id = 'main-image';
        img.width = width;
        img.height = height;
        img.src = imagesPaths[0];
        img.alt = 'carousel-image';
        self.imageContainer.appendChild(img);
    }

    function moveLeft(ev) {
        currentImageIndex--;
        if (currentImageIndex < 0) currentImageIndex = imagesPaths.length - 1;
        img.src = imagesPaths[currentImageIndex];
        ev.stopPropagation();
    }

    function moveRight(ev) {
        currentImageIndex++;
        if (currentImageIndex >= imagesPaths.length) currentImageIndex = 0;
        img.src = imagesPaths[currentImageIndex];
        ev.stopPropagation();
    }

    function slideshow() {

        if (interval) {
            clearInterval(interval);
            interval = 0;
        }
        else {
            interval = setInterval(function () {
                moveRight();
            }, 1500);
        }
    }

    function addImage(path) {
        self.imagesPaths.push(path);
    }

    return {
        init: init,
        addImage:addImage
    }
};