var browserName = navigator.appName;
var addScroll = false;
if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

var positionX = 0;
var positionY = 0;

document.onmousemove = mouseMove;
if (browserName == "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(evn) {
    if (browserName == "Netscape") {
        positionX = evn.pageX - 5;
        positionY = evn.pageY;

        if (document.layers['ToolTip'].visibility == 'show') {
            PopTip();
        }
    }
    else {
        positionX = event.x - 5;
        positionY = event.y;

        if (document.all['ToolTip'].style.visibility == 'visible') {
            PopTip();
        }
    }
}

function PopTip() {
    if (browserName == "Netscape") {
        var layer = eval('document.layers[\'ToolTip\']');
        if ((positionX + 120) > window.innerWidth) {
            positionX = window.innerWidth - 150;
        }

        layer.left = positionX + 10;
        layer.top = positionY + 15;
        layer.visibility = 'show';
    }
    else {
        layer = eval('document.all[\'ToolTip\']');
        if (layer) {
            positionX = event.x - 5;
            positionY = event.y;

            if (addScroll) {
                positionX = positionX + document.body.scrollLeft;
                positionY = positionY + document.body.scrollTop;
            }

            if ((positionX + 120) > document.body.clientWidth) {
                positionX = positionX - 150;
            }

            layer.style.pixelLeft = positionX + 10;
            layer.style.pixelTop = positionY + 15;
            layer.style.visibility = 'visible';
        }
    }
}

function HideTip() {
    var args = HideTip.arguments;
    if (browserName == "Netscape") {
        document.layers['ToolTip'].visibility = 'hide';
    }
    else {
        document.all['ToolTip'].style.visibility = 'hidden';
    }
}

function HideMenu1() {
    if (browserName == "Netscape") {
        document.layers['menu1'].visibility = 'hide';
    }
    else {
        document.all['menu1'].style.visibility = 'hidden';
    }
}

function ShowMenu1() {
    if (browserName == "Netscape") {
        theLayer = eval('document.layers[\'menu1\']'); theLayer.visibility = 'show';
    }
    else {
        theLayer = eval('document.all[\'menu1\']'); theLayer.style.visibility = 'visible';
    }
}

function HideMenu2() {
    if (browserName == "Netscape") {
        document.layers['menu2'].visibility = 'hide';
    }
    else {
        document.all['menu2'].style.visibility = 'hidden';
    }
}

function ShowMenu2() {
    if (browserName == "Netscape") {
        theLayer = eval('document.layers[\'menu2\']');
        theLayer.visibility = 'show';
    }
    else {
        theLayer = eval('document.all[\'menu2\']');
        theLayer.style.visibility = 'visible';
    }
}