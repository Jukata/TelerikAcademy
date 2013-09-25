var player;

function onYouTubeIframeAPIReady() {
    player = new YT.Player('yt-player', {
        height: '390',
        width: '640',
        videoId: 'gaTtGpjnKtA',
        events: {
            'onStateChange': onPlayerStateChange
        }
    });
}

function onPlayerStateChange() {
    var shareTag = document.getElementById('share-tag');
    shareTag.setAttribute('href', player.getVideoUrl());
}

document.getElementById('single-video').addEventListener('click', function () {
    var video = document.getElementById('load-video').value;
    player.cueVideoById(video, 0, "large");
}, false);

document.getElementById('pause').addEventListener('click', function () {
    player.pauseVideo();
}, false);

document.getElementById('play').addEventListener('click', function () {
    player.playVideo();
}, false);

document.getElementById('stop').addEventListener('click', function () {
    player.stopVideo();
}, false);

document.getElementById('load-playlist').addEventListener('click', function () {
    var videoPlaylist = document.getElementById('playlist').value.split(',');
    if (videoPlaylist.length > 0) {
        player.cuePlaylist(videoPlaylist, 0, 0, "large");
    }
}, false);

document.getElementById('previous').addEventListener('click', function () {
    player.previousVideo();
}, false);

document.getElementById('next').addEventListener('click', function () {
    player.nextVideo();
}, false);

document.getElementById('mute').addEventListener('click', function () {
    player.mute();
}, false);

document.getElementById('unmute').addEventListener('click', function () {
    player.unMute();
}, false);

document.getElementById('quality').addEventListener('change', function () {
    var quality = this.value;
    player.setPlaybackQuality(quality);
}, false);