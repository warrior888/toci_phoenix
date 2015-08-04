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
    var navSectionOffset = 0;


    $('a.page-scroll').bind('click', function(event) {

        event.preventDefault();

        var $anchor = $(this);
        var docOffset = $(window).scrollTop();
        var sectionOffset;

        var destSection = '#' + $($anchor.attr('href')).attr('id');

        console.log('============================ ',ContentLoader.iterator);
        ContentLoader.OnClickLoading(destSection);

        setTimeout(function(){
            //console.log('Scrolling-nav: ', ContentLoader.iterator);
            if (docOffset >= 270) {
                sectionOffset = navHeight + navSectionOffset;
            } else {
                sectionOffset = navHeight + navSectionOffset + 90; //rozkminic: jak wyci¹gn¹æ tê liczbê?
            }
            //  console.log(sectionOffset);
            $('html, body').stop().animate({
                scrollTop: ($($anchor.attr('href')).offset().top - sectionOffset)
            }, 1500, 'easeInOutExpo');
            event.preventDefault();
        }, 1000);
        });



});


