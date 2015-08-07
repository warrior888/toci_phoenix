//jQuery to collapse the navbar on scroll
$(window).scroll(function() {

    console.log($(window).scrollTop());
        if ($(window).scrollTop() > 150) {
            $('#navigation-bar').css('position','fixed');
        } else {
            $('#navigation-bar').css('position','static');
        }

});

$(window).resize(function(){


    if($(window).width()>600){
        $("#collapsed-menu").css('display','none');

    }

})


$(document).ready(function(){

    $("#menu-button").click(function(){
        var collapsedMenu = $("#collapsed-menu");

        if(collapsedMenu.css('display')=='none'){


            collapsedMenu.css('display','block');
        }
        else{

            collapsedMenu.css('display','none');

        }

    })

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

        //ContentLoader.OnClickLoading(destSection);      AJAX feature


        if (docOffset >= 270) {
            sectionOffset = navHeight + navSectionOffset;
        } else {
            sectionOffset = navHeight + navSectionOffset + 90; //rozkminic: jak wyci¹gn¹æ tê liczbê?
        }

        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top - sectionOffset)
        }, 1500, 'easeInOutExpo');
            event.preventDefault();

        });
});


