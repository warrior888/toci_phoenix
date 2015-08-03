//jQuery to collapse the navbar on scroll
$(window).scroll(function() {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

//jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {

    var navHeight = $("#navigation-bar").outerHeight();
    var navSectionOffset = 25;

    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        var docOffset = $(window).scrollTop();
        var sectionOffset;

        console.log(docOffset);
        if (docOffset >= 270) {
            sectionOffset = navHeight + navSectionOffset;
        } else {
            sectionOffset = navHeight + navSectionOffset + 90; //rozkminic: jak wyci¹gn¹æ tê liczbê?
        }
        console.log(sectionOffset);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top - sectionOffset)
            }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});


