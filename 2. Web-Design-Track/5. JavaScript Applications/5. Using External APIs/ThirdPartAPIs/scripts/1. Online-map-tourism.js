var TourismMap = function (selector) {
    var container = $(selector);
    var map;

    var locations = [];

    function addLocation(location) {
        locations.push(location);
    }

    function initialize() {
        var mapOptions = {
            zoom: 8,
            center: new google.maps.LatLng(42.70, 23.31),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.querySelector(selector), mapOptions);
        var currentIndex = 0;

        var leftArrow = $('<img src="images/left-arrow.png" id="left-arrow"/>');
        var rightArrow = $('<img src="images/right-arrow.png" id="right-arrow"/>');

        leftArrow.on('click', function () {
            currentIndex--;
            if (currentIndex < 0) {
                currentIndex = locations.length - 1;
            }
            moveMap();
        })

        rightArrow.on('click', function () {
            currentIndex++;
            if (currentIndex >= locations.length) {
                currentIndex = 0;
            }
            moveMap();
        })

        var navigationBar = $('<ol id="navigation-bar"></ol>');
        for (var i = 0; i < locations.length; i++) {
            navigationBar.append('<li data-index="' + i + '">' +
                (i + 1) + '. ' + locations[i].name + '</li>');
        }

        $('li', navigationBar).on('click', function () {
            currentIndex = $(this).attr('data-index') | 0;
            moveMap();
        });

        container.append(leftArrow);
        container.append(rightArrow);
        container.append(navigationBar);

        function moveMap() {
            placeMarker(currentIndex);
            showInfoWindow(currentIndex);
            map.panTo(locations[currentIndex].coord);
        }

        var lastInfoWindow;

        function placeMarker(index) {
            if (!map.getBounds().contains(locations[index].coord)) {
                var marker = new google.maps.Marker({
                    position: locations[index].coord,
                    map: map,
                    title: locations[index].name,
                });
            }
        }

        function showInfoWindow(index) {
            if (lastInfoWindow) {
                lastInfoWindow.close();
            }

            var infowindow = new google.maps.InfoWindow({
                map: map,
                position: locations[index].coord,
                content: locations[index].info,
            });

            lastInfoWindow = infowindow;
        }
    }

    return {
        init: initialize,
        addLocation: addLocation,
    }
}