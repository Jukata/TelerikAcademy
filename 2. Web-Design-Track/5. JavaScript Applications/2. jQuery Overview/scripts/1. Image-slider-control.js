var SliderControl = (function () {
	var Slider = {
		init: function (containerSelector) {
			var that = this; 
			this.container = jQuery(containerSelector);
			this.images = [];
			this.currentImageIndex = 0;

			this.slideContainer = jQuery("<div></div>");
			this.slideContainer.attr("id", "slider-slide");

			this.thumbnailContainer = jQuery("<div></div>");
			this.thumbnailContainer.attr("id", "slider-thumbs");

			this.titleContainer = jQuery("<div></div>");
			this.titleContainer.attr("id", "slider-title");
		},

		addImage: function (image) {
			this.images.push(image);
		},

		render: function () {
			this.renderThumbnails();
			this.renderSlide();
			this.renderTitle();
			this.renderNavigation();

			this.container.append(this.slideContainer);
			this.container.append(this.thumbnailContainer);
			this.container.append(this.titleContainer);

			this.stopRotate();
			this.startRotate();
		},

		renderNavigation: function () {
			var that = this;
			var previousArrow = jQuery("<button></button>");
			previousArrow.attr("id", "slider-previous-arrow");
			previousArrow.on("click", function(){
				that.previousImage();
				that.stopRotate();
				that.startRotate();
			});
			this.container.append(previousArrow);

			var nextArrow = jQuery("<button></button>");
			nextArrow.attr("id", "slider-next-arrow");
			nextArrow.on("click", function(){
				that.nextImage();	
				that.stopRotate();
				that.startRotate();
			});
			this.container.append(nextArrow);
		},

		renderThumbnails: function () {
			var that = this;
			for (var i = 0; i < this.images.length; i++) {
				var img = jQuery("<img />");
				img.attr("src", this.images[i].thumbUrl);
				img.attr("alt", this.images[i].title);
				img.on("click", function (e) {
					that.currentImageIndex = e.target.getAttribute("data-index") | 0;
					that.renderSlide();
					that.renderTitle();
					that.stopRotate();
					that.startRotate();
				});
				img.attr("data-index", i);
				img.attr("class", "slider-thumb");
				this.thumbnailContainer.append(img);
			}
		},

		renderSlide: function () {
			this.slideContainer.css("backgroundImage", "url(" + this.images[this.currentImageIndex].imageUrl + ")");
		},

		renderTitle: function () {
			this.titleContainer.html(this.images[this.currentImageIndex].title);
		},

		nextImage: function () {
			this.currentImageIndex += 1;
			if (this.currentImageIndex > this.images.length - 1) {
				this.currentImageIndex = 0;
			}

			this.renderSlide();
			this.renderTitle();

		},

		previousImage: function () {
			this.currentImageIndex -= 1;
			if (this.currentImageIndex < 0) {
				this.currentImageIndex = this.images.length - 1;
			}

			this.renderSlide();
			this.renderTitle();
			this.startRotate();
		},
		
		startRotate: function(){
			var that = this;
			if(this.rotator) {
				clearInterval(this.rotator);
			}
			this.rotator = setInterval( function(){
				that.nextImage();
			}, 2000)
		},
		
		stopRotate: function(){
			clearInterval(this.rotator);
		},
	};

	var Image = {
		init: function (title, thumbUrl, imageUrl) {
			this.title = title;
			this.thumbUrl = thumbUrl;
			this.imageUrl = imageUrl;
		},
	};

	return {
		Slider: Slider,
		Image: Image,
	};
}());