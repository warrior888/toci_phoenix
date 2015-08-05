$(document).ready(function() {
    $('#home-section').load('server/content/home.html');
    $('#about-section').load('server/content/about.html');

    ContentLoader.ScrollHandler();

});